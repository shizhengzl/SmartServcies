using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 权限按钮
    /// </summary>
    [Description("权限按钮")]
    public class PermissionButton : BaseCompany
    {

        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")] 
        public Guid MenusId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        [Column(StringLength = 50)]
        public string Name { get; set;  }

        /// <summary>
        /// 唯一标识
        /// </summary>
        [Description("唯一标识")]
        [Column(StringLength = 500)]
        public string WebKey { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        [Column(StringLength = 500)]
        public string Note { get; set; }
    }
}
