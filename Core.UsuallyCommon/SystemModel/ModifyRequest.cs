using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 修改动态实体
    /// </summary>
    public  class ModifyRequest
    {
        /// <summary>
        /// 修改表明
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 动态实体
        /// </summary>
        public object Model {  get; set; }
    }
}
