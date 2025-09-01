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

		var server = peer.ParentServer;

		if (server == null)
			return;

		string config = $"""
            [Interface]
            PrivateKey = {this.peer.PrivateKey}
            ListenPort = {this.peer.ListenPort}
            Address = {this.peer.Address}
            """
			+ (this.peer.UseDNS ? (string.IsNullOrEmpty(peer.DNS) ? "" : $"{Environment.NewLine}DNS = {peer.DNS}") : $"{Environment.NewLine}DNS = {server.DNS}{Environment.NewLine}")
			;

		config += $"""
				{Environment.NewLine}
				[Peer]
				Endpoint = {server.Endpoint}
				PublicKey = {server.PubKey}
				"""
				+ (this.peer.UseAllowedIPs ? $"{Environment.NewLine}AllowedIPs = {peer.AllowedIPs}" : $"{Environment.NewLine}AllowedIPs = {server.AllowedIPs}")
				+ (this.peer.UsePersistentKeepalive ? $"{Environment.NewLine}PersistentKeepalive = {peer.PersistentKeepalive}" : $"{Environment.NewLine}PersistentKeepalive = {server.PersistentKeepalive}")
				;

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

		this.txtPrivateKey.Text = peer.PrivateKey;
		this.txtPublicKey.Text = peer.PubKey;
		this.txtListenPort.Text = peer.ListenPort.ToString();
		this.txtAddress.Text = peer.Address?.Split('/')[0];
		this.comboBox1.SelectedItem = peer.Address?.Split('/')[1];

		if (peer.UsePersistentKeepalive)
			this.txtPersistenKeepAlive.Text = peer.PersistentKeepalive.ToString();
		else
			this.txtPersistenKeepAlive.Text = peer.ParentServer?.PersistentKeepalive.ToString();

		if (peer.UseDNS)
			this.txtDnsServers.Text = $"{peer.DNS}";
		else
			this.txtDnsServers.Text = $"{peer.ParentServer?.DNS}";

		if (peer.UseAllowedIPs)
			this.txtAllowedIPs.Text = $"{peer.AllowedIPs?.Replace(';',',')}";
		else
			this.txtAllowedIPs.Text = $"{peer.ParentServer?.AllowedIPs}";

		this.chkUseAllowedIPs.Checked = this.peer.UseAllowedIPs;
		this.chkUseDns.Checked = this.peer.UseDNS;
		this.chkUseKeepAlive.Checked = this.peer.UsePersistentKeepalive;
	}


	private void Save_Click(object sender, EventArgs e)
	{
		if (peer == null)
			return;

		this.peer.PrivateKey = this.txtPrivateKey.Text;
		this.peer.PubKey = this.txtPublicKey.Text;
		this.peer.ListenPort = int.TryParse(this.txtListenPort.Text, out int port) ? port : 0;
		this.peer.Address = $"{this.txtAddress.Text}/{this.comboBox1.SelectedItem}";

		this.peer.UseAllowedIPs = this.chkUseAllowedIPs.Checked;
		this.peer.UseDNS = this.chkUseDns.Checked;
		this.peer.UsePersistentKeepalive = this.chkUseKeepAlive.Checked;

		if(this.peer.UseDNS)
			this.peer.DNS = this.txtDnsServers.Text;

		if (this.peer.UseAllowedIPs)
			this.peer.AllowedIPs = this.txtAllowedIPs.Text;

		if (this.peer.UsePersistentKeepalive)
			this.peer.PersistentKeepalive = int.TryParse(this.txtPersistenKeepAlive.Text, out int pka) ? pka : 0;

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

	private void AllowedIP_CheckedChanged(object sender, EventArgs e)
	{
		this.txtAllowedIPs.Enabled = this.chkUseAllowedIPs.Checked;
	}

	private void Dns_CheckedChanged(object sender, EventArgs e)
	{
		this.txtDnsServers.Enabled = this.chkUseDns.Checked;
	}

	private void UseKeepAlive_CheckedChanged(object sender, EventArgs e)
	{
		this.txtPersistenKeepAlive.Enabled = this.chkUseKeepAlive.Checked;
	}
}
