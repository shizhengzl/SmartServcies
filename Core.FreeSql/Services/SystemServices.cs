using Core.UsuallyCommon;
using FreeSql.Internal.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.FreeSqlServices
{
    [AppServiceAttribute]
    public class SystemServices 
    { 
        public SystemServices()
        { 
        }

        public SystemServices(IFreeSql FreeSql)
        {
            _FreeSql = FreeSql;
        }

        public IFreeSql _FreeSql {  get; set; }


        /// <summary>
        /// 查询返回json
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<object> GetEntitys(BaseRequest<string> request)
        {
            var type = request.TableName.GetClassType();
            DynamicFilterInfo dyfilter = JsonConvert.DeserializeObject<DynamicFilterInfo>(request.Model);

            var sql = _FreeSql.Select<object>().AsType(type).WhereDynamicFilter(dyfilter).OrderByPropertyName(request.Sort)
                .Page(request.PageIndex, request.PageSize).ToSql();

            request.TotalCount = _FreeSql.Select<object>().AsType(type).WhereDynamicFilter(dyfilter).Count();
            var list = _FreeSql.Select<object>().AsType(type).WhereDynamicFilter(dyfilter).OrderByPropertyName(request.Sort,request.Asc)
                .Page(request.PageIndex,request.PageSize).ToList();
            return list;
        }


        /// <summary>
        /// 修改动态实体
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string SaveEntitys(ModifyRequest request)
        {
            var type = request.TableName.GetClassType(); 
            dynamic requestmodel = JsonConvert.DeserializeObject(Convert.ToString(request.Model),type); 
        
            if (!requestmodel.GetDynamicProperty("Id").IsNull())
                _FreeSql.Update<object>().AsType(type).SetDto(requestmodel).WhereDynamic(new { Id = requestmodel.Id }).ExecuteAffrows();
            else
                _FreeSql.Insert<object>().AsType(type).AppendData(requestmodel).ExecuteAffrows();
            //var sql = FreeSqlFactory.FreeSql.Update<object>().AsType(type).SetDto(requestmodel).WhereDynamic(new { Id = Id }).ToSql();
            return JsonConvert.SerializeObject(requestmodel);
        }

        /// <summary>
        /// 修改动态实体
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string RemoveEntity(ModifyRequest request)
        {
            var type = request.TableName.GetClassType();  
            dynamic requestmodel = JsonConvert.DeserializeObject(Convert.ToString(request.Model), type); 
            _FreeSql.Delete<object>().AsType(type).WhereDynamic(new { Id = requestmodel.Id }).ExecuteAffrows();
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
            return _FreeSql.Select<T>();
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
            return _FreeSql.Delete<T>(t).ExecuteAffrows() > 1;
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
            return _FreeSql.Insert<T>(t).ExecuteIdentity() > 0;
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

            _FreeSql.Insert<T>(t).ExecuteAffrows();

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

            _FreeSql.Insert<T>(t).ExecuteAffrows();

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
            return _FreeSql.Update<T>().SetSource(t).ExecuteAffrows() > 1;
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
            return _FreeSql.Update<T>().SetSource(t).ExecuteAffrows() > 1;
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
