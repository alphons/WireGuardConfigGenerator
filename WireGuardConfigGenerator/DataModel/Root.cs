using System.Text.Json;
using System.Text.Json.Serialization;
using WireGuardConfigGenerator.Helpers;

namespace WireGuardConfigGenerator.DataModel;


public class Root
{
	private static readonly JsonSerializerOptions options = new() 
	{ 
		WriteIndented = true,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
	};

	public List<Group> Groups { get; set; } = [];

	public async Task SaveAsync(string path, string password) =>
		await CryptoUtils.CompressAndEncryptToFileAsync(this, password, path);

	public async Task LoadAsync(string path, string password)
	{
		if (File.Exists(path))
		{
			var root = await CryptoUtils.DecryptAndDecompressFromFileAsync<Root>(path, password) ?? new();
			if (root != null)
			{
				Groups = root.Groups;
			}
		}
	}
}

public class Group
{
	public string Name { get; set; } = string.Empty;
	public List<Server> Servers { get; set; } = [];
}

public class WireGuardItem
{
	public string Name { get; set; } = string.Empty;
	public string? PubKey { get; set; }
	public string? PrivateKey { get; set; }
	public int ListenPort { get; set; }
	public string? AllowedIPs { get; set; }
	public string Address { get; set; } = "0.0.0.0";
	public string? DNS { get; set; }
}

public class Server : WireGuardItem
{
	public int MTU { get; set; }
	public string? PreUp { get; set; }
	public string? PostUp { get; set; }
	public string? PreDown { get; set; }
	public string? PostDown { get; set; }
	public string? Comment { get; set; }
	public bool Disabled { get; set; }
	public bool SaveConfig { get; set; }
	public bool UseDNS { get; set; }
	public bool UseMTU { get; set; }
	public bool UsePreUp { get; set; }
	public bool UsePostUp { get; set; }
	public bool UsePreDown { get; set; }
	public bool UsePostDown { get; set; }
	public string? Endpoint { get; set; }

	[JsonIgnore]
	public Group? ParentGroup { get; set; }
	public List<Peer> Peers { get; set; } = [];
}

public class Peer : WireGuardItem
{
	public int PersistentMaxConnections { get; set; }
	public int PersistentMinConnections { get; set; }
	public string? PersistentConnectionInterval { get; set; }
	public int MTU { get; set; }
	public string? PreUp { get; set; }
	public string? PostUp { get; set; }
	public string? PreDown { get; set; }
	public string? PostDown { get; set; }
	public string? Comment { get; set; }
	public bool Disabled { get; set; }
	public bool SaveConfig { get; set; }
	public bool UseDNS { get; set; }
	public bool UseMTU { get; set; }
	public bool UsePreUp { get; set; }
	public bool UsePostUp { get; set; }
	public bool UsePreDown { get; set; }
	public bool UsePostDown { get; set; }
	public bool UsePersistentKeepalive { get; set; }
	public bool UsePersistentMaxConnections { get; set; }
	public bool UsePersistentMinConnections { get; set; }
	public bool UsePersistentConnectionInterval { get; set; }
	public bool UsePersistentConnectionTimeout { get; set; }
	public int PersistentKeepalive { get; set; }

	[JsonIgnore]
	public Server? ParentServer { get; set; }
	

}
