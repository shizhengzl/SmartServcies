using System;
using System.Collections.Generic;
using System.Text;
using Core.FreeSqlServices;
using Core.UsuallyCommon;

namespace Core.AppSystemServices
{
    [AppServiceAttribute]
    public class SystemServices : IServices
    {
        public FreeSqlFactory factory = new FreeSqlFactory();

        public SystemServices()
        {

        }


        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public FreeSql.ISelect<T> GetEntitys<T>() where T : class
        {
            ResponseList<T> response = new ResponseList<T>();
            return factory.FreeSql.Select<T>();
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public Boolean Remove<T>(T t) where T : class
        {
            ResponseList<T> response = new ResponseList<T>();
            return factory.FreeSql.Delete<T>(t).ExecuteAffrows() > 1;
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public Boolean Create<T>(T t) where T : class
        {
            ResponseList<T> response = new ResponseList<T>();
            SetCreateModel<T>(t);
            return factory.FreeSql.Insert<T>(t).ExecuteIdentity() > 0;
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public T[] Create<T>(T[] t) where T : class
        {
            ResponseList<T> response = new ResponseList<T>();
            foreach (var item in t)
            {
                SetCreateModel<T>(item);
            }
            
            factory.FreeSql.Insert<T>(t).ExecuteAffrows();

            return t;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public Boolean Modify<T>(T t) where T : class
        {
            ResponseList<T> response = new ResponseList<T>();
            SetModifyModel<T>(t);
            return factory.FreeSql.Update<T>().SetSource(t).ExecuteAffrows() > 1;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public Boolean Modify<T>(T[] t) where T : class
        {
            ResponseList<T> response = new ResponseList<T>();
            foreach (var item in t)
            {
                SetModifyModel<T>(item);
            }
            return factory.FreeSql.Update<T>().SetSource(t).ExecuteAffrows() > 1;
        }

        /// <summary>
        /// 设置创建对象默认创建时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        private void SetCreateModel<T>(T t) where T : class
        {
            t.SetPropertyValue("CreateTime", DateTime.UtcNow);
            if (t.GetPropertyValue("Id").IsNull()) 
            {
                t.SetPropertyValue("Id", Guid.NewGuid());
            }
        }

        /// <summary>
        /// 设置修改对象默认修改时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        private void SetModifyModel<T>(T t) where T : class
        {
            t.SetPropertyValue("ModifyTime", DateTime.UtcNow);
        }
    }
}
