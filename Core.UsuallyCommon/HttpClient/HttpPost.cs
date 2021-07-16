using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// http post 请求
    /// </summary>
    public static class HttpPost
    {
        public static void Post()
        {
            using (HttpClient client = new HttpClient())
            {
                //client.PostAsync(url)
            }
        }
    }
}
