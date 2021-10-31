using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.AppSystemServices; 
using Core.FreeSqlServices;
using Core.UsuallyCommon;

namespace Core.GeneratorApp
{
    public partial class Login : Form
    {

        public FreeSqlFactory factory = new FreeSqlFactory();
        UserServices userservices = new UserServices();
        public Login()
        {
            InitDataBase initDataBase = new InitDataBase(); 
            InitializeComponent();
        }

        private void btncanel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnregistercanel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btncompanycanel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void linkregister_Click(object sender, EventArgs e)
        {
            registertable.SelectedIndex = 1;
        }

        private void linkcompanyregister_Click(object sender, EventArgs e)
        {
            registertable.SelectedIndex = 2;
        }

        private void btncomregister_Click(object sender, EventArgs e)
        {
            var username = txtregusername.Text.Trim();
            var password = txtregpassword.Text.Trim();
            var passwordconfirm = txtregconfirmpassword.Text.Trim();
            var companyname = txtcompanyname.Text.Trim();

            if (!password.Equals(passwordconfirm))
            {
                MessageBox.Show("密码和确认密码不一致");
                return;
            }
            Users users = new Users()
            {
                UserName = username,
                PassWord = password.Tomd5(),
                Id = Guid.NewGuid()
            };

            var response = userservices.RegisterUser(users);

            if (!response.Success)
            {
                MessageBox.Show(response.Message);
                return;
            }
            GeneratorWindows._currentUser = response.Data;
            this.DialogResult = DialogResult.OK;
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            var username = txtregusername.Text.Trim();
            var password = txtregpassword.Text.Trim();
            var passwordconfirm = txtregconfirmpassword.Text.Trim();
 
            if (!password.Equals(passwordconfirm))
            {
                MessageBox.Show("密码和确认密码不一致");
                return;
            }  
            Users users = new Users() {
                UserName = username,
                PassWord = password.Tomd5(),
                Id = Guid.NewGuid()
            };

            var response = userservices.RegisterUser(users);

            if (!response.Success)
            {
                MessageBox.Show(response.Message);
                return;
            }
            GeneratorWindows._currentUser = response.Data;
            this.DialogResult = DialogResult.OK;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtpassword.Text.Trim(); 
            Users users = new Users() { UserName = username, PassWord = password.Tomd5() };
            var response = userservices.Login(users); 
            if (!response.Success)
            { 
                MessageBox.Show(response.Message);
                return;
            }  
            GeneratorWindows._currentUser = response.Data; 
            this.DialogResult = DialogResult.OK;
        }

       

        #region 文本框焦点事件 
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                txtpassword.Focus();
            }
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnlogin.Focus();
            }
        }

        private void txtregusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtregpassword.Focus();
            }
        }

        private void txtregpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtregconfirmpassword.Focus();
            }
        }

        private void txtregconfirmpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnregister.Focus();
            }
        }

        private void txtcomusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcompassword.Focus();
            }
        }

        private void txtcompassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcomconfirmpassword.Focus();
            }
        }

        private void txtcomconfirmpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcompanyname.Focus();
            }
        }

        private void txtcompanyname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btncomregister.Focus();
            }
        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.SelectAll();
            txtUsername.Focus();
        }
    }
}
