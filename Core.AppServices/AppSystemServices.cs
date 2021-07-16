using System;
using System.Collections.Generic;
using System.Text;
using Core.AppEntitys;
using FreeSql;

namespace Core.AppServices
{
    /// <summary>
    /// 应用系统服务
    /// </summary>
    [AppServiceAttribute]
    public class AppSystemServices : IAppServices
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        public FreeSqlFactory factory = new FreeSqlFactory();

        /// <summary>
        /// 构造函数
        /// </summary>
        public AppSystemServices()
        {

        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="T">类型</typeparam> 
        /// <returns>Boolean</returns>
        public ISelect<T> GetEntitys<T>() where T : class
        {
            ResponseList<T> response = new ResponseList<T>();
            return factory.FreeSql.Select<T>();
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">类型t</param>
        /// <returns>Boolean</returns>
        public Boolean Remove<T>(T t) where T : class
        {
            ResponseList<T> response = new ResponseList<T>();
            return factory.FreeSql.Delete<T>(t).ExecuteAffrows() > 1;
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">类型t</param>
        /// <returns>Boolean</returns>
        public Int64 Create<T>(T t) where T : class
        {
            ResponseList<T> response = new ResponseList<T>();

            return factory.FreeSql.Insert<T>(t).ExecuteIdentity();
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">类型t</param>
        /// <returns>Boolean</returns>
        public Boolean Create<T>(T[] t) where T : class
        {
            ResponseList<T> response = new ResponseList<T>();

            return factory.FreeSql.Insert<T>(t).ExecuteAffrows() > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">类型t</param>
        /// <returns>Boolean</returns>
        public Boolean Modify<T>(T t) where T : class
        {
            ResponseList<T> response = new ResponseList<T>();
            return factory.FreeSql.Update<T>().SetSource(t).ExecuteAffrows() > 1;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">类型t</param>
        /// <returns>Boolean</returns>
        public Boolean Modify<T>(T[] t) where T : class
        {
            ResponseList<T> response = new ResponseList<T>();
            return factory.FreeSql.Update<T>().SetSource(t).ExecuteAffrows() > 1;
        }
    }
}
