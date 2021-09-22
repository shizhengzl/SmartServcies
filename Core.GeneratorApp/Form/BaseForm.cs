using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.AppSystemServices;
using Core.DataBaseServices;
using Core.FreeSqlServices;
using Core.SnippetServices;
using Core.UsuallyCommon;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using FreeSql;

namespace Core.GeneratorApp
{
    public class BaseForm<T> : Form where T : BaseCompany, new() 
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
            this.Width = 520;
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            this.Controls.Add(panel);

            toolStrip.Dock = DockStyle.Top;
            Int32 startIndexX = 20;
            Int32 startIndexY = 20;
            typeof(T).GetProperties().ToList().ForEach(x => {
                if (x.Name != "CompanysId") { 
                var s = Nullable.GetUnderlyingType(x.PropertyType) ?? x.PropertyType;
                var ptype = s.Name;
                Label label = new Label();
                label.Text = x.GetPropertyDescription();
                label.Location = new Point(startIndexX, startIndexY);
                label.Width = 100;
                dynamic textBox = new TextBox();

                if (x.PropertyType.IsEnum)
                {
                    textBox = new ComboBox();
                    var listenum = x.Name.GetTypeByName().GetListEnumClass();
                    textBox.DataSource = listenum;
                    textBox.ValueMember = "Kyes";
                    textBox.DisplayMember = "Name";

                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    textBox.Name = x.Name;
                    startIndexY += 50;
                    panel.Controls.Add(label);
                    panel.Controls.Add(textBox);
                    var item = new EnumClass();
                    x.PropertyType.GetListEnumClass().ForEach(p => {
                        if (p.Name == t.GetPropertyValue(x.Name))
                        {
                            item = p;
                        }
                    });
                    textBox.Width = 300;
                }
                if (ptype == typeof(Boolean).Name)
                {
                    textBox = new System.Windows.Forms.CheckBox();
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    textBox.Name = x.Name;
                    textBox.Width = 300;
                    panel.Controls.Add(label);
                    panel.Controls.Add(textBox);
                    startIndexY += 20;
                }
                if (ptype == typeof(string).Name || ptype == typeof(Int64).Name || ptype == typeof(Int32).Name)
                {
                    textBox = new TextBox();
                    var slength = x.GetPropertyDescription<FreeSql.DataAnnotations.ColumnAttribute>("StringLength").ToInt32();
                    if (slength == -1 || slength > 500)
                    {
                        textBox = new RichTextBox(); 
                     }
                  
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    textBox.Name = x.Name;
                    textBox.Width = 300;
                    panel.Controls.Add(label);
                    panel.Controls.Add(textBox);
                    startIndexY += (slength == -1 || slength > 500) ? 80 :30;

                }
                // 说明是联动
                if (ptype == typeof(Guid).Name && x.Name.EndsWith("sId"))
                {
                    textBox = new ComboBox();
                    textBox.Width = 300;
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    panel.Controls.Add(label);
                    panel.Controls.Add(textBox);
                    Type type = (x.Name.Replace("sId", string.Empty) + "s").GetClassType();
                    var list = factory.FreeSql.Select<object>().AsType(type).ToList();

                    dynamic newdefault = System.Activator.CreateInstance(type);
                    newdefault.Id = Guid.Empty;
                    newdefault.Name = "默认";
                    list.Insert(0, newdefault);
                    textBox.DataSource = list;
                    textBox.Name = x.Name;
                    textBox.ValueMember = "Id";
                    textBox.DisplayMember = "Name";
            
                    startIndexY += 20;
                }
                if (!x.PropertyType.IsEnum
                && (ptype != typeof(Guid).Name || ptype == typeof(Guid).Name && x.Name.EndsWith("sId"))
                && ptype != typeof(DateTime).Name)
                {
                    panel.Controls.Add(label);
                    panel.Controls.Add(textBox);
                    startIndexY += 20;
                }
                }
            });

            this.Height = startIndexY + 150;

            Button btnSave = new Button();
            btnSave.Text = "保存";
            btnSave.Click += BtnSave_Click;
            btnSave.Location = new Point(this.Width - 250, startIndexY + 60);

            Button btnCanel = new Button();
            btnCanel.Text = "取消";
            btnCanel.Click += BtnCanel_Click;
            btnCanel.Location = new Point(this.Width - 150, startIndexY + 60);

