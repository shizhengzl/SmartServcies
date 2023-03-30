using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using System.Net;
using CefSharp.DevTools.Network;
using Core.UsuallyCommon;
using Newtonsoft.Json;
using Core.CefChrome.Properties;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using Core.FreeSqlServices;

namespace Core.CefChrome
{
    public partial class CoreCefChrome : Form
    { 
        public ChromiumWebBrowser chromiumWebBrowser;
        List<CefSharp.Cookie> cookies = new List<CefSharp.Cookie>();
 
        public ZMSetting zMSetting { get; set; }
        public CoreCefChrome()
        {
            //this.WindowState = FormWindowState.;    //最大化窗体
            this.Location = new System.Drawing.Point(0, 0);
        
            InitializeComponent(); 
            InitChrome();

        } 
        public void InitChrome()
        {
            var tragerurl = string.Empty;// txtTargetUrl.Text.Trim(); 
            if (string.IsNullOrEmpty(tragerurl))
                tragerurl ="https://vip337.com:8866"; //"https://www.baidu.com";//
            CefSettings settings = new CefSettings();
            settings.Locale = "zh-CN";
            Cef.Initialize(settings, true);  
            chromiumWebBrowser = new ChromiumWebBrowser(tragerurl);
            chromiumWebBrowser.FrameLoadEnd += ChromiumWebBrowser_FrameLoadEnd;
            chromiumWebBrowser.LifeSpanHandler = new OpenPageSelf(); 
            chromiumWebBrowser.LoadingStateChanged += ChromiumWebBrowser_LoadingStateChanged; 
            this.panchrome.Controls.Add(chromiumWebBrowser); 
            chromiumWebBrowser.Dock = DockStyle.Fill;   
        } 

        private void btnGo_Click(object sender, EventArgs e)
        {
            InitChrome();
        } 
    
