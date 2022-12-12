using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Core.DataBaseServices;
using Core.FreeSqlServices;
using Core.UsuallyCommon;
using Microsoft.Office.Interop.Word;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Testings
{


    public enum Testenum
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q
    }
    class Program
    {
        public static FreeSqlFactory factory = new FreeSqlFactory();
        static void Main()
        {

            List<listresult> result = new List<listresult>();
            int defaultmoney = 0;
            int allmoney = 0;
            for (int i = 1; i < 200; i++)
            {
                listresult listresult = new listresult();
                defaultmoney += 10; 
                allmoney += defaultmoney; 
                listresult.count = i;
                listresult.money = allmoney;
                listresult.invest = defaultmoney;

                result.Add(listresult);
            }
            var s = result;
            Console.ReadLine();
        }



    }

    public class listresult
    {
        public int count { get; set; }

        public int invest { get; set; } 
        public decimal money { get; set; }
    }
}