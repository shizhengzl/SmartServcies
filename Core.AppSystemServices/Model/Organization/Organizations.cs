using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 组织机构表
    /// </summary>
    [Description("组织机构表")]
    public class Organizations : BaseCompany
    {
        /// <summary>
        /// 组织机构名称
        /// </summary>
        [Description("组织机构名称")]
        [Column(StringLength = 50)]
        public string Name { get; set; }


        /// <summary>
        /// 父级机构
        /// </summary>
        [Description("父级机构")] 
        public Guid ParentId { get; set; }



        [Column(IsIgnore = true)]
        [Description("子节点")]
        public List<Organizations> children { get; set;  }

        [Column(IsIgnore = true)]
        [Description("存在子集")]
        public bool hasChildren { get; set; }

    }
}
