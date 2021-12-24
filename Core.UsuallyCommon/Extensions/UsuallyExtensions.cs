using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class UsuallyExtensions
    {
        /// <summary>
        /// 扩展判断是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Boolean IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// 根据字符串获取类type
        /// </summary>
        /// <param name="typeName">类名称字符串</param>
        /// <returns></returns>
        public static Type GetClassType(this string typeName)
        {
            Type type = null;
            Assembly[] assemblyArray = AppDomain.CurrentDomain.GetAssemblies();
            int assemblyArrayLength = assemblyArray.Length;
            for (int i = 0; i < assemblyArrayLength; ++i)
            {
                type = assemblyArray[i].GetType(typeName,false,true);
                if (type != null)
                {
                    return type;
                }
            }

            for (int i = 0; (i < assemblyArrayLength); ++i)
            {
                Type[] typeArray = assemblyArray[i].GetTypes();
                int typeArrayLength = typeArray.Length;
                for (int j = 0; j < typeArrayLength; ++j)
                {
                    if (typeArray[j].Name.ToUpper().Equals(typeName.ToUpper()))
                    {
                        return typeArray[j];
                    }
                }
            }
            return type;
        }

    }
}
