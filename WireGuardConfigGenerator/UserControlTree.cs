using System.Text.Json;
using System.Xml.Linq;
using WireGuardConfigGenerator.DataModel;
using WireGuardConfigGenerator.Helpers;

namespace WireGuardConfigGenerator;
public partial class UserControlTree : UserControl
{
	private readonly AppSettings Settings;

	private readonly Root root = new();
	public UserControlTree()
	{
		InitializeComponent();

		var path = Path.Combine(AppContext.BaseDirectory, "config.json");
		if (File.Exists(path))
			this.Settings = JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(path)) ?? new();
		else
			this.Settings = new();
	}

	private void UserControlTree_Load(object sender, EventArgs e)
	{
		if (this.ParentForm is Form1 form)
			form.FormClosing += (s, e) => root.Save();

		LoadTree();
	}

	private void LoadTree()
	{
		root.Load();

		this.treeView1.Nodes.Clear();
		foreach (var group in root.Groups)
		{
			var groupNode = new TreeNode(group.Name) { Tag = group };
			this.treeView1.Nodes.Add(groupNode);
			foreach (var server in group.Servers)
			{
				server.ParentGroup = group;
				var serverNode = new TreeNode(server.Name) { Tag = server };
				groupNode.Nodes.Add(serverNode);
				foreach (var peer in server.Peers)
				{
					peer.ParentServer = server;
					var peerNode = new TreeNode(peer.Name) { Tag = peer };
					serverNode.Nodes.Add(peerNode);
				}
			}
		}
		this.treeView1.ExpandAll();
	}

	private static DialogResult DeleteIt() =>
		MessageBox.Show("Delete", "Delete it", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


	private static string GetSubnet(string? ipAddress) =>
		ipAddress == null ? "10.0.0" : ipAddress[..ipAddress.LastIndexOf('.')];


	private static void DeleteGroup(Root root, TreeNode node, Group group)
	{
		if (DeleteIt() == DialogResult.OK)
		{
			root.Groups.Remove(group);
			node.Remove();
		}
	}

	private static void DeleteServer(TreeNode node, Server server)
	{
		if (DeleteIt() == DialogResult.OK)
		{
			server.ParentGroup?.Servers.Remove(server);
			node.Remove();
		}
	}

	private static void DeletePeer(TreeNode node, Peer peer)
	{
		if (DeleteIt() == DialogResult.OK)
		{
			peer.ParentServer?.Peers.Remove(peer);
			node.Remove();
		}
	}

	private async Task CreateNewServerAsync(TreeNode node, Group group)
	{
		string privateKey = await WireGuard.ExecuteAsync("wg genkey");
		string publicKey = await WireGuard.ExecuteAsync($"echo {privateKey} | wg pubkey");

		var offset = group.Servers.Count + 1;
		var name = $"Server {offset}";
		Server server = new()
		{
			Name = name,
			ParentGroup = group,
			ListenPort = Settings.ListenPort + (group.Servers.Count * 100) - ((this.root.Groups.Count - 1) * 1000),
			Address = Settings.Address,
			Endpoint = Settings.Endpoint,
			PostUp = string.Format(Settings.PostUp, name),
			PrivateKey = privateKey,
			PubKey = publicKey
		};

		group.Servers.Add(server);
		node.Nodes.Add(new TreeNode(server.Name) { Tag = server });
		node.Expand();
	}

	private async Task CreateNewPeerAsync(TreeNode node, Server server)
	{
		string privateKey = await WireGuard.ExecuteAsync("wg genkey");
		string publicKey = await WireGuard.ExecuteAsync($"echo {privateKey} | wg pubkey");

		var offset = server.Peers.Count + 1;
		var subnet = GetSubnet(server.Address);
		Peer newPeer = new()
		{
			ParentServer = server,
			Name = $"Peer {offset}",
			Address = $"{subnet}.{offset + 1}/32",
			ListenPort = server.ListenPort + offset + 1,
			AllowedIPs = $"{server.Address.Split('/')[0]}/24",
			PersistentKeepalive = Settings.PersistentKeepalive,
			PrivateKey = privateKey,
			PubKey = publicKey
		};
		server.Peers.Add(newPeer);
		node.Nodes.Add(new TreeNode(newPeer.Name) { Tag = newPeer });
		node.Expand();
	}

	private void ShowContextMenu(Point location)
	{
		this.contextMenuStrip1.Items.Clear();

		if (this.treeView1.SelectedNode is not TreeNode node)
		{
			contextMenuStrip1.Items.Add(new ToolStripMenuItem("Add Group", null, (s, e) =>
			{
				Group newGroup = new() { Name = "New Group" };
				root.Groups.Add(newGroup);
				this.treeView1.Nodes.Add(new TreeNode(newGroup.Name) { Tag = newGroup });
			}));
		}
		else if (node.Tag is Group group)
		{
			contextMenuStrip1.Items.Add(new ToolStripMenuItem("Add Server", null, async (s, e) => await CreateNewServerAsync(node, group)));

			if (group.Servers.Count == 0)
				contextMenuStrip1.Items.Add(new ToolStripMenuItem("Delete Group", null, (s, e) => DeleteGroup(root, node, group)));
		}
		else if (node.Tag is Server server)
		{
			contextMenuStrip1.Items.Add(new ToolStripMenuItem("Add Peer", null, async (s, e) => await CreateNewPeerAsync(node, server)));
			
			if (server.Peers.Count == 0)
				contextMenuStrip1.Items.Add(new ToolStripMenuItem("Delete Server", null, (s, e) => DeleteServer(node, server)));
		}
		else if (node.Tag is Peer peer)
			contextMenuStrip1.Items.Add(new ToolStripMenuItem("Delete Peer", null, (s, e) => DeletePeer(node, peer)));

		this.contextMenuStrip1.Show(this.treeView1, location);
	}

	private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
	{
		if (this.ParentForm is not Form1 form)
			return;

		var panel = form.GetPanel();
		panel.Controls.Clear();

		if (e.Node?.Tag is Peer peer)
		{
			panel.Controls.Add(new UserControlPeer(peer) { Dock = DockStyle.Fill });
			return;
		}

		if (e.Node?.Tag is Server server)
		{
			panel.Controls.Add(new UserControlServer(server) { Dock = DockStyle.Fill });
			return;
		}
	}

	private void TreeView_MouseDown(object sender, MouseEventArgs e)
	{

		var node = treeView1.GetNodeAt(e.X, e.Y);

		this.treeView1.LabelEdit = node == this.treeView1.SelectedNode;

		this.treeView1.SelectedNode = node;

		if (e.Button == MouseButtons.Right)
			ShowContextMenu(e.Location);

	}

	private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(e.Label))
		{
			e.CancelEdit = true;
			return;
		}

		if (e.Node?.Tag is Group group)
			group.Name = e.Label;
		else if (e.Node?.Tag is Server server)
		{
			server.Name = e.Label;
			server.PostUp = string.Format(Settings.PostUp, server.Name);
		}
		else
			if (e.Node?.Tag is Peer peer)
			peer.Name = e.Label;
	}

	private void TreeView_DoubleClick(object sender, EventArgs e)
	{
		var treeNode = this.treeView1.SelectedNode;

		if (treeNode == null)
			return;

		if (treeNode.Tag is not Peer peer)
			return;


	}

	private void TreeView_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Delete)
			return;

		if (this.treeView1.SelectedNode is not TreeNode node)
			return;

		if (node.Tag is Group group && group.Servers.Count == 0)
			DeleteGroup(root, node, group);
		else if (node.Tag is Server server && server.Peers.Count == 0)
			DeleteServer(node, server);
		else if (node.Tag is Peer peer)
			DeletePeer(node, peer);
	}
}
