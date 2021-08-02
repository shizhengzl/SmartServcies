using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.DataBaseServices.DataBaseEntitys;
using Core.FreeSql;
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
        private ToolStrip toolslist;
        private StatusStrip statusStrips;
        private Panel panellist;
        private DataGridView dataGridView1;
        public FreeSqlFactory factory = new FreeSqlFactory();

        public BaseForm()
        {
            this.Width = 500;
            this.Height = 400;

            Panel panel= new Panel();
            panel.Dock = DockStyle.Fill;
          

            toolStrip.Dock = DockStyle.Top;
            Int32 startIndexX = 20;
            Int32 startIndexY = 20;
            typeof(T).GetProperties().ToList().ForEach(x=> { 
                Label label= new Label();
                label.Text = x.GetPropertyDescription(); 
                label.Location = new Point(startIndexX, startIndexY); 
                var ptype = x.PropertyType.Name;

                dynamic textBox = new TextBox();
                
                if (x.PropertyType.IsEnum) {
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
                if (ptype == typeof(string).Name)
                {
                    textBox = new TextBox();
                    textBox.Width = 200;
                    textBox.Location = new Point(startIndexX + 150, startIndexY);
                    textBox.Name = x.Name;
                    //TextBox box = new TextBox();
                }

                panel.Controls.Add(label);
                panel.Controls.Add(textBox);

                startIndexY += 50;
            }) ;

            Button btnSave = new Button();
            btnSave.Text = "保存";
            btnSave.Click += BtnSave_Click;
            btnSave.Location = new Point(this.Width - 200, startIndexY) ;

            Button btnCanel = new Button();
            btnCanel.Text = "取消";
            btnCanel.Click += BtnCanel_Click;
            btnCanel.Location = new Point(this.Width - 100, startIndexY);

            this.Controls.Add(btnSave);
            this.Controls.Add(btnCanel);
            this.Controls.Add(panel);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnCanel_Click(object sender, EventArgs e)
        { 

            T t = new T();
            typeof(T).GetProperties().ToList().ForEach(x => {

                foreach (Control control in this.Controls)
                {
                    if (control.Name == x.Name)
                    {
                        if (x.PropertyType.IsEnum)
                        {
                            ComboBox combo = (ComboBox)control;
                            int value = (int)combo.SelectedValue;
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
                    } 
                }
            });
            factory.FreeSql.Insert<T>(t).ExecuteAffrows();
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolslist = new System.Windows.Forms.ToolStrip();
            this.statusStrips = new System.Windows.Forms.StatusStrip();
            this.panellist = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panellist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolslist
            // 
            this.toolslist.Location = new System.Drawing.Point(0, 0);
            this.toolslist.Name = "toolslist";
            this.toolslist.Size = new System.Drawing.Size(689, 25);
            this.toolslist.TabIndex = 0;
            this.toolslist.Text = "菜单栏";
            // 
            // statusStrips
            // 
            this.statusStrips.Location = new System.Drawing.Point(0, 420);
            this.statusStrips.Name = "statusStrips";
            this.statusStrips.Size = new System.Drawing.Size(689, 22);
            this.statusStrips.TabIndex = 1;
            this.statusStrips.Text = "状态栏";
            // 
            // panellist
            // 
            this.panellist.Controls.Add(this.dataGridView1);
            this.panellist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panellist.Location = new System.Drawing.Point(0, 25);
            this.panellist.Name = "panellist";
            this.panellist.Size = new System.Drawing.Size(689, 395);
            this.panellist.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(689, 395);
            this.dataGridView1.TabIndex = 0;
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(689, 442);
            this.Controls.Add(this.panellist);
            this.Controls.Add(this.statusStrips);
            this.Controls.Add(this.toolslist);
            this.Name = "BaseForm";
            this.panellist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
