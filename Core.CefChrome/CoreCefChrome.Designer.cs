
namespace Core.CefChrome
{
    partial class CoreCefChrome
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
            this.ptop = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.BtnGetCookie = new System.Windows.Forms.Button();
            this.ptop.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptop
            // 
            this.ptop.Controls.Add(this.BtnGetCookie);
            this.ptop.Controls.Add(this.btnGo);
            this.ptop.Controls.Add(this.textBox1);
            this.ptop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptop.Location = new System.Drawing.Point(0, 0);
            this.ptop.Name = "ptop";
            this.ptop.Size = new System.Drawing.Size(1044, 67);
            this.ptop.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(941, 21);
            this.textBox1.TabIndex = 0;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(959, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // BtnGetCookie
            // 
            this.BtnGetCookie.Location = new System.Drawing.Point(878, 39);
            this.BtnGetCookie.Name = "BtnGetCookie";
            this.BtnGetCookie.Size = new System.Drawing.Size(75, 23);
            this.BtnGetCookie.TabIndex = 2;
            this.BtnGetCookie.Text = "GetCookie";
            this.BtnGetCookie.UseVisualStyleBackColor = true;
            this.BtnGetCookie.Click += new System.EventHandler(this.BtnGetCookie_Click);
            // 
            // CoreCefChrome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 774);
            this.Controls.Add(this.ptop);
            this.Name = "CoreCefChrome";
            this.Text = "CoreCefChrome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CoreCefChrome_FormClosing);
            this.ptop.ResumeLayout(false);
            this.ptop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ptop;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnGetCookie;
    }
}

