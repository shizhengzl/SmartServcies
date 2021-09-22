
namespace Core.GeneratorApp
{
    partial class GeneratorWindows
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorWindows));
            this.工具栏 = new System.Windows.Forms.ToolStrip();
            this.toolsConnection = new System.Windows.Forms.ToolStripButton();
            this.pantree = new System.Windows.Forms.Panel();
            this.treemenu = new System.Windows.Forms.TreeView();
            this.paneltab = new System.Windows.Forms.Panel();
            this.tabControls = new System.Windows.Forms.TabControl();
            this.imagelistall = new System.Windows.Forms.ImageList(this.components);
            this.工具栏.SuspendLayout();
            this.pantree.SuspendLayout();
            this.paneltab.SuspendLayout();
            this.SuspendLayout();
            // 
            // 工具栏
            // 
            this.工具栏.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsConnection});
            this.工具栏.Location = new System.Drawing.Point(0, 0);
            this.工具栏.Name = "工具栏";
            this.工具栏.Size = new System.Drawing.Size(1461, 25);
            this.工具栏.TabIndex = 0;
            this.工具栏.Text = "toolsbar";
            // 
            // toolsConnection
            // 
            this.toolsConnection.Image = ((System.Drawing.Image)(resources.GetObject("toolsConnection.Image")));
            this.toolsConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsConnection.Name = "toolsConnection";
            this.toolsConnection.Size = new System.Drawing.Size(76, 22);
            this.toolsConnection.Text = "连接管理";
            this.toolsConnection.Click += new System.EventHandler(this.toolsConnection_Click);
            // 
            // pantree
            // 
            this.pantree.Controls.Add(this.treemenu);
            this.pantree.Dock = System.Windows.Forms.DockStyle.Left;
            this.pantree.Location = new System.Drawing.Point(0, 25);
            this.pantree.Name = "pantree";
            this.pantree.Size = new System.Drawing.Size(267, 613);
            this.pantree.TabIndex = 1;
            // 
            // treemenu
            // 
            this.treemenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treemenu.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treemenu.Location = new System.Drawing.Point(0, 0);
            this.treemenu.Name = "treemenu";
            this.treemenu.Size = new System.Drawing.Size(267, 613);
            this.treemenu.TabIndex = 0;
            this.treemenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treemenu_NodeMouseDoubleClick);
            // 
            // paneltab
            // 
            this.paneltab.Controls.Add(this.tabControls);
            this.paneltab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneltab.Location = new System.Drawing.Point(267, 25);
            this.paneltab.Name = "paneltab";
            this.paneltab.Size = new System.Drawing.Size(1194, 613);
            this.paneltab.TabIndex = 2;
            // 
            // tabControls
            // 
            this.tabControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControls.Location = new System.Drawing.Point(0, 0);
            this.tabControls.Name = "tabControls";
            this.tabControls.SelectedIndex = 0;
            this.tabControls.Size = new System.Drawing.Size(1194, 613);
            this.tabControls.TabIndex = 0;
            // 
            // imagelistall
            // 
            this.imagelistall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelistall.ImageStream")));
            this.imagelistall.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelistall.Images.SetKeyName(0, "connection.png");
            this.imagelistall.Images.SetKeyName(1, "create.png");
            this.imagelistall.Images.SetKeyName(2, "modify.png");
            this.imagelistall.Images.SetKeyName(3, "remove.png");
            // 
            // GeneratorWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 638);
            this.Controls.Add(this.paneltab);
            this.Controls.Add(this.pantree);
            this.Controls.Add(this.工具栏);
            this.Name = "GeneratorWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成器窗口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.工具栏.ResumeLayout(false);
            this.工具栏.PerformLayout();
            this.pantree.ResumeLayout(false);
            this.paneltab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip 工具栏;
        private System.Windows.Forms.ToolStripButton toolsConnection;
        private System.Windows.Forms.Panel pantree;
        private System.Windows.Forms.TreeView treemenu;
        private System.Windows.Forms.Panel paneltab;
        private System.Windows.Forms.TabControl tabControls;
        public System.Windows.Forms.ImageList imagelistall;
    }
}

