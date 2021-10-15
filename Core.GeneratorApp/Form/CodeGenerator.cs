using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.DataBaseServices;

namespace Core.GeneratorApp
{
    public partial class CodeGenerator : Form
    { 
        public CodeGenerator()
        {
            InitializeComponent();
            InitDataBase();
        }

        public void InitDataBase()
        {
            this.dataBaseTrees.Companyid = GeneratorWindows._currentUser.User.CompanysId;
            this.dataBaseTrees.InitTree();
        }
    }
}
