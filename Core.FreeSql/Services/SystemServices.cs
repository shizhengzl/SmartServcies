using Core.UsuallyCommon;
using FreeSql.Internal.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FreeSqlServices
{
    [AppServiceAttribute]
    public class SystemServices 
    { 

        public SystemServices()
        {

        }

        /// <summary>
        /// 查询返回json
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public  string GetEntitys(BaseRequest<string> request)
        {
            var type = request.TableName.GetClassType();
            DynamicFilterInfo dyfilter = JsonConvert.DeserializeObject<DynamicFilterInfo>(request.Model); 
            var sql = FreeSqlFactory.FreeSql.Select<object>().AsType(type).WhereDynamicFilter(dyfilter).OrderByPropertyName(request.Sort)
                .Page(request.PageIndex, request.PageSize).ToSql();

            var list = FreeSqlFactory.FreeSql.Select<object>().AsType(type).WhereDynamicFilter(dyfilter).OrderByPropertyName(request.Sort)
                .Page(request.PageIndex,request.PageSize).ToList();
            return JsonConvert.SerializeObject(list);
        }


        /// <summary>
        /// 修改动态实体
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string ModifyEntitys(ModifyRequest request)
        {
            var type = request.TableName.GetClassType();

         
            dynamic requestmodel = JsonConvert.DeserializeObject(Convert.ToString(request.Model),type);
            var Id = requestmodel.Id;
            //var sql = FreeSqlFactory.FreeSql.Update<object>().AsType(type).SetDto(requestmodel).WhereDynamic(new { Id = Id }).ToSql();

            var sql = FreeSqlFactory.FreeSql.Update<object>().AsType(type).SetDto(requestmodel).WhereDynamic(new { Id = Id }).ExecuteAffrows();

            return JsonConvert.SerializeObject(requestmodel);
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
            return FreeSqlFactory.FreeSql.Select<T>();
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
            return FreeSqlFactory.FreeSql.Delete<T>(t).ExecuteAffrows() > 1;
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
            SetCreateModel<T>(t);
            return FreeSqlFactory.FreeSql.Insert<T>(t).ExecuteIdentity() > 0;
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
            foreach (var item in t)
            {
                SetCreateModel<T>(item);
            }

            FreeSqlFactory.FreeSql.Insert<T>(t).ExecuteAffrows();

            return t;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public List<T> Create<T>(List<T> t) where T : class
        {
            foreach (var item in t)
            {
                SetCreateModel<T>(item);
            }

            FreeSqlFactory.FreeSql.Insert<T>(t).ExecuteAffrows();

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
            SetModifyModel<T>(t); 
            return FreeSqlFactory.FreeSql.Update<T>().SetSource(t).ExecuteAffrows() > 1;
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
            foreach (var item in t)
            {
                SetModifyModel<T>(item);
            }
            return FreeSqlFactory.FreeSql.Update<T>().SetSource(t).ExecuteAffrows() > 1;
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
