using System.IO.Compression;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WireGuardConfigGenerator.Helpers;

public static class CryptoUtils
{
	private const int SaltSize = 16; // 128 bits alt
	private const int KeySize = 32;  // 256 bits AES-256
	private const int IVSize = 16;   // 128 bits AES IV
	private const int Iterations = 100000; // PBKDF2 iterations

	public static async Task<bool> CompressAndEncryptToFileAsync<T>(T model, string password, string filePath, JsonSerializerOptions? options = null, CancellationToken ct = default)
	{
		options ??= new JsonSerializerOptions
		{
			WriteIndented = false,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
		};

		// 1. to JSON
		string json = JsonSerializer.Serialize(model, options);

		// 2. Compressing using GZIP
		byte[] compressed;
		using (var outputStream = new MemoryStream())
		{
			using (var gzipStream = new GZipStream(outputStream, CompressionLevel.Optimal))
			using (var writer = new StreamWriter(gzipStream))
			{
				await writer.WriteAsync(json);
			}
			compressed = outputStream.ToArray();
		}

		// 3. Make some salt
		byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

		// 4. Key and IV derive using PBKDF2
		using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
		byte[] keyMaterial = pbkdf2.GetBytes(KeySize + IVSize);
		byte[] key = new byte[KeySize];
		byte[] iv = new byte[IVSize];
		Array.Copy(keyMaterial, 0, key, 0, KeySize);
		Array.Copy(keyMaterial, KeySize, iv, 0, IVSize);

		// 5. Encrypt using AES
		byte[] encrypted;
		using (var aes = Aes.Create())
		{
			aes.Key = key;
			aes.IV = iv;
			using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
			using var ms = new MemoryStream();
			using (var cryptostream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
			{
				await cryptostream.WriteAsync(compressed, ct);
			}
			encrypted = ms.ToArray();
		}

		// 6. Salt prefixed to ciphertext
		byte[] result = new byte[SaltSize + encrypted.Length];
		Array.Copy(salt, 0, result, 0, SaltSize);
		Array.Copy(encrypted, 0, result, SaltSize, encrypted.Length);

		// 7. Async file write
		await File.WriteAllBytesAsync(filePath, result, ct);

		return true;
	}

	public static async Task<T?> DecryptAndDecompressFromFileAsync<T>(string filePath, string password, JsonSerializerOptions? options = null, CancellationToken ct = default)
	{
		options ??= new JsonSerializerOptions();

		// 1. Asynch read file
		byte[] encryptedData = await File.ReadAllBytesAsync(filePath, ct);

		// 2. Salt and ciphertext
		if (encryptedData.Length < SaltSize)
			throw new ArgumentException("Encrypted data is too short to contain salt.");

		byte[] salt = new byte[SaltSize];
		byte[] ciphertext = new byte[encryptedData.Length - SaltSize];
		Array.Copy(encryptedData, 0, salt, 0, SaltSize);
		Array.Copy(encryptedData, SaltSize, ciphertext, 0, ciphertext.Length);

		// 3. Key and IV using PBKDF2
		using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
		byte[] keyMaterial = pbkdf2.GetBytes(KeySize + IVSize);
		byte[] key = new byte[KeySize];
		byte[] iv = new byte[IVSize];
		Array.Copy(keyMaterial, 0, key, 0, KeySize);
		Array.Copy(keyMaterial, KeySize, iv, 0, IVSize);

		// 4. Decrypten using AES
		byte[] decompressed;
		using (var aes = Aes.Create())
		{
			aes.Key = key;
			aes.IV = iv;
			using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
			using var ms = new MemoryStream();
			using (var cryptostream = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
			{
				await cryptostream.WriteAsync(ciphertext, ct);
			}
			decompressed = ms.ToArray();
		}

		// 5. Decompress using GZIP
		string json;
		using (var inputStream = new MemoryStream(decompressed))
		using (var gzipStream = new GZipStream(inputStream, CompressionMode.Decompress))
		using (var reader = new StreamReader(gzipStream))
		{
			json = await reader.ReadToEndAsync(ct);
		}

		// 6. Deserialise to model
		return JsonSerializer.Deserialize<T>(json, options);
	}
}
