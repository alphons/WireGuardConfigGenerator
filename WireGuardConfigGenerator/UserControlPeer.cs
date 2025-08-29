using WireGuardConfigGenerator.DataModel;
using WireGuardConfigGenerator.Helpers;

namespace WireGuardConfigGenerator;

public partial class UserControlPeer : UserControl
{
	private readonly Peer? peer;
	public UserControlPeer(Peer peer)
	{
		this.peer = peer;

		InitializeComponent();

		MakeConfig();
	}

	private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.tabControl1.SelectedIndex == 0)
			MakeConfig();
		if (this.tabControl1.SelectedIndex == 1)
			ShowPeer();
	}

	private void MakeConfig()
	{
		if (this.peer == null)
			return;

		string config = $"""
            [Interface]
            PrivateKey = {this.peer.PrivateKey}
            ListenPort = {this.peer.ListenPort}
            Address = {this.peer.Address}
            """ + (string.IsNullOrEmpty(peer.DNS) ? "" : $"{Environment.NewLine}DNS = {peer.DNS}{Environment.NewLine}");

		var server = peer.ParentServer;

		if (server == null)
			return;

		config += $"""
				{Environment.NewLine}
				[Peer]
				Eindpoint ={server.Endpoint}
				PublicKey = {server.PubKey}
				AllowedIPs = {server.AllowedIPs}
				PersistentKeepalive = {peer.PersistentKeepalive}
				""";

		this.txtConf.Text = config;
	}

	private void Copy_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(this.txtConf.Text);
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


		ShowPeer();
	}

	private void ShowPeer()
	{
		if (peer == null)
			return;

		this.lblName.Text = peer.Name;

		if (string.IsNullOrWhiteSpace(peer.AllowedIPs))
			peer.AllowedIPs = $"{peer.ParentServer?.Address}";

		this.txtPrivateKey.Text = peer.PrivateKey;
		this.txtPublicKey.Text = peer.PubKey;
		this.txtListenPort.Text = peer.ListenPort.ToString();
		this.txtAddress.Text = peer.Address?.Split('/')[0];
		this.comboBox1.SelectedItem = peer.Address?.Split('/')[1];
		this.txtPersistenKeepAlive.Text = peer.PersistentKeepalive.ToString();
		this.txtDnsServers.Text = peer.DNS;
	}


	private void Save_Click(object sender, EventArgs e)
	{
		if (peer == null)
			return;

		this.peer.PrivateKey = this.txtPrivateKey.Text;
		this.peer.PubKey = this.txtPublicKey.Text;
		this.peer.ListenPort = int.TryParse(this.txtListenPort.Text, out int port) ? port : 0;
		this.peer.Address = $"{this.txtAddress.Text}/{this.comboBox1.SelectedItem}";
		this.peer.PersistentKeepalive = int.TryParse(this.txtPersistenKeepAlive.Text, out int pka) ? pka : 0;
		this.peer.DNS = this.txtDnsServers.Text;

		this.buttonEdit.Enabled = true;
		this.buttonCancel.Enabled = false;
		this.buttonSave.Enabled = false;
		this.groupBox1.Enabled = false;

		ShowPeer();
	}

	private async Task RenewKeysAsync()
	{
		if (peer == null)
			return;

		string privateKey = await WireGuard.ExecuteAsync("wg genkey");
		string publicKey = await WireGuard.ExecuteAsync($"echo {privateKey} | wg pubkey");

		peer.PrivateKey = privateKey;
		peer.PubKey = publicKey;

		this.Invoke(() =>
		{
			this.txtPrivateKey.Text = peer.PrivateKey;
			this.txtPublicKey.Text = peer.PubKey;
			MakeConfig();
		});
	}

	private async void RenewKeys_Click(object sender, EventArgs e)
	{
		await RenewKeysAsync();
	}

	private async void GeneratePublicKey_Click(object sender, EventArgs e)
	{
		if (peer == null) return;

		string privateKey = this.txtPrivateKey.Text;
		string publicKey = await WireGuard.ExecuteAsync($"echo {privateKey} | wg pubkey");

		peer.PrivateKey = privateKey;
		peer.PubKey = publicKey;

		this.txtPrivateKey.Text = peer.PrivateKey;
		this.txtPublicKey.Text = peer.PubKey;
		MakeConfig();
	}
}
