using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 枚举操作
    /// </summary>
    public static class EnumExtensions
    {

        /// <summary>
        /// 根据枚举获取查询列集合
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumClass> GetListEnumClass(this Type type)
        {
            List<EnumClass> list = new List<EnumClass>();
            try
            {
                foreach (int i in Enum.GetValues(type))
                {
                    var name = Enum.GetName(type, i);
                    var key = i;

                    FieldInfo field = type.GetField(name);

                    DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                    var description = attribute.IsNull() ? key.ToString() : attribute.Description;

                    list.Add(new EnumClass() { Keys = i, Description = description, Name = name });
                }
            }
            catch (Exception)
            {

            }
            return list;
        }


        /// <summary>
        /// 获取程序集中所有自定义枚举
        /// </summary>
        /// <returns></returns>
        public static List<CodeValue> GetAssembliesEnum()
        {
            List<CodeValue> response = new List<CodeValue>();
            var enums = AssembliesExtensions.GetEnums(String.Empty);

            enums.ForEach(x => {
                if (x.FullName.Contains("Core.UsuallyCommon") || x.FullName.Contains("Core.AppSystemServices"))
                {
                    response.Add(new CodeValue() { Code = x.Name,Name = x.GetClassOrEnumDescription() }); 
                } 
            });

            return response;
        }


        /// <summary>
        /// 获取程序集中所有自定义枚举
        /// </summary>
        /// <returns></returns>
        public static List<CodeValue> GetEnum(this String type)
        {
            List<CodeValue> response = new List<CodeValue>();
            var enums = AssembliesExtensions.GetEnums(String.Empty);

            enums.ForEach(x => {
                if (x.FullName.Contains("Core.UsuallyCommon") || x.FullName.Contains("Core.AppSystemServices"))
                {
                    if (type.ToUpper() == x.Name.ToUpper())
                    {
                        response =  x.GetEnum(); 
                    } 
                }
            });

            return response;
        }

        /// <summary>
        /// 根据枚举获取查询列集合
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<CodeValue> GetEnum(this Type type)
        {
            List<CodeValue> list = new List<CodeValue>();
            try
            {
                foreach (int i in Enum.GetValues(type))
                {
                    var name = Enum.GetName(type, i);
                    var key = i;

                    FieldInfo field = type.GetField(name);

                    DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                    var description = attribute.IsNull() ? name : attribute.Description;

                    list.Add(new CodeValue() { Code = i.ToString(),  Name =   description });
                }
            }
            catch (Exception)
            {

            }
            return list;
        }


        /// <summary>
        /// 根据枚举获取查询列集合
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumClass> GetListEnumClass<T>() where T : struct
        {
            List<EnumClass> list = new List<EnumClass>();
            try
            {
                foreach (int i in Enum.GetValues(typeof(T)))
                {
                    var name = Enum.GetName(typeof(T), i);
                    var key = i;

                    FieldInfo field = i.ToString().ToEnum<T>().GetType().GetField(name);

                    DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                    var description = attribute.IsNull() ? key.ToString() : attribute.Description;

                    list.Add(new EnumClass() { Keys = i, Description = description, Name = name });
                }
            }
            catch (Exception)
            {

            }
            return list;
        }

        /// <summary>
        /// 字符转枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T EnumParse<T>(string value) where T : struct
        {
            return EnumParse<T>(value, false);
        }

        /// <summary>
        /// 字符转枚举忽略大小写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T EnumParse<T>(string value, bool ignoreCase) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enum type.");
            }

            var result = (T)Enum.Parse(typeof(T), value, ignoreCase);
            return result;
        }


        /// <summary>
        /// 字符转枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value) where T : struct
        {
            return EnumParse<T>(value);
        }
        /// <summary>
        /// 字符转枚举忽略大小写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value, bool ignoreCase) where T : struct
        {
            return EnumParse<T>(value, ignoreCase);
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute.IsNull())
                return value.ToString();
            else
                return attribute.Description;
        }

        /// <summary>
        /// 枚举转字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<string, string> EnumToDictionary(this Type enumType)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            foreach (int i in Enum.GetValues(enumType))
            {
                list.Add(i.ToString(), Enum.GetName(enumType, i));
            }
            return list;
        }

        /// <summary>
        /// 枚举转字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<int, string> EnumToKeyValue(this Type enumType)
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            foreach (int i in Enum.GetValues(enumType))
            {
                list.Add(i, Enum.GetName(enumType, i));
            }
            return list;
        }

        /// <summary>
        /// 枚举转List<string>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> EnumToList<T>() where T : struct
        {
            List<string> list = new List<string>();
            foreach (int i in Enum.GetValues(typeof(T)))
            {
                list.Add(Enum.GetName(typeof(T), i));
            }
            return list;
        }


        /// <summary>
        /// 枚举转List<string>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> EnumToList(this Type objects)
        {
            List<string> list = new List<string>();
            foreach (int i in Enum.GetValues(objects))
            {
                list.Add(Enum.GetName(objects, i));
            }
            return list;
        }

        /// <summary>
        /// 值转枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this Int64 value) where T : struct
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        /// <summary>
        /// 值转枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this Int32 value) where T : struct
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
    }
}
