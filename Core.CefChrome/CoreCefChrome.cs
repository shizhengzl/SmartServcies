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

namespace Core.CefChrome
{
    public partial class CoreCefChrome : Form
    {

        public ChromiumWebBrowser chromiumWebBrowser;

        public CoreCefChrome()
        {
            InitializeComponent();

            InitChrome();
        }

        public void InitChrome()
        {
            var tragerurl = string.Empty;// txtTargetUrl.Text.Trim(); 
            if (string.IsNullOrEmpty(tragerurl))
                tragerurl = "https://www.baidu.com";//"http://vip337.com:8866";
            CefSettings settings = new CefSettings();
            settings.Locale = "zh-CN";
            Cef.Initialize(settings, true); 

            chromiumWebBrowser = new ChromiumWebBrowser(tragerurl);
            chromiumWebBrowser.FrameLoadEnd += ChromiumWebBrowser_FrameLoadEnd;
            chromiumWebBrowser.LifeSpanHandler = new OpenPageSelf();


            chromiumWebBrowser.LoadingStateChanged += ChromiumWebBrowser_LoadingStateChanged;

            this.Controls.Add(chromiumWebBrowser); 
            chromiumWebBrowser.Dock = DockStyle.Fill;   
        }

        private void ChromiumWebBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
               
                //var js = @"(function (){ return document.querySelectorAll('a');})(); ";
                //chromiumWebBrowser.EvaluateScriptAsync(js).ContinueWith(x =>
                //{
                //    var response = x.Result;
                //    if (response.Success && response.Result != null)
                //    {

                //    }
                //});
                //chromiumWebBrowser.ExecuteScriptAsyncWhenPageLoaded("alert('All Resources Have Loaded');");
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

        private void btnGo_Click(object sender, EventArgs e)
        {
            InitChrome();
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
                sb.AppendFormat("{0}:{1}",cookie.Name,cookie.Value);
                sb.AppendLine();
            });
           
