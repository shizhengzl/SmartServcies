using Core.DataBaseServices.DataBaseEntitys;
using Core.FreeSql;
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
    public partial class GeneratorWindows : Form
    {
        public GeneratorWindows()
        {
            InitializeComponent();
        }
        public FreeSqlFactory factory = new FreeSqlFactory();
        private void toolsConnection_Click(object sender, EventArgs e)
        {
            BaseForm<ConnectionStringManage> baseForm= new BaseForm<ConnectionStringManage>();
            baseForm.ShowDialog();

            ConnectionStringManage  connectionStringManage= new ConnectionStringManage();
            connectionStringManage.DataBaseType = DataBaseType.SqlServer;
            connectionStringManage.Address = "local";
            connectionStringManage.UserIds = "sa";
            connectionStringManage.Password = "sasa";
            connectionStringManage.IsWindows = false;

            factory.FreeSql.Insert<ConnectionStringManage>(connectionStringManage).ExecuteAffrows();
        }
    }
}
