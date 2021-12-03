using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.UsuallyCommon
{ 
    /// <summary>
    /// 性别
    /// </summary>
    [Description("性别")]
    public enum SexEnum
    {
        [Description("女")]
        Gril = 0,
        [Description("男")]
        Boy = 1
    }
    /// <summary>
    /// 是否
    /// </summary>
    [Description("是否")]
    public enum BooleanEnum
    {
        [Description("否")]
        False = 0,
        [Description("是")]
        True = 1 
    }

    /// <summary>
    /// 列表数据位置
    /// </summary>
    [Description("数据位置")]
    public enum ColumnDataAlignEnum
    {
        [Description("center")]
        Center = 0,
        [Description("left")]
        Left = 1,
        [Description("right")]
        Right = 1
    }


    /// <summary>
    /// 数据验证
    /// </summary>
    [Description("数据验证")]
    public enum ValidTypeEnum
    {
        [Description("")]
        None = 0,
        [Description("手机验证")]
        IsPhone = 1,
        [Description("邮件验证")]
        IsEmail = 2,
        [Description("数字验证")]
        IsNumber = 3
    }
}
