using WireGuardConfigGenerator.DataModel;

namespace WireGuardConfigGenerator.Helpers;

public static class TreeHelpers
{
	public async static Task LoadTreeAsync(TreeView treeView, Root root, string path, string password)
	{
		await root.LoadAsync(path, password);

		treeView.Nodes.Clear();
		foreach (var group in root.Groups)
		{
			var groupNode = new TreeNode(group.Name) { Tag = group };
			treeView.Nodes.Add(groupNode);
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
		treeView.ExpandAll();
	}

	public static DialogResult DeleteIt() =>
		MessageBox.Show("Delete", "Delete this item", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


	public static string GetSubnet(string? ipAddress) =>
		ipAddress == null ? "10.0.0" : ipAddress[..ipAddress.LastIndexOf('.')];


	public static void DeleteGroup(Root root, TreeNode node, Group group)
	{
		if (DeleteIt() == DialogResult.OK)
		{
			root.Groups.Remove(group);
			node.Remove();
		}
	}

	public static void DeleteServer(TreeNode node, Server server)
	{
		if (DeleteIt() == DialogResult.OK)
		{
			server.ParentGroup?.Servers.Remove(server);
			node.Remove();
		}
	}

	public static void DeletePeer(TreeNode node, Peer peer)
	{
		if (DeleteIt() == DialogResult.OK)
		{
			peer.ParentServer?.Peers.Remove(peer);
			node.Remove();
		}
	}

	public static void CreateNewGroup(TreeView treeView, Root root)
	{
		Group newGroup = new() { Name = "New Group" };
		root.Groups.Add(newGroup);
		var treeNode = new TreeNode(newGroup.Name) { Tag = newGroup };
		treeView.Nodes.Add(treeNode);
		treeView.SelectedNode = treeNode;
	}

	public static async Task CreateNewServerAsync(TreeView treeView, Root root, AppSettings settings, TreeNode node, Group group)
	{
		string privateKey = await WireGuard.ExecuteAsync("wg genkey");
		string publicKey = await WireGuard.ExecuteAsync($"echo {privateKey} | wg pubkey");

		var offset = group.Servers.Count + 1;
		var name = $"Server {offset}";
		Server server = new()
		{
			Name = name,
			ParentGroup = group,
			ListenPort = settings.ListenPort + (group.Servers.Count * 100) - ((root.Groups.Count - 1) * 1000),
			Address = settings.Address,
			Endpoint = settings.Endpoint,
			PostUp = string.Format(settings.PostUp, name),
			PrivateKey = privateKey,
			PubKey = publicKey
		};

		group.Servers.Add(server);
		var treeNode = new TreeNode(server.Name) { Tag = server };
		node.Nodes.Add(treeNode);
		node.Expand();
		treeView.SelectedNode = treeNode;
	}

	public static async Task CreateNewPeerAsync(TreeView treeView, AppSettings settings, TreeNode node, Server server)
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
			PersistentKeepalive = settings.PersistentKeepalive,
			PrivateKey = privateKey,
			PubKey = publicKey
		};
		server.Peers.Add(newPeer);
		var treeNode = new TreeNode(newPeer.Name) { Tag = newPeer };
		node.Nodes.Add(treeNode);
		node.Expand();
		treeView.SelectedNode = treeNode;
	}
}
