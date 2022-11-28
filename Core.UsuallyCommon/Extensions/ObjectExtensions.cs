using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Collections;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 对象扩展
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 设置动态对象children
        /// </summary>
        /// <param name="list"></param>
        public static List<object> SetChildren(this List<object> list,Type type)
        { 
            var father = FindRoot(list);
            father.ForEach(x => {
                FindChild(list, x, type);
            });
            return father;
        }

        /// <summary>
        /// 获取顶级父项
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static void FindChild(List<object> list,object obj, Type type)
        {
            var listparent = new List<object>(); 
            list.ForEach(x => { 
                if (!x.GetProperty("ParentId").IsNull())
                {
                    var sparentid = x.GetPropertyValue("ParentId").ToStringExtension().ToUpper();
                    var sid = x.GetPropertyValue("Id").ToStringExtension().ToUpper();
                    var oid = obj.GetPropertyValue("Id").ToStringExtension().ToUpper();

                    if (sparentid == oid)
                    {
                        var children = obj.GetPropertyObjectValue("children");

                        Type t = typeof(List<>); 
                        Type specificListType = t.MakeGenericType(type); 
                       


                        if (children == null || string.IsNullOrEmpty(children.ToStringExtension()))
                        {
                            System.Collections.IList add = Activator.CreateInstance(specificListType) as System.Collections.IList;
                            //List<object> add = new List<object>();
                            add.Add(x);
                            obj.SetPropertyValue("children", add);
                        }
                        else
                        {
                            System.Collections.IList add = (IList) children; 
                            //var add = (List<object>)(children);
                            add.Add(x);
                            obj.SetPropertyValue("children", add);
                        } 
                        FindChild(list, x,type);
                    }
                }
            }); 
        }

        /// <summary>
        /// 获取顶级父项
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<object> FindRoot(List<object> list)
        {
            var listparent = new List<object>();
            var parentid = "ParentId";
            list.ForEach(x => {
                var property = x.GetProperty("ParentId");
                if (!property.IsNull())
                {
                    if (x.GetPropertyValue(parentid).ToStringExtension() == Guid.Empty.ToStringExtension()) {
                        listparent.Add(x);
                    }
                }
            });
            return listparent;
        }

        /// <summary>
        /// 获取对象属性名称
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static PropertyInfo GetProperty(this object objects,string propertyName)
        {
            PropertyInfo[] propertys = objects.GetType().GetProperties();

            return propertys.FirstOrDefault(p => p.Name.ToUpper() == propertyName.ToUpper());
        }


        /// <summary>
        /// 判断动态类型属性值
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string GetDynamicProperty(this object objects, string propertyName)
        {
            string response = string.Empty;
            foreach (PropertyInfo item in objects.GetType().GetProperties())
            {
                if (item.Name == propertyName)
                {
                    response = item.GetValue(objects, null).ToStringExtension(); 
                    break;
                }
            }
            return response;
        }
        /// <summary>
        /// 判断动态类型是否包含属性
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static Boolean HasDynamicProperty(this object objects,string propertyName)
        {
            bool response = false;
            foreach (PropertyInfo item in objects.GetType().GetProperties())
            {
                if (item.Name == propertyName)
                {
                    response = true;
                    break;
                }
            }
            return response;
        }

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
        /// 获取对象属性名称
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static List<String> GetPropertyList(this Type objects)
        {
            PropertyInfo[] propertys = objects.GetProperties();

            return propertys.Select(x => x.Name).ToList<string>();
        }


        /// <summary>
        /// 获取类属性字段和描述
        /// </summary>
        /// <param name="obj"></param> 
        /// <returns>string</returns>
        public static List<PropertyExtensions> GetPropertyExtensions<T>()
        {
            List<PropertyExtensions> response = new List<PropertyExtensions>();
            typeof(T).GetProperties().ToList().ForEach(x => { 
                response.Add(new PropertyExtensions()
                {
                    PropertyName = x.Name,
                    PropertyDescription = x.GetPropertyDescription()
                });
            });

            return response;
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
                    if (property.PropertyType.UnderlyingSystemType.Name == "Guid")
                        property.SetValue(instance, Convert.ChangeType(value.ToGuid(), property.PropertyType), null);
                    else if (property.PropertyType.IsEnum)
                        property.SetValue(instance, value, null);
                    //else if (property.PropertyType.Name.Contains("List"))
                    //{
                        
                    //}
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
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetPropertyObjectValue(this object obj, string name)
        {
            return obj.GetType().GetProperty(name).GetValue(obj, null);
        }


        /// <summary>
        /// 获取属性特性
        /// </summary>
        /// <param name="obj"></param> 
        /// <returns>string</returns>
        public static string GetClassOrEnumDescription(this Type obj)
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
        /// 获取属性特性
        /// </summary>
        /// <param name="obj"></param> 
        /// <returns>string</returns>
        public static string GetPropertyDescription<T>(this PropertyInfo obj,string attpropertyname)  
        {
            var response = obj.GetCustomAttributes(typeof(T), false);
            if (response != null)
            {
                foreach (T att in response)
                {
                    return att.GetPropertyValue(attpropertyname);
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
