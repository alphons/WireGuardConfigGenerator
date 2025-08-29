using WireGuardConfigGenerator.DataModel;
using WireGuardConfigGenerator.Helpers;

namespace WireGuardConfigGenerator;

public partial class UserControlServer : UserControl
{
	private readonly Server? server;
	public UserControlServer(Server server)
	{
		InitializeComponent();

		this.server = server;

		MakeConfig();
	}

	private void ShowServer()
	{
		if (server == null)
			return;

		this.txtEndpoint.Text = server.Endpoint;
		this.txtPrivateKey.Text = server.PrivateKey;
		this.txtPublicKey.Text = server.PubKey;
		this.lblName.Text = server.Name;
		this.txtListenPort.Text = server.ListenPort.ToString();
		this.txtAddress.Text = server.Address?.Split('/')[0];
		this.comboBox1.SelectedItem = server.Address?.Split('/')[1];
		this.txtPostUp.Text = server.PostUp;
		this.txtAllowedIPs.Text = server.AllowedIPs;
	}

	private void Edit_Click(object sender, EventArgs e)
	{
		this.buttonEdit.Enabled = false;
		this.buttonCancel.Enabled = true;
		this.buttonSave.Enabled = true;
		this.groupBox1.Enabled = true;
	}

	private void Cancel_Click(object sender, EventArgs e)
	{

		this.buttonEdit.Enabled = true;
		this.buttonCancel.Enabled = false;
		this.buttonSave.Enabled = false;
		this.groupBox1.Enabled = false;


		ShowServer();
	}

	private void Save_Click(object sender, EventArgs e)
	{
		if (server == null)
			return;

		this.server.Endpoint = this.txtEndpoint.Text;
		this.server.PrivateKey = this.txtPrivateKey.Text;
		this.server.ListenPort = int.TryParse(this.txtListenPort.Text, out int port) ? port : 0;
		this.server.Address = $"{this.txtAddress.Text}/{this.comboBox1.SelectedItem}";
		this.server.PostUp = this.txtPostUp.Text;
		this.server.PubKey = this.txtPublicKey.Text;
		this.server.AllowedIPs = this.txtAllowedIPs.Text;

		this.buttonEdit.Enabled = true;
		this.buttonCancel.Enabled = false;
		this.buttonSave.Enabled = false;
		this.groupBox1.Enabled = false;

		ShowServer();
	}

	private void Copy_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(this.txtConf.Text);
	}

	private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.tabControl1.SelectedIndex == 0)
			MakeConfig();
		if (this.tabControl1.SelectedIndex == 1)
			ShowServer();
	}

	private void MakeConfig()
	{
		if (this.server == null)
			return;

		string config = $"""
            [Interface]
            PrivateKey = {this.server.PrivateKey}
            ListenPort = {this.server.ListenPort}
            Address = {this.server.Address}
            """ + (string.IsNullOrEmpty(server.PostUp) ? "" : $"{Environment.NewLine}PostUp = {server.PostUp}{Environment.NewLine}") +
			$"{Environment.NewLine}";

		foreach (var peer in server.Peers)
		{
			config += $"""
				
				[Peer]
				PublicKey = {peer.PubKey}
				AllowedIPs = {peer.Address}
				PersistentKeepalive = {peer.PersistentKeepalive}

				""";
		}

		this.txtConf.Text = config;
	}

	private async void RenewKeys_Click(object sender, EventArgs e)
	{
		await RenewKeysAsync();
	}

	private async Task RenewKeysAsync()
	{
		if (server == null)
			return;

		string privateKey = await WireGuard.ExecuteAsync("wg genkey");
		string publicKey = await WireGuard.ExecuteAsync($"echo {privateKey} | wg pubkey");

		server.PrivateKey = privateKey;
		server.PubKey = publicKey;

		this.Invoke(() =>
		{
			this.txtPrivateKey.Text = server.PrivateKey;
			this.txtPublicKey.Text = server.PubKey;
			MakeConfig();
		});
	}

	private async void GenersatePublicKey_Click(object sender, EventArgs e)
	{
		if (server == null) return;
		string privateKey = this.txtPrivateKey.Text;
		string publicKey = await WireGuard.ExecuteAsync($"echo {privateKey} | wg pubkey");
		server.PubKey = publicKey;
		this.txtPublicKey.Text = server.PubKey;
		MakeConfig();
	}
}
