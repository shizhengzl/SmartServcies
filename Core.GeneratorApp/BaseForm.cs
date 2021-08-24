using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.AppSystemServices;
using Core.DataBaseServices.DataBaseEntitys;
using Core.FreeSqlServices;
using Core.SnippetServices;
using Core.UsuallyCommon;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Core.GeneratorApp
{
    public class BaseForm<T> : Form where T : class, new() 
    { 
        /// <summary>
        /// 默认工具栏
        /// </summary>
        public ToolStrip toolStrip = new ToolStrip();
        public FreeSqlFactory factory = new FreeSqlFactory();

        public Boolean IsEdit = false;
        public T t { get; set; }
        public BaseForm()
        {
            InitializeComponent();
            t = new T();
            this.Width = 500;
            this.Height = 400;

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;


            toolStrip.Dock = DockStyle.Top;
            Int32 startIndexX = 20;
            Int32 startIndexY = 20;
            typeof(T).GetProperties().ToList().ForEach(x => {
                var s = Nullable.GetUnderlyingType(x.PropertyType) ?? x.PropertyType;
                var ptype = s.Name;


                Label label = new Label();
                label.Text = x.GetPropertyDescription();
                label.Location = new Point(startIndexX, startIndexY);


                dynamic textBox = new TextBox();

                if (x.PropertyType.IsEnum)
                {
                    var listenum = x.Name.GetTypeByName().GetListEnumClass();
                    textBox = new ComboBox();
                    textBox.DataSource = listenum;
                    textBox.ValueMember = "Kyes";
                    textBox.DisplayMember = "Name";
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    textBox.Name = x.Name;
                }

                if (ptype == typeof(Boolean).Name)
                {
                    textBox = new System.Windows.Forms.CheckBox();
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    textBox.Name = x.Name;
                }
                if (ptype == typeof(string).Name || ptype == typeof(Int64).Name || ptype == typeof(Int32).Name)
                {
                    textBox = new TextBox();
                    textBox.Width = 200;
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    textBox.Name = x.Name; 
                    //TextBox box = new TextBox();
                }
                // 说明是联动
                if (ptype == typeof(Guid).Name && x.Name.EndsWith("sId"))
                {
                    textBox = new ComboBox();
                    textBox.Name = x.Name;
                    textBox.Width = 200;
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    Type type =( x.Name.Replace("sId", string.Empty) + "s").GetClassType();
                    var list = factory.FreeSql.Select<object>().AsType(type).ToList();
                     textBox.Name = x.Name;
                    textBox.ValueMember = "Id";
                    textBox.DisplayMember = "Name";
                    textBox.DataSource = list;
                     
                }
                if ((ptype != typeof(Guid).Name || ptype == typeof(Guid).Name && x.Name.EndsWith("sId")) && ptype != typeof(DateTime).Name)
                {
                    panel.Controls.Add(label);
                    panel.Controls.Add(textBox);
                    startIndexY += 50;
                }

            });

            Button btnSave = new Button();
            btnSave.Text = "保存";
            btnSave.Click += BtnSave_Click;
            btnSave.Location = new Point(this.Width - 200, startIndexY);

            Button btnCanel = new Button();
            btnCanel.Text = "取消";
            btnCanel.Click += BtnCanel_Click;
            btnCanel.Location = new Point(this.Width - 100, startIndexY);

            panel.Controls.Add(btnSave);
            panel.Controls.Add(btnCanel);
            this.Controls.Add(panel);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public BaseForm(T _t)
        {
            InitializeComponent();
            this.t = _t;
            IsEdit = !t.GetPropertyValue("Id").IsNullOrEmpty();

            this.Width = 500;
            this.Height = 400;

            Panel panel= new Panel();
            panel.Dock = DockStyle.Fill;
          

            toolStrip.Dock = DockStyle.Top;
            Int32 startIndexX = 20;
            Int32 startIndexY = 20;
            ComboBox stextBox = new ComboBox();
            typeof(T).GetProperties().ToList().ForEach(x=> {
                var s = Nullable.GetUnderlyingType(x.PropertyType) ?? x.PropertyType;
                var ptype = s.Name;
               

                Label label= new Label();
                label.Text = x.GetPropertyDescription(); 
                label.Location = new Point(startIndexX, startIndexY); 
             

                dynamic textBox = new TextBox();
              
                if (x.PropertyType.IsEnum) {
                    var listenum = x.Name.GetTypeByName().GetListEnumClass();
                
                    stextBox.DataSource = listenum;
                    stextBox.ValueMember = "Kyes";
                    stextBox.DisplayMember = "Name";
                    stextBox.Location = new Point(startIndexX + 150, startIndexY);
                    stextBox.Name = x.Name;

                    var item = new EnumClass();
                    x.PropertyType.GetListEnumClass().ForEach(p => {
                        if (p.Name == t.GetPropertyValue(x.Name)) {
                            item = p;
                        } 
                    });

                    //var s = new ComboBox()
                    stextBox.SelectedText = item.Name;
               
                    stextBox.SelectedItem = item;
                    stextBox.SelectedValue = item.Keys;
                    stextBox.Text = item.Name;

                    panel.Controls.Add(label);
                    panel.Controls.Add(stextBox);
                    startIndexY += 50;
                }
               
                if (ptype == typeof(Boolean).Name)
                {
                    textBox = new System.Windows.Forms.CheckBox(); 
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    textBox.Name = x.Name;
                }
                if (ptype == typeof(string).Name || ptype == typeof(Int64).Name || ptype == typeof(Int32).Name)
                {
                    textBox = new TextBox();
                    textBox.Width = 200;
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    textBox.Name = x.Name;
                    textBox.Text = t.GetPropertyValue(x.Name);
                    //TextBox box = new TextBox();
                }
                // 说明是联动
                if (ptype == typeof(Guid).Name && x.Name.EndsWith("sId")) {
                    textBox = new ComboBox();
                    textBox.Width = 200;
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    Type type = (x.Name.Replace("sId", string.Empty) + "s").GetClassType();
                    var list = factory.FreeSql.Select<object>().AsType(type).ToList();
                    textBox.DataSource = list;
                    textBox.Name = x.Name;
                    textBox.ValueMember = "Id";
                    textBox.DisplayMember = "Name";
                }
                if (!x.PropertyType.IsEnum 
                && (ptype != typeof(Guid).Name || ptype == typeof(Guid).Name && x.Name.EndsWith("sId"))
                && ptype != typeof(DateTime).Name)
                {
                    panel.Controls.Add(label);
                    panel.Controls.Add(textBox); 
                    startIndexY += 50;
                } 
                
            }) ;

            Button btnSave = new Button();
            btnSave.Text = "保存";
            btnSave.Click += BtnSave_Click;
            btnSave.Location = new Point(this.Width - 200, startIndexY) ;

            Button btnCanel = new Button();
            btnCanel.Text = "取消";
            btnCanel.Click += BtnCanel_Click;
            btnCanel.Location = new Point(this.Width - 100, startIndexY);

            panel.Controls.Add(btnSave);
            panel.Controls.Add(btnCanel);
            this.Controls.Add(panel);
            this.StartPosition = FormStartPosition.CenterScreen;

            stextBox.SelectedText = LanguageType.jscript.ToString();
        }

        private void BtnCanel_Click(object sender, EventArgs e)
        { 

            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        { 
            typeof(T).GetProperties().ToList().ForEach(x => {

                foreach (Control control in this.Controls[0].Controls)
                {
                    if (control.Name == x.Name)
                    {
                        if (x.PropertyType.IsEnum)
                        {
                            ComboBox combo = (ComboBox)control;
                            int value = (int)(combo.SelectedValue as EnumClass).Keys;
                            t.SetPropertyValue(x.Name, value);
                        }
                        if (x.PropertyType.Name == typeof(Boolean).Name)
                        {
                            System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)control;
                            bool value = checkBox.Checked;
                            t.SetPropertyValue(x.Name, value);
                        }
                        if (x.PropertyType.Name == typeof(string).Name)
                        {
                            TextBox textBox = (TextBox)control;
                            string value = textBox.Text.Trim();
                            t.SetPropertyValue(x.Name, value);
                        }
                        if (x.PropertyType.Name == typeof(Guid).Name && x.Name.EndsWith("sId"))
                        {
                            ComboBox textBox = (ComboBox)control;
                            string value = textBox.SelectedValue.ToStringExtension().Trim();
                            t.SetPropertyValue(x.Name, value);
                        }
                    }
                }
            });
            if(!IsEdit)
                factory.FreeSql.Insert<T>(t).ExecuteAffrows();
            else
                factory.FreeSql.Update<T>().SetSource(t).ExecuteAffrows();

            if ("Resovele" + typeof(T).Name == "ResoveleSnippetRecord")
                ResoveleSnippetRecord(t);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(689, 442);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }


        private void ResoveleSnippetRecord(object t) {
            var response = (SnippetRecord)t; 
   
            StringBuilder snippet = new StringBuilder();
            snippet.AppendLine("<CodeSnippet Format=\"1.1.0\" xmlns=\"http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet\">");
            snippet.AppendLine("<Header>");
            snippet.AppendLine("<Title>" + response.Title + "</Title>"); 
            snippet.AppendLine("<Author>"+ response.Author +"</Author>");
            snippet.AppendLine("<Shortcut>" + response.Shortcut + "</Shortcut>");
            snippet.AppendLine("<Description>" + response.Description + "</Description>");
            snippet.AppendLine("<SnippetTypes>");
            snippet.AppendLine("<SnippetType>Expansion</SnippetType>");
            snippet.AppendLine("<SnippetType>SurroundsWith</SnippetType>"); 
            snippet.AppendLine("</SnippetTypes>");
            snippet.AppendLine("</Header>");
            snippet.AppendLine("<Snippet>");
            snippet.AppendLine("<Code Language=\"jscript\"><![CDATA["+response.Code.Replace("$","$$")+"]]></Code>");
            snippet.AppendLine("</Snippet>");
            snippet.AppendLine("</CodeSnippet>");
            var path = string.Empty;
            switch (response.LanguageType)
            {
                case LanguageType.VB:
                    break;
                case LanguageType.csharp:
                    path = @"C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC#\Snippets\2052\Visual C#\" ;
                    break;
                case LanguageType.CPP:
                    break;
                case LanguageType.XAML:
                    break;
                case LanguageType.XML:
                    break;
                case LanguageType.jscript:
                    path = @"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Web\Snippets\JScript\2052\JScript\";
                    break;
                case LanguageType.TypeScript:
                    break;
                case LanguageType.SQL:
                    break;
                case LanguageType.html:
                    path = @"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Web\Snippets\HTML\2052\HTML\";
                    break;
                default:
                    break;
            }
            if (!path.IsNullOrEmpty())
                (path + response.Title + ".snippet").WriteFile(snippet.ToString());
        }
    }
}
