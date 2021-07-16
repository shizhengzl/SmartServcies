using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

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
                    property.SetValue(instance, Convert.ChangeType(value, property.PropertyType), null);
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
    }
}