            MessageBox.Show(sb.ToString());
        }

        List<CefSharp.Cookie> cookies = new List<CefSharp.Cookie>();

        private void SaveCookie(CefSharp.Cookie cookie)
        {
            if(!cookies.Any(x=>x.Name == cookie.Name && x.Value == cookie.Value))
                cookies.Add(cookie); 
        }

        private void btnGetJson_Click(object sender, EventArgs e)
        {
            var jsonurl = @"https://vip337.com:8866/infe/macenter/record/betrecordcontroller/getliverecord.json";
            CookieContainer cookieContainer= new CookieContainer();
            CookieCollection cookieCollection= new CookieCollection();
            cookies.ForEach(cookie => {
                cookieCollection.Add(new System.Net.Cookie()
                {
                    Name = cookie.Name,
                    Value = cookie.Value,
                    Secure = cookie.Secure,
                    Domain = cookie.Domain,
                    Path = cookie.Path
                });

                cookieContainer.Add(new System.Net.Cookie() { 
                    Name = cookie.Name,
                    Value = cookie.Value, 
                    Secure = cookie.Secure,
                    Domain= cookie.Domain,
                    Path= cookie.Path
                });
            });
             
            var response = HttpClientHelper.CreateGetHttpResponse(jsonurl,10000,"", cookieCollection);
            var result = HttpClientHelper.GetResponseString(response);
            var root = JsonConvert.DeserializeObject<Root>(result);
   
            var data = root.data.FirstOrDefault();
            if(data != null)
            {
                Cdata(data, zMSetting);
            }  
        }

        private void btnInitUer_Click(object sender, EventArgs e)
        {
            var list = chromiumWebBrowser.GetBrowser().GetFrameNames();

            list.ToList().ForEach(x => {
                chromiumWebBrowser.GetBrowser().GetFrame(x).ExecuteJavaScriptAsync("document.getElementById('username').value='shizhengzl'");
                chromiumWebBrowser.GetBrowser().GetFrame(x).ExecuteJavaScriptAsync("document.getElementById('passwd').value='shizi120'");
                //chromiumWebBrowser.GetBrowser().GetFrame(x).ExecuteJavaScriptAsync("document.getElementById('LoginForm').submit()");
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("5");
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
            }

        }

        private void btnstartserver_Click(object sender, EventArgs e)
        {
            txtmessage.AppendText("start" + Environment.NewLine);
            
            var txtten = txtTen.Text.Trim();
            var txtok = txtOk.Text.Trim();

            var zhuang = txtzhuang.Text.Trim();
            var xian = txtxian.Text.Trim();
            var he = txtHe.Text.Trim();
           

            zMSetting = new ZMSetting() { 
                Ten = new GnameSettig() {  point = new Point() { X = txtten.Split(',')[0].ToInt32(), Y = txtten.Split(',')[1].ToInt32() } },
                OK = new GnameSettig() { point = new Point() { X = txtok.Split(',')[0].ToInt32(), Y = txtok.Split(',')[1].ToInt32() } },
                Zhuang = new GnameSettig() { point = new Point() { X = zhuang.Split(',')[0].ToInt32(), Y = zhuang.Split(',')[1].ToInt32() } },
                Xian = new GnameSettig() { point = new Point() { X = xian.Split(',')[0].ToInt32(), Y = xian.Split(',')[1].ToInt32() } },
                He = new GnameSettig() { point = new Point() { X = he.Split(',')[0].ToInt32(), Y = he.Split(',')[1].ToInt32() } }
            };
            switch (commode.SelectedText)
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
            timeserver.Interval = txtJg.Text.ToInt32() * 1000;
            timeserver.Enabled = true;
            timeserver.Start();
        }

        private void btnstopserver_Click(object sender, EventArgs e)
        {
            timeserver.Enabled = false;
            timeserver.Stop();
        }

        public ZMSetting zMSetting { get; set; }

        private void timeserver_Tick(object sender, EventArgs e)
        { 
            Cdata(new DataItem() { detail_status = true }, zMSetting);
        }

        public void Cdata(DataItem dataItem, ZMSetting zMSetting)
        {
            if (dataItem.detail_status)
            {
                Point point = new Point();
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
                txtmessage.AppendText(string.Format("{0}，{1}", zMSetting.Ten.point.X, zMSetting.Ten.point.Y) + Environment.NewLine);
                txtmessage.AppendText(string.Format("{0}，{1}", point.X,point.Y) + Environment.NewLine);
                txtmessage.AppendText(string.Format("{0}，{1}", zMSetting.OK.point.X, zMSetting.OK.point.Y) + Environment.NewLine);
                //// ten
                //MouseHelper.DoClick(zMSetting.Ten.point.X, zMSetting.Ten.point.Y);
                //// inverst
                //MouseHelper.DoClick(point.X, point.Y);
                //// ok
                //MouseHelper.DoClick(zMSetting.OK.point.X,zMSetting.OK.point.Y);
            }
        }
    }

 

    public class MouseHelper
    {
        #region win32

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags,
            int dx, int dy, uint data, UIntPtr extraInfo);

        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        public static void DoClick(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }
        #endregion
    }


    public enum InverstMode
    {
        Xian = 0,
        Zhuang = 1,
        He = 2,
        Random = 3
    }

    public class ZMSetting
    {
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
    }


    public class GnameSettig
    {  
        public Point point { get; set; }
    }
     

    /// <summary>
    /// 在自己窗口打开链接
    /// </summary>
    internal class OpenPageSelf : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Load(targetUrl);
            return true; //Return true to cancel the popup creation copyright by codebye.com.
        }
    }

    public class CookieVisitor : ICookieVisitor
    {
        //定义委托
        public Action<CefSharp.Cookie> SendCookie = null;
        public bool Visit(CefSharp.Cookie cookie, int count, int total, ref bool deleteCookie)
        {
            if (SendCookie != null)
            {
                SendCookie(cookie);
            }

            return true;
        }

        public void Dispose() { }
    }

}
