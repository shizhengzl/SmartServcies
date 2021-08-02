using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.AppEntitys;
using Core.UsuallyCommon;
using Microsoft.Office.Interop.Word;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Testings
{
    class Program
    {
        static void Main()
        {

           // var ds = OfficeServices.ExeclServices.GetDataTable(@"C:\Users\shizheng\Desktop\模板\导入清单参考样式 (1).xls");

            InitdataBase database = new InitdataBase();
             
            Console.WriteLine("Completed");
        }
    }
}
