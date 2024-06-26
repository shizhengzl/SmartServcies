﻿using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Description("角色表")] 
    public class Roles : BaseCompany
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Description("角色名称")]
        [Column(StringLength = 50)]
        public string Name { get; set; }
         
        ///// <summary>
        ///// ID
        ///// </summary>
        //[Description("ID")]
        //[Column(IsPrimary = true)]
        //public Guid Id { get; set; }
    }
}
