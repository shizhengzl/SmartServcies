using System.ComponentModel;

namespace Core.AppWebApi
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public class DtoUser
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [Description("用户名称")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码")]
        public string PassWord { get; set; }
    }
}
