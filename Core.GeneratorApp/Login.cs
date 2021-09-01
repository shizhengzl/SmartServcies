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
            initDataBase.Init();
            InitializeComponent();
        }

        private void btncanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnregistercanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncompanycanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkregister_Click(object sender, EventArgs e)
        {
            registertable.SelectedIndex = 1;
        }

        private void linkcompanyregister_Click(object sender, EventArgs e)
        {
            registertable.SelectedIndex = 2;
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            var username = txtregusername.Text.Trim();
            var password = txtregpassword.Text.Trim();
            var passwordconfirm = txtregconfirmpassword.Text.Trim();
            var email = txtregemail.Text.Trim();
            if (username.IsNull())
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (password.IsNull())
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            if (email.IsNull())
            {
                MessageBox.Show("邮箱不能为空");
                return;
            }
            if (!password.Equals(passwordconfirm))
            {
                MessageBox.Show("密码和确认密码不一致");
                return;
            }

            // 检查用户名是否存在
            if (factory.FreeSql.Select<Users>().Any(x => x.UserName == username))
            {
                MessageBox.Show("用户名已经存在");
                return;
            }

            // 检查邮箱否存在
            if (factory.FreeSql.Select<Users>().Any(x => x.Email == email))
            {
                MessageBox.Show("邮箱已经存在");
                return;
            }

            Users users = new Users() {
                UserName = username,
                Email = email,
                PassWord = password.Tomd5(),
                Id = Guid.NewGuid()
            };

          

            if (factory.FreeSql.Insert<Users>(users).ExecuteAffrows() > 0)
            {
                GeneratorWindows windows = new GeneratorWindows(null);
                windows.ShowDialog();
                this.Close();
            }
            else {
                MessageBox.Show("注册失败");
                return;
            }
               
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtpassword.Text.Trim();
            //if (username.IsNull())
            //{
            //    MessageBox.Show("用户名不能为空");
            //    return;
            //}
            //if (password.IsNull())
            //{
            //    MessageBox.Show("密码不能为空");
            //    return;
            //}

            //// 检查邮箱否存在
            //if (!factory.FreeSql.Select<Users>().Any(x => x.UserName == username ||
            // x.Email == username || x.Phone == username
            //))
            //{
            //    MessageBox.Show("用户名不存在");
            //    return;
            //}

            //password = password.Tomd5();
            //// 检查邮箱否存在
            //if (!factory.FreeSql.Select<Users>().Any(x => (x.UserName == username ||
            // x.Email == username || x.Phone == username) && x.PassWord == password
            //))
            //{
            //    MessageBox.Show("用户名不存在");
            //    return;
            //}
            Users users = new Users() { UserName = username, PassWord = password.Tomd5() };
            var response = userservices.Login(users);

            if (!response.Success)
            { 
                MessageBox.Show(response.Message);
                return;
            } 
            GeneratorWindows windows = new GeneratorWindows(response.Data);
            windows.ShowDialog();
            this.Close();
        }
    }
}