        private void btnGetJson_Click(object sender, EventArgs e)
        {
            var jsonurl = @"https://vip337.com:8866/infe/macenter/record/betrecordcontroller/getliverecord.json";
            CookieContainer cookieContainer = new CookieContainer();
            CookieCollection cookieCollection = new CookieCollection();
            cookies.ForEach(cookie => {
                cookieCollection.Add(new System.Net.Cookie()
                {
                    Name = cookie.Name,
                    Value = cookie.Value,
                    Secure = cookie.Secure,
                    Domain = cookie.Domain,
                    Path = cookie.Path
                });

                cookieContainer.Add(new System.Net.Cookie()
                {
                    Name = cookie.Name,
                    Value = cookie.Value,
                    Secure = cookie.Secure,
                    Domain = cookie.Domain,
                    Path = cookie.Path
                });
            });

            var response = HttpClientHelper.CreateGetHttpResponse(jsonurl, 10000, "", cookieCollection);
            if (response != null)
            {
                var result = HttpClientHelper.GetResponseString(response);
                var root = JsonConvert.DeserializeObject<Root>(result);

                if (root != null && root.data != null)
                {
                    root.data.betInfo.ForEach(x =>
                    {
                        if (!DataBaseFactory.Core_Application.FreeSql.Select<DataItem>().Any(p => p.roundSerial == x.roundSerial))
                            DataBaseFactory.Core_Application.FreeSql.Insert<DataItem>(x).ExecuteAffrowsAsync();
                    });
                }
            }
        } 
        private void CoreCefChrome_KeyDown(object sender, KeyEventArgs e)
        {
            string value = string.Format("{0},{1}", Cursor.Position.X.ToStringExtension(), Cursor.Position.Y.ToStringExtension());
            switch (e.KeyCode)
            {
                case Keys.F2:
                    txtzhuang.Text = value;
                    break;
                case Keys.F3:
                    txtxian.Text = value;
                    break;
                case Keys.F4:
                    txtHe.Text = value;
                    break;
                case Keys.F5:
                    txtOk.Text = value;
                    break;
                case Keys.F6:
                    txtTen.Text = value;
                    break;
                case Keys.F7:
                    txtOne.Text = value;
                    break;
            }

        }
        private void btnstartserver_Click(object sender, EventArgs e)
        { 
            timeserver.Interval = txtJg.Text.ToInt32() * 1000;
            timeserver.Enabled = true;
            timeserver.Start();
        } 
        public void InitData()
        {
            ShowText("start===============================");

            var txtten = txtTen.Text.Trim();
            var txtok = txtOk.Text.Trim(); 
            var zhuang = txtzhuang.Text.Trim();
            var xian = txtxian.Text.Trim();
            var he = txtHe.Text.Trim(); 
            var one = txtOne.Text.Trim();
            zMSetting = new ZMSetting()
            {
                Ten = new GnameSettig() { point = new Point() { X = txtten.Split(',')[0].ToInt32(), Y = txtten.Split(',')[1].ToInt32() } },
                OK = new GnameSettig() { point = new Point() { X = txtok.Split(',')[0].ToInt32(), Y = txtok.Split(',')[1].ToInt32() } },
                Zhuang = new GnameSettig() { point = new Point() { X = zhuang.Split(',')[0].ToInt32(), Y = zhuang.Split(',')[1].ToInt32() } },
                Xian = new GnameSettig() { point = new Point() { X = xian.Split(',')[0].ToInt32(), Y = xian.Split(',')[1].ToInt32() } },
                He = new GnameSettig() { point = new Point() { X = he.Split(',')[0].ToInt32(), Y = he.Split(',')[1].ToInt32() } },
                One = new GnameSettig() { point = new Point() { X = one.Split(',')[0].ToInt32(), Y = one.Split(',')[1].ToInt32() } },
                Add = txtAdd.Text.Trim().ToInt32(),
                Min = txtMin.Text.Trim().ToInt32(),
                Imode = comIMode.SelectedItem.ToStringExtension().ToEnum<IMode>(),
                wRandom = comrandom.SelectedItem.ToStringExtension().ToEnum<WRandom>()
            };
            switch (commode.SelectedItem)
            {
                case "Z":
                    zMSetting.inverstMode = InverstMode.Zhuang;
                    break;
                case "X":
                    zMSetting.inverstMode = InverstMode.Xian;
                    break;
                case "H":
                    zMSetting.inverstMode = InverstMode.He;
                    break;
                case "Rondom":
                    zMSetting.inverstMode = InverstMode.Random;
                    break;
            }

            if (Moni)
            {
                var data = GetMoni(zMSetting);
                Cdata(data, zMSetting);
            }
            else
            {
                cookieCollection = new CookieCollection();
                var date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                var enddate = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
                var jsonurl = "https://www.vip337.com:9900/entrance/betrecord/live/getBetRecord?gameKind=3&searchType=date&page=1&startDate="+date+"&endDate=" + enddate;

               // var jsonurl = @"https://vip337.com:8866/infe/macenter/record/betrecordcontroller/getliverecord.json";
           
                cookies.ForEach(cookie => {
                    cookieCollection.Add(new System.Net.Cookie()
                    {
                        Name = cookie.Name,
                        Value = cookie.Value,
                        Secure = cookie.Secure,
                        Domain = cookie.Domain,
                        Path = cookie.Path
                    });

                    cookieContainer.Add(new System.Net.Cookie()
                    {
                        Name = cookie.Name,
                        Value = cookie.Value,
                        Secure = cookie.Secure,
                        Domain = cookie.Domain,
                        Path = cookie.Path
                    });
                });
                var response = HttpClientHelper.CreateGetHttpResponse(jsonurl, 10000, "", cookieCollection);
                if (response != null)
                {
                    var result = HttpClientHelper.GetResponseString(response);
                    var root = JsonConvert.DeserializeObject<Root>(result);

                    var data = root.data.betInfo.FirstOrDefault();
                    if (data != null)
                    {
                        Cdata(data, zMSetting);
                    }
                    else
                    { 
                        Cdata(GetMoni(zMSetting), zMSetting);
                    }
                }
            }
        }
        CookieContainer cookieContainer = new CookieContainer();
        CookieCollection cookieCollection = new CookieCollection();

