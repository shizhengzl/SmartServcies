using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Policy;
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

            //var ds = OfficeServices.ExeclServices.GetDataTable(@"C:\Users\shizheng\Desktop\报表\房建进度款标准报表\3.3.xls");
            //var ds1 = OfficeServices.ExeclServices.GetDataTable(@"C:\Users\shizheng\Desktop\报表\房建进度款标准报表\3.进度款支付分项汇总表.xls");

            //InitdataBase database = new InitdataBase();
            //Console.WriteLine("Completed");

            InverstData inverstData = new InverstData();
            bool result = false;
            int i = 0;
            while (!result) {
                i++;
                if (i > 10000)
                {
                    break;
                }
                result = inverstData.start();
            } 
            Console.ReadLine();
        }
    }


    public class InverstData
    {
        public FreeSqlFactory factory = new FreeSqlFactory();
        List<DataItem> list = new List<DataItem>();

        ZMSetting setting = new ZMSetting()
        {
            Min = 10,
            Add = 10,
            toatl = 10000
        };

        public bool start() 
        {
            var result = false;
            var last = list.OrderByDescending(x => x.gamecode).FirstOrDefault();
            if (last == null) 
            {
                last = new DataItem
                {
                    wagers_date = DateTime.Now,
                    payoff = Core.UsuallyCommon.RandomExtensions.RandomBool() ? setting.Min : (0 - setting.Min),
                    betamount = setting.Min,
                    gamecode = 1
                };

                list.Add(last);
            }

            factory.FreeSql.Insert<DataItem>(last).ExecuteAffrows();

            AutoCacle autoCacle = new AutoCacle();

            var message = "";
            if (last.payoff > 0)
                message = "win:" + Math.Abs(last.payoff);
            if (last.payoff < 0)
                message = "lost:" + Math.Abs(last.payoff);
            if (last.payoff == 0)
                message = "和：" + Math.Abs(last.payoff);
         

            var data = autoCacle.Invest(setting, last);
            var allmoney = list.Sum(x => x.payoff).ToInt32();
          
           
            if (setting.toatl + allmoney < 0)
            {
                Console.WriteLine($"光");
                result = true;
            }
            Console.WriteLine($"总计数:{list.Count} {message}，下投{Math.Abs(data.payoff)},余:{setting.toatl + allmoney}");
            data.yuer = setting.toatl + allmoney;
            list.Add(data);

            return result;
        } 
    }

     


    public class AutoCacle
    {
        public decimal cacle(ZMSetting setting,DataItem data) {

            decimal response = 0;
            InvestStatus status = CacleStatus(data.payoff);

            switch (status)
            {
                case InvestStatus.Win:
                    response = data.payoff - ((data.payoff / 200) + 1) * setting.Add;
                    break;
                case InvestStatus.He:
                    break;
                case InvestStatus.Lost:
                    response = 0 - data.payoff + (Math.Abs(data.payoff) / 200 + 1) * setting.Add;
                    break;
                default:
                    break;
            }

            if(response < setting.Min)
                response = setting.Min;

            return response;
        }

        public InvestStatus CacleStatus(decimal payoff)
        {
            if (payoff == 0)
                return InvestStatus.He;
            if (payoff > 0)
                return InvestStatus.Win;
            if (payoff < 0)
                return InvestStatus.Lost;
            return InvestStatus.Win;
        }

        public DataItem Invest(ZMSetting setting, DataItem data)
        {
          
            var money = cacle(setting, data).ToInt32();

            var rondom = Core.UsuallyCommon.RandomExtensions.RandomBoolTwo();
 
            DataItem response = new DataItem()
            {
                wagers_date = DateTime.Now,
                payoff = rondom ? money : 0- money,
                betamount = money,
                gamecode = data.gamecode + 1
            };
      
            return response;
        }
    }

    public enum InvestStatus
    { 
        Win,
        He,
        Lost
    }
    public class DataItem
    {
        public int yuer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long wagers_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime wagers_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long roundserial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string round_no { get; set; }
        /// <summary>
        /// 百家乐
        /// </summary>
        public string gametype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long gamecode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bet_detail { get; set; }
        /// <summary>
        /// 闲 ( 4 )庄 ( 9 )
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string poker_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal betamount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string commissionable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int64 payoff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string exchangerate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string result_status { get; set; }
        /// <summary>
        /// iOS手机
        /// </summary>
        public string platform { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string codename { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wagers_detail_key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool detail_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long gametype_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string video_url { get; set; }
    }

    public class ZMSetting
    {
        public int toatl { get; set; }

        public int DefaultInverstMoney { get; set; } = 10;

        public InverstMode inverstMode { get; set; } = InverstMode.Xian;


        public GnameSettig Zhuang { get; set; }

        public GnameSettig Xian { get; set; }

        public GnameSettig He { get; set; }

        public GnameSettig OK { get; set; }

        public GnameSettig One { get; set; }

        public GnameSettig Ten { get; set; }

        public GnameSettig fifty { get; set; }

        public GnameSettig hundred { get; set; }

        public int Add { get; set; } = 1;

        public int Min { get; set; } = 10;

        public IMode Imode { get; set; } = IMode.Await;

        public WRandom wRandom { get; set; } = WRandom.Random;
    }

    public enum WRandom
    {

        Random,
        Random095,
        Win,
        Lost
    }

    public enum IMode
    {
        Await,
        Add
    }
    public class GnameSettig
    {
        public Point point { get; set; }
    }
    public enum InverstMode
    {
        Xian = 0,
        Zhuang = 1,
        He = 2,
        Random = 3
    }
}
