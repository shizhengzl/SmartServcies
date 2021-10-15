using Core.AppSystemServices;
using Core.DataBaseServices;
using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.UsuallyCommon;
using System.Reflection;
using Core.SnippetServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;
using System.Xml.Linq;

namespace Core.GeneratorApp
{
    public partial class GeneratorWindows : Form
    {
        public Form self { get; set; }
        public static CurrentSesscion _currentUser { get; set;  }

        public bool colsed { get; set; }

        public GeneratorWindows()
        {
            Login winlogin = new Login();
            winlogin.ShowDialog();
             
            if (winlogin.DialogResult == DialogResult.Cancel)
            {
                colsed = true;
                return;
            }
            //_currentUser = currentUse;
            InitializeComponent();
            LoadTree();
            
            self = this;
        }
        public FreeSqlFactory factory = new FreeSqlFactory();
        private void toolsConnection_Click(object sender, EventArgs e)
        {
            //BaseList<Menus> baseForm= new BaseList<Menus>();
            //baseForm.ShowDialog();

            //ConnectionStringManage  connectionStringManage= new ConnectionStringManage();
            //connectionStringManage.DataBaseType = DataBaseType.SqlServer;
            //connectionStringManage.Address = "local";
            //connectionStringManage.UserIds = "sa";
            //connectionStringManage.Password = "sasa";
            //connectionStringManage.IsWindows = false;

            //factory.FreeSql.Insert<ConnectionStringManage>(connectionStringManage).ExecuteAffrows();
        }

        public void LoadTree()
        {
            var allmenus = _currentUser.UserMenus;// factory.FreeSql.Select<Menus>().ToList();
            var menus = allmenus.Where(x => x.MenusId == Guid.Empty).ToList();
            menus.ForEach(x => {
                TreeNode root = new TreeNode();
                root.Text = x.MenuName; 
                root.Tag = x;
                treemenu.Nodes.Add(root);

                GetChild(x, root, allmenus);
            }); 
        }

        public void GetChild(Menus menus,TreeNode node, List<Menus> allmenus) {
            var search = allmenus.Where(x => x.MenusId == menus.Id).ToList();
            search.ForEach(x => {
                TreeNode child = new TreeNode();
                child.Text = x.MenuName;
                child.Tag = x;
                node.Nodes.Add(child);

                GetChild(x,child,allmenus);

            });
        }

        private void treemenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode trNode = treemenu.SelectedNode;
            Menus menus = (Menus)trNode.Tag;
            if (menus.Component.IsNullOrEmpty() || menus.Component.ToStringExtension().GetClassType().IsNull())
                return;
             

            if (!menus.IsAuto.ToBoolean())
            {


                Type classType = Type.GetType("Core.GeneratorApp." + menus.Component); 
                var instance = Activator.CreateInstance(classType);

                Form form =(Form)instance; 
                form.TopLevel = false;     //设置为非顶级控件

                TabPage tabgrant = new TabPage();
                tabgrant.Text = menus.MenuName;
                tabgrant.Name = menus.Component.ToStringExtension();
                tabgrant.Controls.Add(form);
                form.Dock = DockStyle.Fill;
                    //让窗体form显示出来 
                form.FormBorderStyle = FormBorderStyle.None;  //外边框干掉
                form.WindowState = FormWindowState.Maximized;
                

                if (!tabControls.TabPages.ContainsKey(menus.Component.ToStringExtension()))
                    tabControls.TabPages.Add(tabgrant);
                tabControls.SelectTab(menus.Component.ToStringExtension());

                form.Show();
            }
            else
            {
                // 初始化dll
                SnippetRecord snippetRecord = new SnippetRecord();
                ConnectionStringManage connectionStringManage= new ConnectionStringManage();    
                Type classType = Type.GetType("Core.GeneratorApp.BaseList`1");
                Type constructedType = classType.MakeGenericType(menus.Component.ToStringExtension().GetClassType());
                var instance = Activator.CreateInstance(constructedType, new object[] {menus.IsSupper.ToBoolean().ToString().ToUpper() });
                var from = ((Panel)instance); 
                from.Dock = DockStyle.Fill;
                TabPage tabpage = new TabPage();
                var name = menus.Component.ToStringExtension().GetClassType().Name;
                tabpage.Text = name;
                tabpage.Name = name;

                tabpage.Controls.Add(from);
                from.Tag = this.imagelistall;
                if (!tabControls.TabPages.ContainsKey(name))
                    tabControls.TabPages.Add(tabpage);
                tabControls.SelectTab(name);
            }
        }
    }
}
