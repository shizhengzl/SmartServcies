﻿using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    [Description("组织机构用户")]
    public class OrganizationUsers:BaseCompany
    {
        /// <summary>
        /// 用户
        /// </summary>
        [Description("用户")]
        public Guid UsersId { get; set; }

        /// <summary>
        /// 组织
        /// </summary>
        [Description("组织")]
        public Guid OrganizationsId { get; set; } 
    }
}
