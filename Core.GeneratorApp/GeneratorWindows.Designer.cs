
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorWindows));
            this.工具栏 = new System.Windows.Forms.ToolStrip();
            this.toolsConnection = new System.Windows.Forms.ToolStripButton();
            this.工具栏.SuspendLayout();
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
            // GeneratorWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 638);
            this.Controls.Add(this.工具栏);
            this.Name = "GeneratorWindows";
            this.Text = "生成器窗口";
            this.工具栏.ResumeLayout(false);
            this.工具栏.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip 工具栏;
        private System.Windows.Forms.ToolStripButton toolsConnection;
    }
}

