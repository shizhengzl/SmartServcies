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
    }
}
