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
        }

        private void ChromiumWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            chromiumWebBrowser.GetBrowser().MainFrame.ExecuteJavaScriptAsync("document.getElementById('username').value='shizhengzl'");
            chromiumWebBrowser.GetBrowser().MainFrame.ExecuteJavaScriptAsync("document.getElementById('passwd').value='shizi120'");
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
