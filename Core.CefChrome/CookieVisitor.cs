using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CefChrome
{
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
