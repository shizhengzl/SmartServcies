using Core.AppSystemServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.GeneratorApp
{
    public partial class Grant : Form
    {

        CompanyServices companyServices = new CompanyServices();
        UserServices userServices = new UserServices();
        public List<Companys> companys = new List<Companys>();

        public Grant()
        {
            InitializeComponent();
            LoadCompany();
             
        }

        public void LoadCompany() {
            companys = companyServices.GetCompanys();
            companys.ForEach(x=> {
                listcompanys.Items.Add(x.CompanyName);
            }) ; 
        }

        public void LoadTreeView(List<Menus> hasmenus,Companys company)
        {
            treegrangview.Nodes.Clear();
            var menus = userServices.GetGrantMenus(GeneratorWindows._currentUser.User, company);
            menus.Where(x => x.MenusId == Guid.Empty).ToList().ForEach(x => {
                TreeNode root = new TreeNode();
                root.Text = x.MenuName;
                root.Tag = x;

                root.Checked = hasmenus.ToList().Any(u => u.Id == x.Id);

                treegrangview.Nodes.Add(root);
                GetChildrenMenus(menus, x, root, hasmenus);
            });
            treegrangview.ExpandAll();
        }

        private void GetChildrenMenus(List<Menus> menus, Menus self,TreeNode treeNode, List<Menus> hasmenus)
        {
            menus.Where(p => p.MenusId == self.Id).ToList().ForEach(x=> {
                TreeNode root = new TreeNode();
                root.Text = x.MenuName;
                root.Tag = x;
                root.Checked = hasmenus.ToList().Any(u => u.Id == x.Id);
                treeNode.Nodes.Add(root); 
                GetChildrenMenus(menus, x, root, hasmenus);
            });
        }

        private void listcompanys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listcompanys.SelectedItem == null)
                return;
            var company = companys.Where(x => x.CompanyName == listcompanys.SelectedItem.ToString()).FirstOrDefault();
            // 获取单位菜单
            var menus = companyServices.GetCompanyMenus(company);

            LoadTreeView(menus, company);
        }
        /// <summary>
        /// 保存单位授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsavecompanygrant_Click(object sender, EventArgs e)
        {
            var company = companys.Where(x => x.CompanyName == listcompanys.SelectedItem.ToString()).FirstOrDefault();
            var menus = GetSelectedMenus();
            var response = companyServices.SaveCompanyMenus(menus, company);
            if (response) {
                MessageBox.Show("保存成功");
            }


            listcompanys_SelectedIndexChanged(null,null);
        } 

        private List<Menus> GetSelectedMenus()
        {
            List<Menus> menus = new List<Menus>();  
            for (int i = 0; i < treegrangview.Nodes.Count; i++)
            {
                var selectmenus = (Menus)treegrangview.Nodes[i].Tag;
                if (treegrangview.Nodes[i].Checked)
                {
                    menus.Add(selectmenus);
                    GetSelectedChildMenus(menus, treegrangview.Nodes[i]);
                }
              
            } 
            return menus;
        }

        private void GetSelectedChildMenus(List<Menus> menus,TreeNode node) {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                var selectmenus = (Menus)node.Nodes[i].Tag;
                if (node.Nodes[i].Checked) {
                    menus.Add(selectmenus);
                    GetSelectedChildMenus(menus, node.Nodes[i]);
                } 
            }
        }
    } 
}
