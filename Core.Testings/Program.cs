using System;
using System.Collections.Generic;
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
    public enum Testenum { 
        A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q 
    }
    class Program
    {
        static void Main()
        {

            //var ds = OfficeServices.ExeclServices.GetDataTable(@"C:\Users\shizheng\Desktop\报表\房建进度款标准报表\3.3.xls");
            //var ds1 = OfficeServices.ExeclServices.GetDataTable(@"C:\Users\shizheng\Desktop\报表\房建进度款标准报表\3.进度款支付分项汇总表.xls");

            //InitdataBase database = new InitdataBase();
            //Console.WriteLine("Completed");  

            List<Tongji> tongjis= new List<Tongji>();
            for (int x   = 0; x < 100;x ++)
            {
                Tongji t = new Tongji() { 
                     Add = 1, Pici = x+1, Zongjiner =10000,Min =10
                };
                tongjis.Add(t);
            }

            tongjis.ForEach(x => {
                InverstData inverstData = new InverstData();
                bool result = false;
                int i = 0;
                while (!result)
                {
                    i++;
                    if (i > 10000)
                    {
                        break;
                    }
                    result = inverstData.start(x);
                    if (x.Yuer >=x.Zongjiner + 500) {
                        result = true;
                    }
                }
                FreeSqlFactory.FreeSql.Insert<Tongji>(x).ExecuteAffrows();
            });

            Console.ReadLine();
        }
    }


    public class Tongji : CacleResult
    { 
        public Int32 Pici { get; set; } 
        public int Min { get; set; }
        public int Add { get; set; }
        public int Zongjiner { get; set; } 
    }


    public class InverstData
    {
        public FreeSqlFactory factory = new FreeSqlFactory();
        List<DataItem> list = new List<DataItem>(); 
        public bool start(Tongji tj) 
        {
            var result = false;
            var last = list.OrderByDescending(x => x.roundserial).FirstOrDefault();
            if (last == null) 
            {
                last = new DataItem
                {
                    wagers_date = DateTime.Now,
                    payoff = Core.UsuallyCommon.RandomExtensions.RandomBool() ? tj.Min : (0 - tj.Min),
                    betamount = tj.Min,
                    roundserial = 1
                };

                list.Add(last);
            }



            AutoCacle autoCacle = new AutoCacle();
            var allmoney = list.Sum(x => x.payoff.ToDecimal());
            var wincount = list.Where(x => x.payoff > 0).Count();
            var lostcount = list.Where(x => x.payoff < 0).Count();
            var hecount = list.Where(x => x.payoff == 0).Count();
            var allinvest = list.Sum(x => Math.Abs(x.payoff)).ToDecimal();
            var maxinverst = list.Max(x => Math.Abs(x.payoff)).ToDecimal();
            var totallostcount = lostcount > wincount ? lostcount - wincount : 0;


            tj.HtCount = hecount;
            tj.LostCount = lostcount;
            tj.WinCount = wincount;
            tj.TotalCount = list.Count;
            tj.TotalLostCount = totallostcount;
            tj.TotalInvest = allinvest;
            tj.Yuer = tj.Zongjiner + allmoney;
            tj.MaxInvest = maxinverst;
            tj.last = last;
            last.Pici = tj.Pici;


            if (last.betamount == 0)
            {

            }
            FreeSqlFactory.FreeSql.Insert<DataItem>(last).ExecuteAffrows();

       
            CacleResult cacleResult = new CacleResult() {
              HtCount = hecount, LostCount = lostcount, WinCount = wincount, TotalCount = list.Count, TotalLostCount = totallostcount,
              TotalInvest = allinvest, Yuer = tj.Zongjiner + allmoney,  MaxInvest = maxinverst,last = last
            };
          

            if (tj.Zongjiner + allmoney < 0)
            {
                Console.WriteLine($"光");
                result = true;
            } 

            Console.WriteLine(cacleResult.Message()); 
            var data = autoCacle.Invest(tj, last);
            data.yuer = tj.Zongjiner.ToDecimal() + allmoney;
            list.Add(data);
             

            return result;
        } 
    }


    public class CacleResult
    { 
        public int TotalCount { get; set; }
        public decimal TotalInvest { get; set; }
        public int WinCount { get; set; }
        public int LostCount { get; set; }
        public int HtCount { get; set; }

        public decimal MaxInvest { get; set; } 

        public decimal Yuer {  get; set; }

        public int TotalLostCount { get; set; }


        public DataItem last {  get; set; }

        public string Message() { 
            var response = string.Empty;
            var totalcountstr = $"总计数:{TotalCount}。";
            var allinveststr = $"总投注:{TotalInvest}。";
            var wincontstr = $"赢{WinCount}。输{LostCount}。和{HtCount}。总计输{TotalLostCount}把";
            var currentstr = $"本次{(last.payoff > 0 ? "赢" : (last.payoff == 0 ? "和" : "输"))}{last.betamount}元";
            var yustr = $"余: { Yuer}";

            var maxlength = 12;

            response = totalcountstr.ToFixedRightWidth(maxlength)
             + allinveststr.ToFixedRightWidth(maxlength)
             + wincontstr.ToFixedRightWidth(20)
             + currentstr.ToFixedRightWidth(maxlength)
             + yustr.ToFixedRightWidth(maxlength);
            return response;
        }
    }
     


    public class AutoCacle
    {
        public decimal cacle(Tongji tj,DataItem data) {

            decimal response = 0;
            InvestStatus status = CacleStatus(data.payoff.ToDecimal());

            switch (status)
            {
                case InvestStatus.Win:
                   // response = data.payoff - ((data.payoff.ToInt32() / (20* tj.Add)) + 1) * tj.Add;

                    response = data.betamount -  tj.Add;
                    break;
                case InvestStatus.He:
                    response =  data.betamount;
                    break;
                case InvestStatus.Lost:
                    //response = 0 - data.payoff + (Math.Abs(data.payoff).ToInt32() / (20 * tj.Add) + 1) * tj.Add;
                    response =  data.betamount +  tj.Add;

                    break;
                default:
                    break;
            }

            if(response < tj.Min)
                response = tj.Min;

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

        public DataItem Invest(Tongji tj, DataItem data)
        {
            var xian = RandomExtensions.RamdoInt32(9) + 1;
            var zhuang = RandomExtensions.RamdoInt32(9) + 1;
            int money = (int) Math.Ceiling(cacle(tj, data));

            decimal payoff = 0.0M;
            if (zhuang == xian) {
                payoff = 0;
            }
            if (zhuang > xian)
            {
                payoff = money;// (money * 95).ToDecimal() / 100;
            }
            if (zhuang < xian)
            {
                payoff = 0- money;
            }


            DataItem response = new DataItem()
            {
                wagers_date = DateTime.Now,
                payoff = payoff,
                betamount = money,
                roundserial = data.roundserial + 1
            };


            if (response.betamount == 0)
            { 
                
            }
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
        public Int32 Pici { get; set; }
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
        public int betamount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string commissionable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal payoff { get; set; }
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
        public int Zongjiner { get; set; }

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
