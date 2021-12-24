using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.DataBaseServices
{
    /// <summary>
    /// 表
    /// </summary>
    [Description("表")]
    public class Table : DataBase
    {
        /// <summary>
        /// 表名
        /// </summary>
        [Description("表名")]
        [Column(StringLength = 1000)]
        public string TableName { get; set; }
        /// <summary>
        /// 表描述
        /// </summary>
        [Description("表描述")]
        [Column(StringLength = 1000)]
        public string TableDescription { get; set; }


        /// <summary>
        /// 存在描述
        /// </summary>
        [Description("存在描述")] 
        public Boolean HasDescription { get; set; }

    }
}