        public bool isover(string danhao,out decimal money)
        {
            var date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var enddate = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd"); 
            var url = 
                "https://www.vip337.com:9900/infe/macenter/record/cashrecordcontroller/getcashrecord.json?PayWay=ALL&pay_way_result=ALL&Sort=desc&sDate="+date+"&eDate="+enddate+"&qPage=1";
            money = 0;
            var response = HttpClientHelper.CreateGetHttpResponse(url, 10000, "", cookieCollection);
            if (response != null)
            {
                var result = HttpClientHelper.GetResponseString(response);
                var root = JsonConvert.DeserializeObject<searchs>(result);
                if (root != null)
                {
                    var count = root.ARR_WDATA.Where(x => x.ACT_RESULT == "单号:" + danhao).Count();

                    money = root.ARR_WDATA.Where(x => x.ACT_RESULT == "单号:" + danhao).OrderByDescending(p=>p.KEY_DATE).FirstOrDefault().NOW_GOLD;

                    return count >= 2;
                }
            } 
            return false;
        }

        public class searchs
        { 
            public List<searchitem> ARR_WDATA { get; set; }
        }

        public class searchitem
        { 
            public  string ACT_RESULT { get; set; }//"单号:30149382826"//


            public decimal NOW_GOLD { get; set; }// 育儿


            public DateTime KEY_DATE { get; set; }
        }


        public int wincount = 0;
        public int lostcount = 0;
        public int hecount = 0;
        public decimal nowmoney = 0;
        public int currentbashu = 0;

