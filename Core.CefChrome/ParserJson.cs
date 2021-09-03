using Core.CefChrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CefChrome
{
    #region detail
    
 
    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long  wagers_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wagers_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long  roundserial { get; set; }
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
        public long  gamecode { get; set; }
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
        public string betamount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string commissionable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string payoff { get; set; }
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
        public long  gametype_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string video_url { get; set; }
    }

 
 
    public class Root
    { 
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long subCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subTotalBet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subTotalPayoff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subTotalComm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long  totalCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long  totalPages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string totalBet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string totalPayoff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string totalComm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string @select { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dateStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dateEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string serial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long  page { get; set; }
        /// <summary>
        /// 
        /// </summary>
       
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string maintain { get; set; }
    }
    #endregion

    #region total

    /*
    public class Ret_arrayFromItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
        }

        public class Ret_arrayToItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
        }

        public class Transfer_list
        {
            /// <summary>
            /// 
            /// </summary>
            public List<Ret_arrayFromItem> ret_arrayFrom { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Ret_arrayToItem> ret_arrayTo { get; set; }
        }

        public class Free_transfer
        {
            /// <summary>
            /// 
            /// </summary>
            public long  wallet_status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string free_transfer_wallet { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string enable { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string last_balance_code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string modified_at { get; set; }
        }

        public class Balance_listItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string maintain { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<int> game_list { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string balance { get; set; }
        }

        public class Interest_maintain
        {
            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public string token { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Transfer_list transfer_list { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Free_transfer free_transfer { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Balance_listItem> balance_list { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string agTestMsg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string total_balance { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string interest_balance { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Interest_maintain interest_maintain { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string message { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string maintain { get; set; }
        }*/
    #endregion
}