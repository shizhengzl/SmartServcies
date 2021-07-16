using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppRepositorys
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Description("用户表")]
    public class Users : EntityBaseAll
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [Description("用户名称")]
        [Column(StringLength = 50)]
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
        [Column(StringLength = 50)]
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
        [Column(StringLength = 50)]
        public String Email { get; set; }


        /// <summary>
        /// 默认单位
        /// </summary>
        [Description("默认单位")]
        public Guid? DefaultCompany { get; set; }
    }
}