        public void Cdata(DataItem dataItem, ZMSetting zMSetting)
        {
            initlevel();
            var has = isover(dataItem.wagersId.ToString(), out nowmoney);
            if (dataItem != null)
            {
                if (has)
                {
                    if (!DataBaseFactory.Core_Application.FreeSql.Select<DataItem>().Any(x => x.roundSerial == dataItem.roundSerial))
                        DataBaseFactory.Core_Application.FreeSql.Insert<DataItem>(dataItem).ExecuteAffrowsAsync();
                }
               
            }
            if (has) { 
           
                Point point = new Point();
                ShowText($"投注:{zMSetting.inverstMode.ToString()}");
                // 开始
                switch (zMSetting.inverstMode)
                {
                    case InverstMode.Xian:
                        point = zMSetting.Xian.point;
                        break;
                    case InverstMode.Zhuang:
                        point = zMSetting.Zhuang.point;
                        break;
                    case InverstMode.He:
                        point = zMSetting.He.point;
                        break;
                    case InverstMode.Random:
                        point = Core.UsuallyCommon.RandomExtensions.RandomBool() ? zMSetting.Xian.point : zMSetting.Zhuang.point;
                        break;
                    default:
                        break;
                }

                ShowText($"选择I模式:{zMSetting.Imode.ToString()}");
                if (zMSetting.Imode == IMode.Await)
                {
                    ShowText($"上一把{(dataItem.payoff.ToDecimal() > 0 ? "赢": "输")}了{dataItem.betAmount}");
                    var clicknum = zMSetting.DefaultInverstMoney.ToDecimal();

                    ShowText($"选择金额1，坐标{zMSetting.One.point.X},{zMSetting.One.point.Y}");
                    // ten
                    if (!Moni)
                        MouseHelper.DoClick(zMSetting.One.point.X, zMSetting.One.point.Y);
                    ShowText($"选择投注点击次数{clicknum}");
                    for (int i = 0; i < clicknum; i++)
                    {
                        // inverst
                        if(!Moni)
                            MouseHelper.DoClick(point.X, point.Y);
                    }
                    // ok
                    ShowText($"点击ok,坐标:{zMSetting.OK.point.X},{zMSetting.OK.point.Y}");
                    if (!Moni)
                        MouseHelper.DoClick(zMSetting.OK.point.X, zMSetting.OK.point.Y);
                }
                if (zMSetting.Imode == IMode.Add)
                {
                    ShowText($"选择金额1，坐标{zMSetting.One.point.X},{zMSetting.One.point.Y}");
                    // one
                    if (!Moni)
                        MouseHelper.DoClick(zMSetting.One.point.X, zMSetting.One.point.Y);

                    decimal investmoney = 0;
                    if (dataItem.payoff.ToDecimal() > 0) {
                        ShowText($"上一把赢了{dataItem.payoff.ToDecimal()}");
                        investmoney = dataItem.betAmount.ToDecimal() - zMSetting.Add.ToDecimal();

                        wincount++; 
                    }
                    if (dataItem.payoff.ToDecimal() == 0)
                    {
                        ShowText($"上一把和了,{dataItem.betAmount.ToDecimal()}");
                        investmoney = dataItem.betAmount.ToDecimal() ;
                        hecount++;
                    }
                    if (dataItem.payoff.ToDecimal() < 0)
                    {
                        ShowText($"上一把输了,{dataItem.betAmount.ToDecimal()}");
                        investmoney = 0 - dataItem.payoff.ToDecimal() + zMSetting.Add.ToDecimal();
                        lostcount++;
                    }

                    if (investmoney < zMSetting.Min.ToDecimal())
                    {
                        ShowText($"投注低于最小,{investmoney},{zMSetting.Min.ToDecimal()}");
                        investmoney = zMSetting.Min.ToDecimal();
                    }


                    var targer = result.OrderBy(x => x.money).ToList().Where(p => nowmoney > p.money).LastOrDefault();
                    if (currentbashu == 0)
                        currentbashu =  targer.count;
                    else
                    {
                        if(currentbashu < targer.count)
                        {
                            currentbashu = targer.count;
                            investmoney = zMSetting.Min;
                            ShowText($"达到目标把数{currentbashu},重置");
                        }
                            
                    }

                    var next = result.OrderBy(x => x.money).ToList().Where(p => p.count== currentbashu+1).FirstOrDefault();
                


                    ShowText($"最终投注:{investmoney}，总计赢{wincount},输:{lostcount},和:{hecount}");
                    ShowText($"把数：{currentbashu}，金额把数：{next.count} 下个金额：{next.money},还差:{next.money - nowmoney}");
                    ShowText($"选择投注点击次数{investmoney}");
                    for (int i = 0; i < investmoney; i++)
                    {
                        // inverst
                        if (!Moni)
                            MouseHelper.DoClick(point.X, point.Y);
                    }
                    //ShowText($"点击ok,坐标:{zMSetting.OK.point.X},{zMSetting.OK.point.Y}");
                    // ok
                    if (!Moni)
                        MouseHelper.DoClick(zMSetting.OK.point.X, zMSetting.OK.point.Y);
                }
            }
        }

        #region 其他代码

        private void ShowText(string text)
        {
            txtmessage.AppendText(text + Environment.NewLine);
        }

        private void btnInitUer_Click(object sender, EventArgs e)
        {
            var list = chromiumWebBrowser.GetBrowser().GetFrameNames();

            list.ToList().ForEach(x => {
                chromiumWebBrowser.GetBrowser().GetFrame(x).ExecuteJavaScriptAsync("document.getElementById('username').value='shizhengzl'");
                chromiumWebBrowser.GetBrowser().GetFrame(x).ExecuteJavaScriptAsync("document.getElementById('passwd').value='shizi120'");
            });
        }

        private void ChromiumWebBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {

            }
        }