            panel.Controls.Add(btnSave);
            panel.Controls.Add(btnCanel);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public BaseForm(T _t)
        {
            InitializeComponent();
            this.t = _t;
            IsEdit = !t.GetPropertyValue("Id").IsNullOrEmpty();

            this.Width = 520;  
            Panel panel= new Panel();
            panel.Dock = DockStyle.Fill;
            this.Controls.Add(panel);

            toolStrip.Dock = DockStyle.Top;
            Int32 startIndexX = 20;
            Int32 startIndexY = 20; 
            typeof(T).GetProperties().ToList().ForEach(x=> {
                if (x.Name != "CompanysId")
                {
                    var s = Nullable.GetUnderlyingType(x.PropertyType) ?? x.PropertyType;
                    var ptype = s.Name;
                    Label label = new Label();
                    label.Text = x.GetPropertyDescription();
                    label.Location = new Point(startIndexX, startIndexY);
                    label.Width = 100;
                    dynamic textBox = new TextBox();

                    if (x.PropertyType.IsEnum)
                    {
                        textBox = new ComboBox();
                        var listenum = x.Name.GetTypeByName().GetListEnumClass();
                        textBox.DataSource = listenum;
                        textBox.ValueMember = "Kyes";
                        textBox.DisplayMember = "Name";

                        textBox.Location = new Point(startIndexX + 150, startIndexY);
                        textBox.Name = x.Name;
                        startIndexY += 50;
                        panel.Controls.Add(label);
                        panel.Controls.Add(textBox);
                        var item = new EnumClass();
                        x.PropertyType.GetListEnumClass().ForEach(p =>
                        {
                            if (p.Name == t.GetPropertyValue(x.Name))
                            {
                                item = p;
                            }
                        });
                        textBox.Width = 300;
                        textBox.SelectedText = item.Name;
                        textBox.SelectedItem = item;
                        textBox.SelectedValue = item.Keys;
                        textBox.Text = item.Name;

                    }
                    if (ptype == typeof(Boolean).Name)
                    {
                        textBox = new System.Windows.Forms.CheckBox();
                        textBox.Location = new Point(startIndexX + 150, startIndexY);
                        textBox.Name = x.Name;
                        textBox.Width = 300;
                        panel.Controls.Add(label);
                        panel.Controls.Add(textBox);
                        startIndexY += 20;
                    }
                    if (ptype == typeof(string).Name || ptype == typeof(Int64).Name || ptype == typeof(Int32).Name)
                    {
                        textBox = new TextBox();
                        var slength = x.GetPropertyDescription<FreeSql.DataAnnotations.ColumnAttribute>("StringLength").ToInt32();
                        if (slength == -1 || slength > 500)
                        {
                            textBox = new RichTextBox();
                        }
                        textBox.Location = new Point(startIndexX + 150, startIndexY);
                        textBox.Name = x.Name;
                        textBox.Text = t.GetPropertyValue(x.Name);
                        textBox.Width = 300;
                        panel.Controls.Add(label);
                        panel.Controls.Add(textBox);

                        startIndexY += 30;

                    }
                    // 说明是联动
                    if (ptype == typeof(Guid).Name && x.Name.EndsWith("sId"))
                    {
                        textBox = new ComboBox();
                        textBox.Width = 300;
                        textBox.Location = new Point(startIndexX + 150, startIndexY);
                        panel.Controls.Add(label);
                        panel.Controls.Add(textBox);
                        Type type = (x.Name.Replace("sId", string.Empty) + "s").GetClassType();
                        var list = factory.FreeSql.Select<object>().AsType(type).ToList();

                        dynamic newdefault = System.Activator.CreateInstance(type);
                        newdefault.Id = Guid.Empty;
                        newdefault.Name = "默认";
                        list.Insert(0, newdefault);
                        textBox.DataSource = list;
                        textBox.Name = x.Name;
                        textBox.ValueMember = "Id";
                        textBox.DisplayMember = "Name";

                        var item = list.Where(p => p.GetPropertyValue("Id") == t.GetPropertyValue(x.Name)).FirstOrDefault();
                        if (item == null)
                        {
                            textBox.SelectedIndex = 0;
                        }
                        else
                        {
                            textBox.SelectedValue = item.GetPropertyValue("Id");
                            textBox.Text = item.GetPropertyValue("Name").ToString();
                            textBox.SelectedItem = item;
                        }

                        startIndexY += 20;
                    }
                    if (!x.PropertyType.IsEnum
                    && (ptype != typeof(Guid).Name || ptype == typeof(Guid).Name && x.Name.EndsWith("sId"))
                    && ptype != typeof(DateTime).Name)
                    {
                        panel.Controls.Add(label);
                        panel.Controls.Add(textBox);
                        startIndexY += 20;
                    }
                }
            }) ;

            this.Height = startIndexY + 150;

            Button btnSave = new Button();
            btnSave.Text = "保存";
            btnSave.Click += BtnSave_Click;
            btnSave.Location = new Point(this.Width - 250, startIndexY + 60) ;

            Button btnCanel = new Button();
            btnCanel.Text = "取消";
            btnCanel.Click += BtnCanel_Click;
            btnCanel.Location = new Point(this.Width - 150, startIndexY + 60);

            panel.Controls.Add(btnSave);
            panel.Controls.Add(btnCanel); 
            this.StartPosition = FormStartPosition.CenterScreen;
         
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
                            var slength = x.GetPropertyDescription<FreeSql.DataAnnotations.ColumnAttribute>("StringLength").ToInt32();
                            if (slength == -1 || slength > 500)
                            {
                                var textBox = (RichTextBox)control;
                                string value = textBox.Text.Trim();
                                t.SetPropertyValue(x.Name, value);
                            }
                            else
                            {
                                var textBox = (TextBox)control;
                                string value = textBox.Text.Trim();
                                t.SetPropertyValue(x.Name, value);
                            }
                          
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
            t.CompanysId = GeneratorWindows._currentUser.CurrentUser.CompanysId;
            if (!IsEdit)
            {
                if (t.GetPropertyList().Any(x => x == "PassWord"))
                {
                    t.SetPropertyValue("PassWord", t.GetPropertyValue("PassWord").ToString().Tomd5());
                }
                factory.FreeSql.Insert<T>(t).ExecuteAffrows();
            } 
            else
            { 
                factory.FreeSql.Update<T>().SetSource(t).ExecuteAffrows();
            }
               

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
