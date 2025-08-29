namespace WireGuardConfigGenerator.DataModel;

public class AppSettings
{
	public string Endpoint { get; set; } = null!;
	public string Address { get; set; } = string.Empty;
	public int ListenPort { get; set; }
	public int PersistentKeepalive { get; set; }
	public string PostUp { get; set; } = string.Empty;
}