        private void ChromiumWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            //var result = chromiumWebBrowser.GetSourceAsync();
            //if (result.Status == TaskStatus.RanToCompletion)
            //    MessageBox.Show(result.ToString());
        }

        private void CoreCefChrome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void btnstopserver_Click(object sender, EventArgs e)
        {
            timeserver.Enabled = false;
            timeserver.Stop();
        }
        private void timeserver_Tick(object sender, EventArgs e)
        {
            InitData(); 
        }

        private void BtnGetCookie_Click(object sender, EventArgs e)
        {
            //注册获取cookie回调事件
            ICookieManager cookieManager = chromiumWebBrowser.GetCookieManager();
            CookieVisitor visitor = new CookieVisitor();
            visitor.SendCookie += SaveCookie;
            cookieManager.VisitAllCookies(visitor);

            StringBuilder sb = new StringBuilder();
            cookies.ForEach(cookie => {
                sb.AppendFormat("{0}:{1}", cookie.Name, cookie.Value);
                sb.AppendLine();
            });
            MessageBox.Show(sb.ToString());
        }
        private void SaveCookie(CefSharp.Cookie cookie)
        {
            if (!cookies.Any(x => x.Name == cookie.Name && x.Value == cookie.Value))
                cookies.Add(cookie);
        }
        #endregion

        public bool Moni = true;

        private void btnmn_Click(object sender, EventArgs e)
        {
            Moni = !Moni;

            btnmn.Text = Moni ? "模拟" : "真实";
        }

        private DataItem GetMoni(ZMSetting settings)
        {
            var dataItem = DataBaseFactory.Core_Application.FreeSql.Select<DataItem>().OrderByDescending(x => x.roundSerial).ToOne();
            var win = true;
            switch(zMSetting.wRandom)
            {
                case WRandom.Random:
                    win = RandomExtensions.RandomBool();
                    break;
                case WRandom.Random095:
                    win = RandomExtensions.RandomBool095();
                    break;
                case WRandom.Win:
                    win = true;
                    break;
                case WRandom.Lost:
                    win = false;
                    break;

            }
            if(dataItem == null)
            {
                return new DataItem()
                { 
                    payoff = win ? settings.Min : 0 - settings.Min,
                    betAmount = settings.Min,
                    roundSerial = 1
                };

            }
            decimal investmoney = zMSetting.DefaultInverstMoney;
            if (zMSetting.Imode == IMode.Add)
            {
                if (dataItem.payoff.ToDecimal() > 0)
                {
                   
                        investmoney = dataItem.payoff.ToDecimal() - zMSetting.Add.ToDecimal();
                  
                }
                if (dataItem.payoff.ToDecimal() == 0)
                {
                    investmoney = dataItem.betAmount.ToDecimal();
                }
                if (dataItem.payoff.ToDecimal() < 0)
                {
                    //if ((dataItem.betamount.ToDecimal() - zMSetting.Min.ToDecimal()) / zMSetting.Add.ToDecimal() == 20)
                    //{
                    //    investmoney = (zMSetting.Min.ToDecimal() + dataItem.betamount.ToDecimal())
                    //        *
                    //        ((dataItem.betamount.ToDecimal() - zMSetting.Min.ToDecimal()) / zMSetting.Add.ToDecimal()) / 2;
                    //}
                    //else if ((dataItem.betamount.ToDecimal() - zMSetting.Min.ToDecimal()) / zMSetting.Add.ToDecimal() > 20)
                    //{
                    //    investmoney = dataItem.betamount.ToDecimal() * 2;
                    //}
                    //else
                        investmoney = 0 - dataItem.payoff.ToDecimal() + zMSetting.Add.ToDecimal();
                }

                if (investmoney < zMSetting.Min.ToDecimal())
                {
                    investmoney = zMSetting.Min.ToDecimal();
                }
            }

            dataItem.betAmount = investmoney;
            dataItem.roundSerial += 1;
            dataItem.payoff =win ? investmoney : 0 - investmoney;
            return dataItem;
        }

        public void initlevel()
        {
            result = new List<listresult>();
            decimal defaultmoney = 0;
            decimal allmoney = 0;
            for (int i = 1; i < 200; i++)
            {
                listresult listresult = new listresult();
                defaultmoney += zMSetting.Add.ToInt32();

                defaultmoney = defaultmoney+ (int)(defaultmoney / (zMSetting.Add.ToInt32()* 20));

                allmoney += defaultmoney;
                listresult.count = i;
                listresult.money = allmoney;
                listresult.invest = defaultmoney; 
                result.Add(listresult);
            }
        }

        List<listresult> result = new List<listresult>(); 


    }

   

    public class listresult
    {
        public int count { get; set; }

        public decimal invest { get; set; }
        public decimal money { get; set; }
    }
}
