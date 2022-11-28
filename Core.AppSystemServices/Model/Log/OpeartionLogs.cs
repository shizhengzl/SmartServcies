using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 操作日志表
    /// </summary>
    [Description("操作日志表")]
    public class OpeartionLogs : BaseCompany
    {
        /// <summary>
        /// 操作描述
        /// </summary>
        [Column(StringLength = -1)]
        [Description("操作描述")]
        public String OpeartionDescripton { get; set; }

        /// <summary>
        /// 原来数据
        /// </summary>
        [Column(StringLength = -1)]
        [Description("原来数据")]
        public String JsonData { get; set; }

        /// <summary>
        /// 现有数据
        /// </summary>
        [Column(StringLength = -1)]
        [Description("现有数据")]
        public String NewJsonData { get; set; }


        /// <summary>
        /// IP地址
        /// </summary>
        [Column(StringLength = 50)]
        [Description("IP地址")]
        public String IP { get; set; }
    }
}
