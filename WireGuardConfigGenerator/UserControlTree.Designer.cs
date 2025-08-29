namespace WireGuardConfigGenerator
{
	partial class UserControlTree
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			treeView1 = new TreeView();
			contextMenuStrip1 = new ContextMenuStrip(components);
			SuspendLayout();
			// 
			// treeView1
			// 
			treeView1.ContextMenuStrip = contextMenuStrip1;
			treeView1.Dock = DockStyle.Fill;
			treeView1.LabelEdit = true;
			treeView1.Location = new Point(0, 0);
			treeView1.Name = "treeView1";
			treeView1.Size = new Size(138, 130);
			treeView1.TabIndex = 0;
			treeView1.AfterLabelEdit += TreeView_AfterLabelEdit;
			treeView1.AfterSelect += TreeView_AfterSelect;
			treeView1.DoubleClick += TreeView_DoubleClick;
			treeView1.KeyDown += TreeView_KeyDown;
			treeView1.MouseDown += TreeView_MouseDown;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(61, 4);
			// 
			// UserControlTree
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(treeView1);
			Name = "UserControlTree";
			Size = new Size(138, 130);
			Load += UserControlTree_Load;
			ResumeLayout(false);
		}

		#endregion

		private TreeView treeView1;
		private ContextMenuStrip contextMenuStrip1;
	}
}
