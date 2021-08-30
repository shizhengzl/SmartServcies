
using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.UsuallyCommon;
namespace Core.GeneratorApp
{
    /// <summary>
    /// 列表展示
    /// </summary>
    public class BaseList<T> : Panel where T : class, new()
    {
        private ToolStripButton toolcreate;
        private ToolStripButton toolmodify;
        private ToolStripButton toolremove;
        private ToolStripTextBox toolsearch;
        private Panel panellist;
        private StatusStrip statusmessage;
        private DataGridView listview;
        private ToolStrip toollist; 
        public FreeSqlFactory factory = new FreeSqlFactory();

        public Panel self { get; set; }
        public BaseList()
        {
            self = this;
            InitializeComponent();
            this.listview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.listview.MultiSelect = false;
            LoadList(); 

             
        }

        public void LoadList()
        { 
             
            var list = factory.FreeSql.Select<T>().Where(x=> 1==1).ToList();
            listview.DataSource = list;
            listview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            listview.ReadOnly = true;
            listview.DataBindingComplete += Listview_DataBindingComplete;
            listview.CellDoubleClick += Listview_CellDoubleClick;
        }

        private void Listview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var sources = (List<T>)listview.DataSource;
            T t = new T();
            foreach (DataGridViewRow item in listview.SelectedRows)
            {
                var key = ((T)sources[item.Index]).GetPropertyValue("Id");
                t = factory.FreeSql.Select<T>(key).First();
            }

            BaseForm<T> baseForm = new BaseForm<T>(t);
            var response = baseForm.ShowDialog();
            if (response == DialogResult.OK)
            {
                this.LoadList();
            }
        }

        private void Listview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < listview.Columns.Count; i++)
            {
                var description = typeof(T).GetProperty(listview.Columns[i].Name).GetPropertyDescription();
                listview.Columns[i].HeaderText = description;
            }
        }

        private void InitializeComponent()
        {
            this.toollist = new System.Windows.Forms.ToolStrip();
            this.toolcreate = new System.Windows.Forms.ToolStripButton();
            this.toolmodify = new System.Windows.Forms.ToolStripButton();
            this.toolremove = new System.Windows.Forms.ToolStripButton();
            this.toolsearch = new System.Windows.Forms.ToolStripTextBox();
            this.panellist = new System.Windows.Forms.Panel();
            this.statusmessage = new System.Windows.Forms.StatusStrip();
            this.listview = new System.Windows.Forms.DataGridView();
            this.toollist.SuspendLayout();
            this.panellist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listview)).BeginInit();
            this.SuspendLayout();
            // 
            // toollist
            // 
            this.toollist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolcreate,
            this.toolmodify,
            this.toolremove,
            this.toolsearch});
            this.toollist.Location = new System.Drawing.Point(0, 0);
            this.toollist.Name = "toollist";
            this.toollist.Size = new System.Drawing.Size(1091, 25);
            this.toollist.TabIndex = 0;
            this.toollist.Text = "toolStrip1";
            // 
            // toolcreate
            // 
            this.toolcreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolcreate.Name = "toolcreate";
            this.toolcreate.Size = new System.Drawing.Size(36, 22);
            this.toolcreate.Text = "新增";
            this.toolcreate.Click += new System.EventHandler(this.toolcreate_Click);
            // 
            // toolmodify
            // 
            this.toolmodify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolmodify.Name = "toolmodify";
            this.toolmodify.Size = new System.Drawing.Size(36, 22);
            this.toolmodify.Text = "编辑";
            this.toolmodify.Click += new System.EventHandler(this.toolmodify_Click);
            // 
            // toolremove
            // 
            this.toolremove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolremove.Name = "toolremove";
            this.toolremove.Size = new System.Drawing.Size(36, 22);
            this.toolremove.Text = "删除";
            this.toolremove.Click += new System.EventHandler(this.toolremove_Click);
            // 
            // toolsearch
            // 
            this.toolsearch.Name = "toolsearch";
            this.toolsearch.Size = new System.Drawing.Size(100, 25);
            // 
            // panellist
            // 
            this.panellist.Controls.Add(this.statusmessage);
            this.panellist.Controls.Add(this.listview);
            this.panellist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panellist.Location = new System.Drawing.Point(0, 25);
            this.panellist.Name = "panellist";
            this.panellist.Size = new System.Drawing.Size(1091, 626);
            this.panellist.TabIndex = 1;
            // 
            // statusmessage
            // 
            this.statusmessage.Location = new System.Drawing.Point(0, 604);
            this.statusmessage.Name = "statusmessage";
            this.statusmessage.Size = new System.Drawing.Size(1091, 22);
            this.statusmessage.TabIndex = 1;
            this.statusmessage.Text = "statusStrip1";
            // 
            // listview
            // 
            this.listview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listview.Location = new System.Drawing.Point(0, 0);
            this.listview.Name = "listview";
            this.listview.RowTemplate.Height = 23;
            this.listview.Size = new System.Drawing.Size(1091, 626);
            this.listview.TabIndex = 0;
            // 
            // BaseList
            // 
            this.Controls.Add(this.panellist);
            this.Controls.Add(this.toollist);
            this.Size = new System.Drawing.Size(1091, 651);
            this.Resize += new System.EventHandler(this.BaseList_Resize);
            this.toollist.ResumeLayout(false);
            this.toollist.PerformLayout();
            this.panellist.ResumeLayout(false);
            this.panellist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void toolcreate_Click(object sender, EventArgs e)
        {
            BaseForm<T> baseForm = new BaseForm<T>();
            var response = baseForm.ShowDialog();
            if (response == DialogResult.OK) 
            {
                this.LoadList();
            }
        }

        private void toolmodify_Click(object sender, EventArgs e)
        {

            var sources = (List<T>) listview.DataSource;
            T t = new T();
            foreach (DataGridViewRow item in listview.SelectedRows)
            {
                var key = ((T)sources[item.Index]).GetPropertyValue("Id");
                t = factory.FreeSql.Select<T>(key).First();
            }

            BaseForm<T> baseForm = new BaseForm<T>(t);
            var response = baseForm.ShowDialog();
            if (response == DialogResult.OK)
            {
                this.LoadList();
            }
        }

        private void toolremove_Click(object sender, EventArgs e)
        {
            var sources = (List<Core.AppSystemServices.Menus>)listview.DataSource;
            foreach (DataGridViewRow item in listview.SelectedRows)
            {
                var key = sources[item.Index].Id;
                var response = factory.FreeSql.Delete<T>(key).ExecuteAffrows();
                this.LoadList();
            }

        }

        private void BaseList_Resize(object sender, EventArgs e)
        {
            ImageList imglist = ((self.Tag as ImageList));

            this.toollist.ImageList = imglist;
            this.toolcreate.ImageIndex = 1;
            this.toolmodify.ImageIndex = 2;
            this.toolremove.ImageIndex = 3;

        }
    }
}
