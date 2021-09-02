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
            CefSettings settings = new CefSettings();

            Cef.Initialize(settings);

            chromiumWebBrowser = new ChromiumWebBrowser("http://vip337.com:8866");
            chromiumWebBrowser.FrameLoadEnd += ChromiumWebBrowser_FrameLoadEnd;
            this.Controls.Add(chromiumWebBrowser);

            chromiumWebBrowser.Dock = DockStyle.Fill;
            // sid=5d114f3b494acfaa406b7db08745d29b690b916f
            var searchurl = @"https://prolivey.com/ipl/portal.php/game/betrecord_search/kind3?GameCode=1&GameType=3001&sid={0}&lang=cn&rnd1630578589476";

          
        }

        private void ChromiumWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            
        }

        private void CoreCefChrome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var list = chromiumWebBrowser.GetBrowser().GetFrameNames();
            
            list.ToList().ForEach(x=>{
                chromiumWebBrowser.GetBrowser().GetFrame(x).ExecuteJavaScriptAsync("document.getElementById('username').value='shizhengzl'");
                chromiumWebBrowser.GetBrowser().GetFrame(x).ExecuteJavaScriptAsync("document.getElementById('passwd').value='shizi120'");
            });
           
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
            //var jsonurl = @"https://vip337.com:8866/infe/macenter/account/moneyswitchcontroller/translist.json";//
            //var jsonurl = @"https://prolivey.com/ipl/portal.php/game/betrecord_search/kind3?GameCode=1&GameType=3001&lang=cn&rnd1630578589476&sid=";

            var jsonurl = @"https://vip337.com:8866/infe/macenter/record/betrecordcontroller/getliverecord.json";
            CookieContainer cookieContainer= new CookieContainer();
            CookieCollection cookieCollection= new CookieCollection();
            cookies.ForEach(cookie => {
                //if(cookie.Name == "BBSESSID")
                //    jsonurl =jsonurl + cookie.Value + "&";
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

            //var result = HttpClientHelper.GetAsync(jsonurl, cookieContainer);
            var response = HttpClientHelper.CreateGetHttpResponse(jsonurl,10000,"", cookieCollection);
            var result = HttpClientHelper.GetResponseString(response);
            var root = JsonConvert.DeserializeObject<Root>(result);
            //var money = root.balance_list.Where(x => x.name == "BBIN").FirstOrDefault().balance;

            var money = root.data.FirstOrDefault().payoff;
            MessageBox.Show(money);

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
