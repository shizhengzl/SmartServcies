using Core.AppSystemServices;
using Core.DataBaseServices.DataBaseEntitys;
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
namespace Core.GeneratorApp
{
    public partial class GeneratorWindows : Form
    {
        public Form self { get; set; }
        public CurrentUsers _currentUser { get; set;  }
        public GeneratorWindows(CurrentUsers currentUse)
        {
            _currentUser = currentUse;
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
                root.Text = x.Name; 
                root.Tag = x;
                treemenu.Nodes.Add(root);

                GetChild(x, root, allmenus);
            }); 
        }

        public void GetChild(Menus menus,TreeNode node, List<Menus> allmenus) {
            var search = allmenus.Where(x => x.MenusId == menus.Id).ToList();
            search.ForEach(x => {
                TreeNode child = new TreeNode();
                child.Text = x.Name;
                child.Tag = x;
                node.Nodes.Add(child);

                GetChild(x,child,allmenus);

            });
        }

        private void treemenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode trNode = treemenu.SelectedNode;
            Menus menus = (Menus)trNode.Tag;
            if (menus.Url.IsNullOrEmpty() || menus.Url.ToStringExtension().GetClassType().IsNull())
                return;

            // 初始化dll
            SnippetRecord snippetRecord = new SnippetRecord(); 
            Type classType = Type.GetType("Core.GeneratorApp.BaseList`1"); 
            Type constructedType = classType.MakeGenericType(menus.Url.ToStringExtension().GetClassType());
            var instance = Activator.CreateInstance(constructedType);


            var from = ((Panel)instance); 
            
         
            from.Dock = DockStyle.Fill;
            TabPage tabpage = new TabPage();
            var name = menus.Url.ToStringExtension().GetClassType().Name;
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
