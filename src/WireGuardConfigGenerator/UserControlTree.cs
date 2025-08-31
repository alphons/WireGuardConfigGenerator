using System.Text.Json;
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

	public async Task LoadAsync(string path, string password)
	{
		if (this.ParentForm is Form1 form)
			form.FormClosing += async (s, e) => await root.SaveAsync(path, password);

		await TreeHelpers.LoadTreeAsync(this.treeView1, root, path, password);
	}


	private void ShowContextMenu(Point location)
	{
		this.contextMenuStrip1.Items.Clear();

		if (this.treeView1.SelectedNode is not TreeNode node)
		{
			contextMenuStrip1.Items.Add(new ToolStripMenuItem("Add Group", null, (s, e) => TreeHelpers.CreateNewGroup(this.treeView1, root)));
		}
		else if (node.Tag is Group group)
		{
			contextMenuStrip1.Items.Add(new ToolStripMenuItem("Add Server", null, async (s, e) => await TreeHelpers.CreateNewServerAsync(this.treeView1, root, Settings, node, group)));

			if (group.Servers.Count == 0)
				contextMenuStrip1.Items.Add(new ToolStripMenuItem("Delete Group", null, (s, e) => TreeHelpers.DeleteGroup(root, node, group)));
		}
		else if (node.Tag is Server server)
		{
			contextMenuStrip1.Items.Add(new ToolStripMenuItem("Add Peer", null, async (s, e) => await TreeHelpers.CreateNewPeerAsync(this.treeView1, Settings, node, server)));

			if (server.Peers.Count == 0)
				contextMenuStrip1.Items.Add(new ToolStripMenuItem("Delete Server", null, (s, e) => TreeHelpers.DeleteServer(node, server)));
		}
		else if (node.Tag is Peer peer)
			contextMenuStrip1.Items.Add(new ToolStripMenuItem("Delete Peer", null, (s, e) => TreeHelpers.DeletePeer(node, peer)));

		this.contextMenuStrip1.Show(this.treeView1, location);
	}

	private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
	{
		ShowInformation(e.Node);
	}

	private void ShowInformation(TreeNode? node)
	{
		if (this.ParentForm is not Form1 form)
			return;

		var panel = form.GetPanel();

		panel.Controls.Clear();

		if (node?.Tag is Peer peer)
			panel.Controls.Add(new UserControlPeer(peer) { Dock = DockStyle.Fill });
		else if (node?.Tag is Server server)
			panel.Controls.Add(new UserControlServer(server) { Dock = DockStyle.Fill });
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
		{
			group.Name = e.Label;
		}
		else if (e.Node?.Tag is Server server)
		{
			server.Name = e.Label;
			server.PostUp = string.Format(Settings.PostUp, server.Name);
			ShowInformation(e.Node);
		}
		else if (e.Node?.Tag is Peer peer)
		{
			peer.Name = e.Label;
			ShowInformation(e.Node);
		}
	}

	private void TreeView_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode != Keys.Delete)
			return;

		if (this.treeView1.SelectedNode is not TreeNode node)
			return;

		if (node.Tag is Group group && group.Servers.Count == 0)
			TreeHelpers.DeleteGroup(root, node, group);
		else if (node.Tag is Server server && server.Peers.Count == 0)
			TreeHelpers.DeleteServer(node, server);
		else if (node.Tag is Peer peer)
			TreeHelpers.DeletePeer(node, peer);
	}
}
