using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 程序集扩展
    /// </summary>
    public static class AssembliesExtensions
    {
        /// <summary>
        /// 获取所有Assembly
        /// </summary>
        /// <param name="path">程序集路劲,如果没有则当前编译目录下</param>
        /// <returns>List<Assembly></returns>
        public static List<Assembly> GetAssemblies(string path)
        {
            List<Assembly> allAssemblies = new List<Assembly>();
            path = string.IsNullOrEmpty(path) ? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) : path;
            foreach (string dll in Directory.GetFiles(path, "*.dll"))
                allAssemblies.Add(Assembly.LoadFile(dll));
            return allAssemblies;
        }

        /// <summary>
        /// 获取所有接口
        /// </summary>
        /// <param name="path">程序集路劲,如果没有则当前编译目录下</param>
        /// <returns>List<Type></returns>
        public static List<Type> GetInterfaces<T>(string path)
        {
            var allAssemblies = GetAssemblies(path);
            var instance = allAssemblies
                .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(T))))
                .ToList();
            return instance;
        }

        /// <summary>
        /// 获取所有接口
        /// </summary>
        /// <param name="path">程序集路劲,如果没有则当前编译目录下</param>
        /// <returns>List<Type></returns>
        public static List<Type> GetInterfaces(string path)
        {
            var allAssemblies = GetAssemblies(path);
            var instance = allAssemblies
                .SelectMany(a => a.GetTypes().Where(t => t.IsInterface))
                .ToList();
            return instance;
        }

        /// <summary>
        /// 获取所有枚举
        /// </summary>
        /// <param name="path">程序集路劲,如果没有则当前编译目录下</param>
        /// <returns>List<Type></returns>
        public static List<Type> GetEnums(string path)
        {
            var allAssemblies = GetAssemblies(path);
            var instance = allAssemblies
                .SelectMany(a => a.GetTypes().Where(t => t.IsEnum))
                .ToList();
            return instance;
        }
    }
}
