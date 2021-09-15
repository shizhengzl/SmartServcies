using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 随机扩展
    /// </summary>
    public static class RandomExtensions
    {

        /// <summary>
        /// 随机生成bool
        /// </summary>
        /// <returns></returns>
        public static bool RandomBool095()
        {
            return RamdoInt32(200) > 102;
        }

        /// <summary>
        /// 随机生成bool
        /// </summary>
        /// <returns></returns>
        public static bool RandomBoolTwo()
        {
            return RamdoInt32(2) == 1;
        }


        /// <summary>
        /// 随机生成bool
        /// </summary>
        /// <returns></returns>
        public static bool RandomBool()
        {
            return RamdoInt32() % 2 == 0;
        }

        /// <summary>
        /// 随机生成一个数字
        /// </summary>
        /// <param name="max">从0开始到max</param>
        /// <returns>INT32</returns>
        public static Int32 RamdoInt32(Int32 max = 9)
        {
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            return rd.Next(0, max);
        }

        /// <summary>
        /// 随机生成指定长度数字
        /// </summary>
        /// <param name="length">长度x</param>
        /// <param name="max">从0开始到max</param>
        /// <returns>string</returns>
        public static string RamdomString(Int32 length, Int32 max = 9)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.AppendFormat("{0}", RamdoInt32(max));
            }
            return sb.ToStringExtension();
        }

    }
}
