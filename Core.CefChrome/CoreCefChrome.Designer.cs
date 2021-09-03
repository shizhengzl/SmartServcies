
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
            this.components = new System.ComponentModel.Container();
            this.ptop = new System.Windows.Forms.Panel();
            this.btnInitUer = new System.Windows.Forms.Button();
            this.btnGetJson = new System.Windows.Forms.Button();
            this.BtnGetCookie = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtTargetUrl = new System.Windows.Forms.TextBox();
            this.panleft = new System.Windows.Forms.Panel();
            this.lblMode = new System.Windows.Forms.Label();
            this.commode = new System.Windows.Forms.ComboBox();
            this.txtJg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnstopserver = new System.Windows.Forms.Button();
            this.btnstartserver = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHe = new System.Windows.Forms.TextBox();
            this.lblxian = new System.Windows.Forms.Label();
            this.txtxian = new System.Windows.Forms.TextBox();
            this.lblzhuang = new System.Windows.Forms.Label();
            this.txtzhuang = new System.Windows.Forms.TextBox();
            this.timeserver = new System.Windows.Forms.Timer(this.components);
            this.txtmessage = new System.Windows.Forms.TextBox();
            this.ptop.SuspendLayout();
            this.panleft.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptop
            // 
            this.ptop.Controls.Add(this.btnInitUer);
            this.ptop.Controls.Add(this.btnGetJson);
            this.ptop.Controls.Add(this.BtnGetCookie);
            this.ptop.Controls.Add(this.btnGo);
            this.ptop.Controls.Add(this.txtTargetUrl);
            this.ptop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptop.Location = new System.Drawing.Point(0, 0);
            this.ptop.Name = "ptop";
            this.ptop.Size = new System.Drawing.Size(1187, 67);
            this.ptop.TabIndex = 0;
            // 
            // btnInitUer
            // 
            this.btnInitUer.Location = new System.Drawing.Point(719, 39);
            this.btnInitUer.Name = "btnInitUer";
            this.btnInitUer.Size = new System.Drawing.Size(75, 23);
            this.btnInitUer.TabIndex = 4;
            this.btnInitUer.Text = "Init";
            this.btnInitUer.UseVisualStyleBackColor = true;
            this.btnInitUer.Click += new System.EventHandler(this.btnInitUer_Click);
            // 
            // btnGetJson
            // 
            this.btnGetJson.Location = new System.Drawing.Point(878, 39);
            this.btnGetJson.Name = "btnGetJson";
            this.btnGetJson.Size = new System.Drawing.Size(75, 23);
            this.btnGetJson.TabIndex = 3;
            this.btnGetJson.Text = "GetJson";
            this.btnGetJson.UseVisualStyleBackColor = true;
            this.btnGetJson.Click += new System.EventHandler(this.btnGetJson_Click);
            // 
            // BtnGetCookie
            // 
            this.BtnGetCookie.Location = new System.Drawing.Point(800, 39);
            this.BtnGetCookie.Name = "BtnGetCookie";
            this.BtnGetCookie.Size = new System.Drawing.Size(75, 23);
            this.BtnGetCookie.TabIndex = 2;
            this.BtnGetCookie.Text = "GetCookie";
            this.BtnGetCookie.UseVisualStyleBackColor = true;
            this.BtnGetCookie.Click += new System.EventHandler(this.BtnGetCookie_Click);
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
            // txtTargetUrl
            // 
            this.txtTargetUrl.Location = new System.Drawing.Point(12, 12);
            this.txtTargetUrl.Name = "txtTargetUrl";
            this.txtTargetUrl.Size = new System.Drawing.Size(941, 21);
            this.txtTargetUrl.TabIndex = 0;
            this.txtTargetUrl.Text = "https://www.jeasyui.cn/document/index/index.html";
            // 
            // panleft
            // 
            this.panleft.Controls.Add(this.txtmessage);
            this.panleft.Controls.Add(this.lblMode);
            this.panleft.Controls.Add(this.commode);
            this.panleft.Controls.Add(this.txtJg);
            this.panleft.Controls.Add(this.label1);
            this.panleft.Controls.Add(this.btnstopserver);
            this.panleft.Controls.Add(this.btnstartserver);
            this.panleft.Controls.Add(this.button5);
            this.panleft.Controls.Add(this.button4);
            this.panleft.Controls.Add(this.button3);
            this.panleft.Controls.Add(this.button2);
            this.panleft.Controls.Add(this.button1);
            this.panleft.Controls.Add(this.label5);
            this.panleft.Controls.Add(this.txtTen);
            this.panleft.Controls.Add(this.label3);
            this.panleft.Controls.Add(this.txtOk);
            this.panleft.Controls.Add(this.label4);
            this.panleft.Controls.Add(this.txtHe);
            this.panleft.Controls.Add(this.lblxian);
            this.panleft.Controls.Add(this.txtxian);
            this.panleft.Controls.Add(this.lblzhuang);
            this.panleft.Controls.Add(this.txtzhuang);
            this.panleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panleft.Location = new System.Drawing.Point(0, 67);
            this.panleft.Name = "panleft";
            this.panleft.Size = new System.Drawing.Size(279, 729);
            this.panleft.TabIndex = 1;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(30, 411);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(29, 12);
            this.lblMode.TabIndex = 25;
            this.lblMode.Text = "Mode";
            // 
            // commode
            // 
            this.commode.FormattingEnabled = true;
            this.commode.Items.AddRange(new object[] {
            "Z",
            "X",
            "H",
            "Rondom"});
            this.commode.Location = new System.Drawing.Point(74, 403);
            this.commode.Name = "commode";
            this.commode.Size = new System.Drawing.Size(121, 20);
            this.commode.TabIndex = 24;
            this.commode.Text = "X";
            // 
            // txtJg
            // 
            this.txtJg.Location = new System.Drawing.Point(74, 366);
            this.txtJg.Name = "txtJg";
            this.txtJg.Size = new System.Drawing.Size(116, 21);
            this.txtJg.TabIndex = 23;
            this.txtJg.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "ITime";
            // 
            // btnstopserver
            // 
            this.btnstopserver.Location = new System.Drawing.Point(147, 453);
            this.btnstopserver.Name = "btnstopserver";
            this.btnstopserver.Size = new System.Drawing.Size(75, 23);
            this.btnstopserver.TabIndex = 21;
            this.btnstopserver.Text = "停止";
            this.btnstopserver.UseVisualStyleBackColor = true;
            this.btnstopserver.Click += new System.EventHandler(this.btnstopserver_Click);
            // 
            // btnstartserver
            // 
            this.btnstartserver.Location = new System.Drawing.Point(53, 453);
            this.btnstartserver.Name = "btnstartserver";
            this.btnstartserver.Size = new System.Drawing.Size(75, 23);
            this.btnstartserver.TabIndex = 20;
            this.btnstartserver.Text = "开启";
            this.btnstartserver.UseVisualStyleBackColor = true;
            this.btnstartserver.Click += new System.EventHandler(this.btnstartserver_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(78, 144);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 19;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(77, 115);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(77, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(78, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ten : F6";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(74, 323);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(116, 21);
            this.txtTen.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ok : F5";
            // 
            // txtOk
            // 
            this.txtOk.Location = new System.Drawing.Point(74, 285);
            this.txtOk.Name = "txtOk";
            this.txtOk.Size = new System.Drawing.Size(116, 21);
            this.txtOk.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "H : F4";
            // 
            // txtHe
            // 
            this.txtHe.Location = new System.Drawing.Point(74, 248);
            this.txtHe.Name = "txtHe";
            this.txtHe.Size = new System.Drawing.Size(116, 21);
            this.txtHe.TabIndex = 7;
            // 
            // lblxian
            // 
            this.lblxian.AutoSize = true;
            this.lblxian.Location = new System.Drawing.Point(12, 215);
            this.lblxian.Name = "lblxian";
            this.lblxian.Size = new System.Drawing.Size(41, 12);
            this.lblxian.TabIndex = 5;
            this.lblxian.Text = "X : F3";
            // 
            // txtxian
            // 
            this.txtxian.Location = new System.Drawing.Point(74, 210);
            this.txtxian.Name = "txtxian";
            this.txtxian.Size = new System.Drawing.Size(116, 21);
            this.txtxian.TabIndex = 4;
            // 
            // lblzhuang
            // 
            this.lblzhuang.AutoSize = true;
            this.lblzhuang.Location = new System.Drawing.Point(12, 178);
            this.lblzhuang.Name = "lblzhuang";
            this.lblzhuang.Size = new System.Drawing.Size(41, 12);
            this.lblzhuang.TabIndex = 2;
            this.lblzhuang.Text = "Z : F2";
            // 
            // txtzhuang
            // 
            this.txtzhuang.Location = new System.Drawing.Point(74, 173);
            this.txtzhuang.Name = "txtzhuang";
            this.txtzhuang.Size = new System.Drawing.Size(116, 21);
            this.txtzhuang.TabIndex = 1;
            // 
            // timeserver
            // 
            this.timeserver.Interval = 5000;
            this.timeserver.Tick += new System.EventHandler(this.timeserver_Tick);
            // 
            // txtmessage
            // 
            this.txtmessage.Location = new System.Drawing.Point(14, 500);
            this.txtmessage.Multiline = true;
            this.txtmessage.Name = "txtmessage";
            this.txtmessage.Size = new System.Drawing.Size(247, 199);
            this.txtmessage.TabIndex = 26;
            // 
            // CoreCefChrome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 796);
            this.Controls.Add(this.panleft);
            this.Controls.Add(this.ptop);
            this.KeyPreview = true;
            this.Name = "CoreCefChrome";
            this.Text = "CoreCefChrome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CoreCefChrome_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoreCefChrome_KeyDown);
            this.ptop.ResumeLayout(false);
            this.ptop.PerformLayout();
            this.panleft.ResumeLayout(false);
            this.panleft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ptop;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtTargetUrl;
        private System.Windows.Forms.Button BtnGetCookie;
        private System.Windows.Forms.Button btnGetJson;
        private System.Windows.Forms.Button btnInitUer;
        private System.Windows.Forms.Panel panleft;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHe;
        private System.Windows.Forms.Label lblxian;
        private System.Windows.Forms.TextBox txtxian;
        private System.Windows.Forms.Label lblzhuang;
        private System.Windows.Forms.TextBox txtzhuang;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnstopserver;
        private System.Windows.Forms.Button btnstartserver;
        private System.Windows.Forms.Timer timeserver;
        private System.Windows.Forms.TextBox txtJg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox commode;
        private System.Windows.Forms.TextBox txtmessage;
    }
}

