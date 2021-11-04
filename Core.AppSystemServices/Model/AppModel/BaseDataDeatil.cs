using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 基础数据明细
    /// </summary>
    [Description("基础数据明细")]
    public class BaseDataDeatil: BaseCompany
    {

        /// <summary>
        /// 父编码
        /// </summary>
        [Description("父编码")] 
        public Guid BaseDataId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Description("编码")]
        [Column(StringLength = 50)]
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        [Column(StringLength = 50)]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        [Column(StringLength = -1)]
        public string Description { get; set; }
    }
}
