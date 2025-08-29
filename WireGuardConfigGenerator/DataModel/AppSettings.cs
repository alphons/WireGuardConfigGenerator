namespace WireGuardConfigGenerator.DataModel;

public class AppSettings
{
	public string Endpoint { get; set; } = "vpn.example.com:56900";
	public string Address { get; set; } = "10.0.0.1/32";
	public int ListenPort { get; set; } = 56900;
	public int PersistentKeepalive { get; set; } = 25;
	public string PostUp { get; set; } = string.Empty;
}
