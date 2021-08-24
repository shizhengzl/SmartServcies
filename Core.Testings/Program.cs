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

            var ds = OfficeServices.ExeclServices.GetDataTable(@"C:\Users\shizheng\Desktop\报表\房建进度款标准报表\3.3.xls");
            var ds1 = OfficeServices.ExeclServices.GetDataTable(@"C:\Users\shizheng\Desktop\报表\房建进度款标准报表\3.进度款支付分项汇总表.xls");

            InitdataBase database = new InitdataBase();
            Console.WriteLine("Completed");
        }
    }
}
