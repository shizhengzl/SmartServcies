using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Description("用户表")]
    public class Users : BaseCompany
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [Description("用户名称")]
        [Column(StringLength = 50,IsNullable =false)]
        public String UserName { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [Description("用户昵称")]
        [Column(StringLength = 50)]
        public String NikeName { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Description("手机号码")]
        [Column(StringLength = 50,IsNullable =false)]
        public String Phone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码")]
        [Column(StringLength = 50)]
        public String PassWord { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        [Description("用户邮箱")]
        [Column(StringLength = 50,IsNullable =false)]
        public String Email { get; set; }
         
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public bool Sex { get; set; }
    }
}
