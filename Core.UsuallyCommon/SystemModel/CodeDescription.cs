using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 返回代码描述
    /// </summary>
    public enum CodeDescription
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 200,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Faile = 500,
        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        Login = 50008,
        /// <summary>
        /// 未找到
        /// </summary>
        [Description("未找到")]
        NotFind = 404,
        /// <summary>
        /// 未授权
        /// </summary>
        [Description("未授权")]
        NotPermission = 403
    }
}
