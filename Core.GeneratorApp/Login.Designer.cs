
namespace Core.GeneratorApp
{
    partial class Login
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
            this.registertable = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.linkcompanyregister = new System.Windows.Forms.LinkLabel();
            this.linkregister = new System.Windows.Forms.LinkLabel();
            this.btncanel = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtregemail = new System.Windows.Forms.TextBox();
            this.labregemail = new System.Windows.Forms.Label();
            this.btnregister = new System.Windows.Forms.Button();
            this.txtregconfirmpassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnregistercanel = new System.Windows.Forms.Button();
            this.txtregpassword = new System.Windows.Forms.TextBox();
            this.txtregusername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtcomsimplename = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcompanyname = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btncomregister = new System.Windows.Forms.Button();
            this.txtcomconfirmpassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btncompanycanel = new System.Windows.Forms.Button();
            this.txtcompassword = new System.Windows.Forms.TextBox();
            this.txtcomusername = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.registertable.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // registertable
            // 
            this.registertable.Controls.Add(this.tabPage1);
            this.registertable.Controls.Add(this.tabPage2);
            this.registertable.Controls.Add(this.tabPage3);
            this.registertable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registertable.Location = new System.Drawing.Point(0, 0);
            this.registertable.Name = "registertable";
            this.registertable.SelectedIndex = 0;
            this.registertable.Size = new System.Drawing.Size(572, 395);
            this.registertable.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.linkcompanyregister);
            this.tabPage1.Controls.Add(this.linkregister);
            this.tabPage1.Controls.Add(this.btncanel);
            this.tabPage1.Controls.Add(this.btnlogin);
            this.tabPage1.Controls.Add(this.txtpassword);
            this.tabPage1.Controls.Add(this.txtUsername);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(564, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "登录";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // linkcompanyregister
            // 
            this.linkcompanyregister.AutoSize = true;
            this.linkcompanyregister.Location = new System.Drawing.Point(366, 217);
            this.linkcompanyregister.Name = "linkcompanyregister";
            this.linkcompanyregister.Size = new System.Drawing.Size(53, 12);
            this.linkcompanyregister.TabIndex = 13;
            this.linkcompanyregister.TabStop = true;
            this.linkcompanyregister.Text = "单位注册";
            this.linkcompanyregister.Click += new System.EventHandler(this.linkcompanyregister_Click);
            // 
            // linkregister
            // 
            this.linkregister.AutoSize = true;
            this.linkregister.Location = new System.Drawing.Point(290, 217);
            this.linkregister.Name = "linkregister";
            this.linkregister.Size = new System.Drawing.Size(53, 12);
            this.linkregister.TabIndex = 12;
            this.linkregister.TabStop = true;
            this.linkregister.Text = "个人注册";
            this.linkregister.Click += new System.EventHandler(this.linkregister_Click);
            // 
            // btncanel
            // 
            this.btncanel.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btncanel.Location = new System.Drawing.Point(232, 246);
            this.btncanel.Name = "btncanel";
            this.btncanel.Size = new System.Drawing.Size(73, 31);
            this.btncanel.TabIndex = 11;
            this.btncanel.Text = "取消";
            this.btncanel.UseVisualStyleBackColor = true;
            this.btncanel.Click += new System.EventHandler(this.btncanel_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnlogin.Location = new System.Drawing.Point(348, 246);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(75, 31);
            this.btnlogin.TabIndex = 3;
            this.btnlogin.Text = "确认";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpassword.Location = new System.Drawing.Point(221, 176);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(200, 29);
            this.txtpassword.TabIndex = 2;
            this.txtpassword.Text = "admin";
            this.txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassword_KeyPress);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUsername.Location = new System.Drawing.Point(221, 108);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 29);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "admin";
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(152, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(133, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtregemail);
            this.tabPage2.Controls.Add(this.labregemail);
            this.tabPage2.Controls.Add(this.btnregister);
            this.tabPage2.Controls.Add(this.txtregconfirmpassword);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnregistercanel);
            this.tabPage2.Controls.Add(this.txtregpassword);
            this.tabPage2.Controls.Add(this.txtregusername);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(564, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "注册";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtregemail
            // 
            this.txtregemail.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtregemail.Location = new System.Drawing.Point(222, 127);
            this.txtregemail.Name = "txtregemail";
            this.txtregemail.Size = new System.Drawing.Size(200, 29);
            this.txtregemail.TabIndex = 101;
            // 
            // labregemail
            // 
            this.labregemail.AutoSize = true;
            this.labregemail.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labregemail.Location = new System.Drawing.Point(150, 132);
            this.labregemail.Name = "labregemail";
            this.labregemail.Size = new System.Drawing.Size(66, 19);
            this.labregemail.TabIndex = 21;
            this.labregemail.Text = "邮箱：";
            // 
            // btnregister
            // 
            this.btnregister.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnregister.Location = new System.Drawing.Point(347, 275);
            this.btnregister.Name = "btnregister";
            this.btnregister.Size = new System.Drawing.Size(75, 30);
            this.btnregister.TabIndex = 104;
            this.btnregister.Text = "注册";
            this.btnregister.UseVisualStyleBackColor = true;
            this.btnregister.Click += new System.EventHandler(this.btnregister_Click);
            // 
            // txtregconfirmpassword
            // 
            this.txtregconfirmpassword.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtregconfirmpassword.Location = new System.Drawing.Point(222, 219);
            this.txtregconfirmpassword.Name = "txtregconfirmpassword";
            this.txtregconfirmpassword.PasswordChar = '*';
            this.txtregconfirmpassword.Size = new System.Drawing.Size(200, 29);
            this.txtregconfirmpassword.TabIndex = 103;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(112, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "确认密码：";
            // 
            // btnregistercanel
            // 
            this.btnregistercanel.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnregistercanel.Location = new System.Drawing.Point(234, 275);
            this.btnregistercanel.Name = "btnregistercanel";
            this.btnregistercanel.Size = new System.Drawing.Size(75, 30);
            this.btnregistercanel.TabIndex = 17;
            this.btnregistercanel.Text = "取消";
            this.btnregistercanel.UseVisualStyleBackColor = true;
            this.btnregistercanel.Click += new System.EventHandler(this.btnregistercanel_Click);
            // 
            // txtregpassword
            // 
            this.txtregpassword.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtregpassword.Location = new System.Drawing.Point(222, 173);
            this.txtregpassword.Name = "txtregpassword";
            this.txtregpassword.PasswordChar = '*';
            this.txtregpassword.Size = new System.Drawing.Size(200, 29);
            this.txtregpassword.TabIndex = 102;
            // 
            // txtregusername
            // 
            this.txtregusername.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtregusername.Location = new System.Drawing.Point(222, 78);
            this.txtregusername.Name = "txtregusername";
            this.txtregusername.Size = new System.Drawing.Size(200, 29);
            this.txtregusername.TabIndex = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(150, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(131, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "用户名：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtcomsimplename);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.txtcompanyname);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.btncomregister);
            this.tabPage3.Controls.Add(this.txtcomconfirmpassword);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.btncompanycanel);
            this.tabPage3.Controls.Add(this.txtcompassword);
            this.tabPage3.Controls.Add(this.txtcomusername);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(564, 369);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "单位注册";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtcomsimplename
            // 
            this.txtcomsimplename.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcomsimplename.Location = new System.Drawing.Point(221, 242);
            this.txtcomsimplename.Name = "txtcomsimplename";
            this.txtcomsimplename.Size = new System.Drawing.Size(200, 29);
            this.txtcomsimplename.TabIndex = 204;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(115, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 19);
            this.label8.TabIndex = 35;
            this.label8.Text = "单位简称：";
            // 
            // txtcompanyname
            // 
            this.txtcompanyname.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcompanyname.Location = new System.Drawing.Point(221, 194);
            this.txtcompanyname.Name = "txtcompanyname";
            this.txtcompanyname.Size = new System.Drawing.Size(200, 29);
            this.txtcompanyname.TabIndex = 203;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(114, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 19);
            this.label9.TabIndex = 33;
            this.label9.Text = "单位名称：";
            // 
            // btncomregister
            // 
            this.btncomregister.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btncomregister.Location = new System.Drawing.Point(347, 295);
            this.btncomregister.Name = "btncomregister";
            this.btncomregister.Size = new System.Drawing.Size(75, 30);
            this.btncomregister.TabIndex = 205;
            this.btncomregister.Text = "注册";
            this.btncomregister.UseVisualStyleBackColor = true;
            // 
            // txtcomconfirmpassword
            // 
            this.txtcomconfirmpassword.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcomconfirmpassword.Location = new System.Drawing.Point(222, 145);
            this.txtcomconfirmpassword.Name = "txtcomconfirmpassword";
            this.txtcomconfirmpassword.PasswordChar = '*';
            this.txtcomconfirmpassword.Size = new System.Drawing.Size(200, 29);
            this.txtcomconfirmpassword.TabIndex = 202;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(115, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 19);
            this.label10.TabIndex = 30;
            this.label10.Text = "确认密码：";
            // 
            // btncompanycanel
            // 
            this.btncompanycanel.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btncompanycanel.Location = new System.Drawing.Point(222, 295);
            this.btncompanycanel.Name = "btncompanycanel";
            this.btncompanycanel.Size = new System.Drawing.Size(75, 30);
            this.btncompanycanel.TabIndex = 29;
            this.btncompanycanel.Text = "取消";
            this.btncompanycanel.UseVisualStyleBackColor = true;
            this.btncompanycanel.Click += new System.EventHandler(this.btncompanycanel_Click);
            // 
            // txtcompassword
            // 
            this.txtcompassword.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcompassword.Location = new System.Drawing.Point(222, 95);
            this.txtcompassword.Name = "txtcompassword";
            this.txtcompassword.PasswordChar = '*';
            this.txtcompassword.Size = new System.Drawing.Size(200, 29);
            this.txtcompassword.TabIndex = 201;
            // 
            // txtcomusername
            // 
            this.txtcomusername.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcomusername.Location = new System.Drawing.Point(222, 45);
            this.txtcomusername.Name = "txtcomusername";
            this.txtcomusername.Size = new System.Drawing.Size(200, 29);
            this.txtcomusername.TabIndex = 200;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(153, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 19);
            this.label11.TabIndex = 26;
            this.label11.Text = "密码：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(134, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 19);
            this.label12.TabIndex = 25;
            this.label12.Text = "用户名：";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 395);
            this.Controls.Add(this.registertable);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.registertable.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl registertable;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btncanel;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnregistercanel;
        private System.Windows.Forms.TextBox txtregpassword;
        private System.Windows.Forms.TextBox txtregusername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnregister;
        private System.Windows.Forms.TextBox txtregconfirmpassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkcompanyregister;
        private System.Windows.Forms.LinkLabel linkregister;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtcomsimplename;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtcompanyname;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btncomregister;
        private System.Windows.Forms.TextBox txtcomconfirmpassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btncompanycanel;
        private System.Windows.Forms.TextBox txtcompassword;
        private System.Windows.Forms.TextBox txtcomusername;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtregemail;
        private System.Windows.Forms.Label labregemail;
    }
}