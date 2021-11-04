using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System.ComponentModel;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 基础数据
    /// </summary>
    [Description("基础数据")]
    public class BaseData : BaseCompany
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Description("编码")]
        [Column(StringLength = 50)]
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        [Column(StringLength = 50)]
        public string Name {  get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        [Column(StringLength = -1)]
        public string Description {  get; set; }
        
    }
}
