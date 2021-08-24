using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 对象扩展
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 获取对象属性名称
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static List<String> GetPropertyList(this object objects)
        {
            PropertyInfo[] propertys = objects.GetType().GetProperties();

            return propertys.Select(x => x.Name).ToList<string>();
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(this object instance, string propertyName, object value)
        {
            var propertyInfos = instance.GetType().GetProperties().ToList();
            var property = (propertyInfos.FirstOrDefault(x => x.Name == propertyName));
            if (property != null)
            {
                if (IsNullableType(property.PropertyType))
                    property.SetValue(instance, value, null);
                else
                {
                    if(property.PropertyType.UnderlyingSystemType.Name == "Guid")
                        property.SetValue(instance, Convert.ChangeType(value.ToGuid(), property.PropertyType), null);
                    else if(property.PropertyType.IsEnum)
                        property.SetValue(instance,value, null);
                    else
                        property.SetValue(instance, Convert.ChangeType(value, property.PropertyType), null);
                }
                   
            }
        }

        /// <summary>
        /// 可空类型判断
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetPropertyValue(this object obj, string name)
        {
            return obj.GetType().GetProperty(name).GetValue(obj, null).ToStringExtension();
        }

        /// <summary>
        /// 获取属性特性
        /// </summary>
        /// <param name="obj"></param> 
        /// <returns>string</returns>
        public static string GetPropertyDescription(this PropertyInfo obj)
        {
            var response = obj.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (response != null)
            {
                foreach (DescriptionAttribute att in response)
                {
                    return att.Description;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 根据字符串获取类型
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type GetTypeByName(this string typeName)
        {
            Type type = null;
            Assembly[] assemblyArray = AppDomain.CurrentDomain.GetAssemblies();
            int assemblyArrayLength = assemblyArray.Length;
            for (int i = 0; i < assemblyArrayLength; ++i)
            {
                type = assemblyArray[i].GetType(typeName);
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
                    if (typeArray[j].Name.Equals(typeName))
                    {
                        return typeArray[j];
                    }
                }
            }
            return type;

        }
    }
}
