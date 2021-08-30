using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 部门表
    /// </summary>
    [Description("部门表")]
    public class Departments : EntityBaseAll
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        [Description("部门名称")]
        [Column(StringLength = 50)]
        public string Name { get; set; }
    }
}
