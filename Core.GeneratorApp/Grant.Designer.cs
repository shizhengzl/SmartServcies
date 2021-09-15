
namespace Core.GeneratorApp
{
    partial class Grant
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
            this.tabgrant = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treegrangview = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsavecompanygrant = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolssearchcompany = new System.Windows.Forms.ToolStripTextBox();
            this.listcompanys = new System.Windows.Forms.ListBox();
            this.tabgrant.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabgrant
            // 
            this.tabgrant.Controls.Add(this.tabPage1);
            this.tabgrant.Controls.Add(this.tabPage2);
            this.tabgrant.Controls.Add(this.tabPage3);
            this.tabgrant.Controls.Add(this.tabPage4);
            this.tabgrant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabgrant.Location = new System.Drawing.Point(0, 0);
            this.tabgrant.Name = "tabgrant";
            this.tabgrant.SelectedIndex = 0;
            this.tabgrant.Size = new System.Drawing.Size(1035, 530);
            this.tabgrant.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1027, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "单位授权";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1027, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "角色授权";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1027, 504);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "组织机构授权";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1027, 504);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "用户授权";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.treegrangview);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(257, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(767, 498);
            this.panel2.TabIndex = 1;
            // 
            // treegrangview
            // 
            this.treegrangview.CheckBoxes = true;
            this.treegrangview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treegrangview.Location = new System.Drawing.Point(0, 0);
            this.treegrangview.Name = "treegrangview";
            this.treegrangview.Size = new System.Drawing.Size(767, 498);
            this.treegrangview.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnsavecompanygrant);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 433);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(767, 65);
            this.panel3.TabIndex = 1;
            // 
            // btnsavecompanygrant
            // 
            this.btnsavecompanygrant.Location = new System.Drawing.Point(673, 23);
            this.btnsavecompanygrant.Name = "btnsavecompanygrant";
            this.btnsavecompanygrant.Size = new System.Drawing.Size(75, 23);
            this.btnsavecompanygrant.TabIndex = 0;
            this.btnsavecompanygrant.Text = "保存";
            this.btnsavecompanygrant.UseVisualStyleBackColor = true;
            this.btnsavecompanygrant.Click += new System.EventHandler(this.btnsavecompanygrant_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listcompanys);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 498);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolssearchcompany});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(254, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolssearchcompany
            // 
            this.toolssearchcompany.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolssearchcompany.Name = "toolssearchcompany";
            this.toolssearchcompany.Size = new System.Drawing.Size(180, 25);
            // 
            // listcompanys
            // 
            this.listcompanys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listcompanys.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listcompanys.FormattingEnabled = true;
            this.listcompanys.ItemHeight = 16;
            this.listcompanys.Location = new System.Drawing.Point(0, 25);
            this.listcompanys.Name = "listcompanys";
            this.listcompanys.Size = new System.Drawing.Size(254, 473);
            this.listcompanys.TabIndex = 2;
            this.listcompanys.SelectedIndexChanged += new System.EventHandler(this.listcompanys_SelectedIndexChanged);
            // 
            // Grant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 530);
            this.Controls.Add(this.tabgrant);
            this.Name = "Grant";
            this.Text = "Grant";
            this.tabgrant.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabgrant;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treegrangview;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnsavecompanygrant;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolssearchcompany;
        private System.Windows.Forms.ListBox listcompanys;
    }
}