﻿using Core.UsuallyCommon.Model;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 单位租户表
    /// </summary>
    [Description("单位表")]
    public class Companys : EntityBaseAll
    {
        /// <summary>
        /// 租户名称
        /// </summary>
        [Description("单位名称")]
        [Column(StringLength = 50)]
        public String CompanyName { get; set; }
    }
}
