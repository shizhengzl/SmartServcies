using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Core.AppEntitys;
using Core.DataBaseServices; 
using Core.UsuallyCommon;
using Microsoft.Office.Interop.Word;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Testings
{
    public enum Testenum { 
        A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q 
    }
    class Program
    {
        static void Main()
        {
            InitDatabase initDatabase= new InitDatabase();
            var m = new ConnectionStringManage() { CompanysId = "00000000-0000-0000-0000-000000000001".ToGuid() };
            ConnectionStringManageServices connection = new ConnectionStringManageServices();
             
            connection.GetConnections(m).ForEach(c => {
                var s = c.GetConnectionString();
                Console.WriteLine(s); 
               
                var dataBaseServices = new Core.DataBaseServices.DataBaseServices(c);
                dataBaseServices.GetDataBase().ForEach(x => {
                    Console.WriteLine(x.DataBaseName);

                    var tables = dataBaseServices.GetTable(x.DataBaseName);

                    tables.ForEach(p => {
                        Console.WriteLine($"{p.DataBaseName}:{p.TableName}");
                    });


                    var columns = dataBaseServices.GetColumn(x.DataBaseName);

                    columns.ForEach(p => {
                        Console.WriteLine($"{p.DataBaseName}:{p.TableName}:{p.ColumnName}");
                    });
                });


           

            });
            Console.ReadLine();
            return;

            //var ds = OfficeServices.ExeclServices.GetDataTable(@"C:\Users\shizheng\Desktop\报表\房建进度款标准报表\3.3.xls");
            //var ds1 = OfficeServices.ExeclServices.GetDataTable(@"C:\Users\shizheng\Desktop\报表\房建进度款标准报表\3.进度款支付分项汇总表.xls");

            //InitdataBase database = new InitdataBase();
            //Console.WriteLine("Completed");

            Console.WriteLine(StringExtensions.ToFixedLeftWidth("44", 8));
            Console.WriteLine(StringExtensions.ToFixedRightWidth("44", 8));
            Console.WriteLine(StringExtensions.ToFixedWidth("44", 8,"P"));

         

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
            Add = 0,
            toatl = 2000
        };

        public bool start() 
        {
            var result = false;
            var last = list.OrderByDescending(x => x.roundserial).FirstOrDefault();
            if (last == null) 
            {
                last = new DataItem
                {
                    wagers_date = DateTime.Now,
                    payoff = Core.UsuallyCommon.RandomExtensions.RandomBool() ? setting.Min : (0 - setting.Min),
                    betamount = setting.Min,
                    roundserial = 1
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
            var allmoney = list.Sum(x => x.payoff.ToDecimal());
          
           
            if (setting.toatl + allmoney < 0)
            {
                Console.WriteLine($"光");
                result = true;
            }
            var wincount = list.Where(x => x.payoff > 0).Count();
            var lostcount = list.Where(x => x.payoff < 0).Count();
            var hecount = list.Where(x => x.payoff == 0).Count();
            Console.WriteLine($"总计数:{list.Count} {message}，下投{Math.Abs(data.betamount)},赢{wincount},输{lostcount},和{hecount},余:{setting.toatl + allmoney}");
            data.yuer = setting.toatl.ToDecimal() + allmoney;
            list.Add(data);

            return result;
        } 
    }

     


    public class AutoCacle
    {
        public decimal cacle(ZMSetting setting,DataItem data) {

            decimal response = 0;
            InvestStatus status = CacleStatus(data.payoff.ToDecimal());

            switch (status)
            {
                case InvestStatus.Win:
                    //response = data.payoff - ((data.payoff / 200) + 1) * setting.Add;
                    response = data.betamount.ToInt32() -  setting.Add;
                    break;
                case InvestStatus.He:
                    break;
                case InvestStatus.Lost:
                    //response = 0 - data.payoff + (Math.Abs(data.payoff) / 200 + 1) * setting.Add;
                    response =  data.betamount.ToInt32() +  setting.Add;
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

            var zs = Core.UsuallyCommon.RandomExtensions.RandomBoolTwo();
            var money = cacle(setting, data).ToInt32();
            var newmoney = zs ? money * 0.95 : money;
            var rondom = Core.UsuallyCommon.RandomExtensions.RandomBoolTwo();
 
            DataItem response = new DataItem()
            {
                wagers_date = DateTime.Now,
                payoff = rondom ? money : 0-money,
                betamount = money,
                roundserial = data.roundserial + 1
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
        public decimal yuer { get; set; }
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
        public double payoff { get; set; }
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
