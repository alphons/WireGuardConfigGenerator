using System.Diagnostics;

namespace WireGuardConfigGenerator.Helpers;

public class WireGuard
{
	public static async Task<string> ExecuteAsync(string command)
	{
		using Process process = new()
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = $"/C {command}",
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			}
		};

		process.Start();
		string output = await process.StandardOutput.ReadToEndAsync();
		await process.WaitForExitAsync();
		return output.Trim();
	}
}
