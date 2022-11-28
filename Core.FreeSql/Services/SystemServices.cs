using Core.UsuallyCommon;
using FreeSql.Internal.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Core.FreeSqlServices
{
    [AppServiceAttribute]
    public class SystemServices
    {
        #region 构造函数和属性 
        public SystemServices()
        { 

        }

        public SystemServices(IFreeSql FreeSql)
        {
            _FreeSql = FreeSql;
        }

        public IFreeSql _FreeSql { get; set; }
        #endregion

        #region 查询 

        /// <summary>
        /// 查询返回List
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<object> GetAllEntitys(string TableName,Guid CommpayId)
        { 
            DynamicFilterInfo dyfilter = new DynamicFilterInfo()
            {
                Logic = DynamicFilterLogic.And,
                Field = "CompanysId",
                Operator = DynamicFilterOperator.Equals,
                Value = CommpayId.ToString() 
            };
 
            DateTime time = DateTime.UtcNow;
            DateTime donetime = DateTime.UtcNow;
            var type = TableName.GetClassType(); 
            var sql = _FreeSql.Select<object>().AsType(type).WhereDynamicFilter(dyfilter)
               // .OrderByPropertyName("CreateTime",false)
                .ToSql();

            var list = _FreeSql.Select<object>().AsType(type).WhereDynamicFilter(dyfilter)
                //.OrderByPropertyName("CreateTime", false)
                .ToList();

            DataBaseFactory.Core_Log.FreeSql.Insert<SqlLogs>(new SqlLogs
            {
                Sql = sql,
                CreateTime = DateTime.UtcNow,
                ExecuteTimeLongs = (donetime - time).Milliseconds
            }).ExecuteAffrows();

            return list;
        }
        /// <summary>
        /// 查询返回List
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<object> GetEntitys(BaseRequest<string> request)
        { 
            DateTime time = DateTime.UtcNow;
            DateTime donetime = DateTime.UtcNow;
            var type = request.TableName.GetClassType();
            DynamicFilterInfo dyfilter = JsonConvert.DeserializeObject<DynamicFilterInfo>(request.Model); 

            var sql = _FreeSql.Select<object>().AsType(type)
                .WhereDynamicFilter(dyfilter)
                .OrderByPropertyName(request.Sort, request.Asc)
                .Page(request.PageIndex, request.PageSize)
                .ToSql(); 

            request.TotalCount = _FreeSql.Select<object>().AsType(type).WhereDynamicFilter(dyfilter).Count();

            var list = _FreeSql.Select<object>()
                .AsType(type).WhereDynamicFilter(dyfilter)
                .OrderByPropertyName(request.Sort, request.Asc)
                .Page(request.PageIndex, request.PageSize)
                .ToList();

            DataBaseFactory.Core_Log.FreeSql.Insert<SqlLogs>(new SqlLogs
            {
                Sql = sql,
                CreateTime = DateTime.UtcNow,
                ExecuteTimeLongs = (donetime - time).Milliseconds
            }).ExecuteAffrows();

            return list;
        }

        /// <summary>
        /// 查询返回json
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<object> GetTreeEntitys(BaseRequest<string> request)
        {
            DateTime time = DateTime.UtcNow;
            DateTime donetime = DateTime.UtcNow;
            var type = request.TableName.GetClassType();
            DynamicFilterInfo dyfilter = JsonConvert.DeserializeObject<DynamicFilterInfo>(request.Model);

            var sql = _FreeSql.Select<object>().AsType(type)
                .WhereDynamicFilter(dyfilter)
                .OrderByPropertyName(request.Sort, request.Asc)
                .Page(request.PageIndex, request.PageSize)
                .ToSql();

            request.TotalCount = _FreeSql.Select<object>().AsType(type).WhereDynamicFilter(dyfilter).Count();

            var list = _FreeSql.Select<object>()
                .AsType(type).WhereDynamicFilter(dyfilter)
                .OrderByPropertyName(request.Sort, request.Asc)
                .Page(request.PageIndex, request.PageSize)
                .ToList();

            var now =  list.SetChildren(type);

            DataBaseFactory.Core_Log.FreeSql.Insert<SqlLogs>(new SqlLogs
            {
                Sql = sql,
                CreateTime = DateTime.UtcNow,
                ExecuteTimeLongs = (donetime - time).Milliseconds
            }).ExecuteAffrows();

            return now;
        }
        /// <summary>
        /// 查询实体分页
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
        #endregion

        #region 修改和保存
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string SaveEntitys(ModifyRequest request)
        {
            var type = request.TableName.GetClassType();

            var strmodel = Convert.ToString(request.Model);
            dynamic requestmodel = JsonConvert.DeserializeObject(strmodel, type);

            string sql = string.Empty;
            DateTime time = DateTime.UtcNow;
            DateTime donetime = DateTime.UtcNow;
            if (requestmodel.Id != Guid.Empty)
            {
                sql = _FreeSql.Update<object>().AsType(type).SetDto(requestmodel).WhereDynamic(new { Id = requestmodel.Id }).ToSql();
                _FreeSql.Update<object>().AsType(type).SetDto(requestmodel).WhereDynamic(new { Id = requestmodel.Id }).ExecuteAffrows();
                donetime = DateTime.UtcNow;
            }
            else
            {
                sql = _FreeSql.Insert<object>().AsType(type).AppendData(requestmodel).ToSql();
                _FreeSql.Insert<object>().AsType(type).AppendData(requestmodel).ExecuteAffrows();
                donetime = DateTime.UtcNow;
            }

            DataBaseFactory.Core_Log.FreeSql.Insert<SqlLogs>(new SqlLogs
            {
                Sql = sql,
                CreateUserId = requestmodel.CreateUserId,
                CreateTime = DateTime.UtcNow,
                CompanysId = requestmodel.CompanysId,
                ExecuteTimeLongs = (donetime - time).Milliseconds
            }).ExecuteAffrows();

            return JsonConvert.SerializeObject(requestmodel);
        }
        #endregion

        #region 删除实体
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string RemoveEntity(ModifyRequest request)
        {
            DateTime time = DateTime.UtcNow;
            DateTime donetime = DateTime.UtcNow;
            var type = request.TableName.GetClassType();
            dynamic requestmodel = JsonConvert.DeserializeObject(Convert.ToString(request.Model), type);
            var sql = _FreeSql.Delete<object>().AsType(type).WhereDynamic(new { Id = requestmodel.Id }).ToSql();
            _FreeSql.Delete<object>().AsType(type).WhereDynamic(new { Id = requestmodel.Id }).ExecuteAffrows();
              
            // 记录SQL日志 
            DataBaseFactory.Core_Log.FreeSql.Insert<SqlLogs>(new SqlLogs
            {
                Sql = sql,
                CreateUserId = requestmodel.CreateUserId,
                CreateTime = DateTime.UtcNow,
                CompanysId = requestmodel.CompanysId,
                ExecuteTimeLongs = (donetime - time).Milliseconds
            }).ExecuteAffrows();
            return JsonConvert.SerializeObject(requestmodel);
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
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseRequest"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public Boolean Remove<T>(T[] t) where T : class
        {
            bool response = true;
            t.ToList().ForEach(x =>
            {
                response = _FreeSql.Delete<T>(x).ExecuteAffrows() > 1;
            });
            return response;
        }
        #endregion

        #region 新增和批量新增
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

            string sql = string.Empty;
            DateTime time = DateTime.UtcNow;
            DateTime donetime = DateTime.UtcNow;

            SetCreateModel<T>(t);

            sql = _FreeSql.Insert<T>(t).ToSql();
            DataBaseFactory.Core_Log.FreeSql.Insert<SqlLogs>(new SqlLogs
            {
                Sql = sql,
                CreateUserId = t.GetPropertyValue("CreateUserId").ToGuid(),
                CreateTime = DateTime.UtcNow,
                CompanysId = t.GetPropertyValue("CompanysId").ToGuid(),
                ExecuteTimeLongs = (donetime - time).Milliseconds
            }).ExecuteAffrows();

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
            string sql = string.Empty;
            DateTime time = DateTime.UtcNow;
            DateTime donetime = DateTime.UtcNow;
            foreach (var item in t)
            {
                SetCreateModel<T>(item);
            }
         
            sql = _FreeSql.Insert<T>(t).ToSql();

            _FreeSql.Insert<T>(t).ExecuteAffrows();

            DataBaseFactory.Core_Log.FreeSql.Insert<SqlLogs>(new SqlLogs
            {
                Sql = sql,
                CreateUserId = t[0].GetPropertyValue("CreateUserId").ToGuid(),
                CreateTime = DateTime.UtcNow,
                CompanysId = t[0].GetPropertyValue("CompanysId").ToGuid(),
                ExecuteTimeLongs = (donetime - time).Milliseconds
            }).ExecuteAffrows();
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
            string sql = string.Empty;
            DateTime time = DateTime.UtcNow;
            DateTime donetime = DateTime.UtcNow;
            foreach (var item in t)
            {
                SetCreateModel<T>(item);
            }
            sql = _FreeSql.Insert<T>(t).ToSql();

            _FreeSql.Insert<T>(t).ExecuteAffrows();
            DataBaseFactory.Core_Log.FreeSql.Insert<SqlLogs>(new SqlLogs
            {
                Sql = sql,
                CreateUserId = t[0].GetPropertyValue("CreateUserId").ToGuid(),
                CreateTime = DateTime.UtcNow,
                CompanysId = t[0].GetPropertyValue("CompanysId").ToGuid(),
                ExecuteTimeLongs = (donetime - time).Milliseconds
            }).ExecuteAffrows();
            return t;
        }

        #endregion

        #region 修改和批量修改

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
            string sql = string.Empty;
            DateTime time = DateTime.UtcNow;
            DateTime donetime = DateTime.UtcNow;
            SetModifyModel<T>(t);
            sql = _FreeSql.Update<T>().SetSource(t).ToSql();

            DataBaseFactory.Core_Log.FreeSql.Insert<SqlLogs>(new SqlLogs
            {
                Sql = sql,
                CreateUserId = t.GetPropertyValue("CreateUserId").ToGuid(),
                CreateTime = DateTime.UtcNow,
                CompanysId = t.GetPropertyValue("CompanysId").ToGuid(),
                ExecuteTimeLongs = (donetime - time).Milliseconds
            }).ExecuteAffrows();
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
            DateTime time = DateTime.UtcNow;
            DateTime donetime = DateTime.UtcNow;
            foreach (var item in t)
            {
                SetModifyModel<T>(item);
            }
            var sql = _FreeSql.Update<T>().SetSource(t).ToSql();
            DataBaseFactory.Core_Log.FreeSql.Insert<SqlLogs>(new SqlLogs
            {
                Sql = sql,
                CreateUserId = t[0].GetPropertyValue("CreateUserId").ToGuid(),
                CreateTime = DateTime.UtcNow,
                CompanysId = t[0].GetPropertyValue("CompanysId").ToGuid(),
                ExecuteTimeLongs = (donetime - time).Milliseconds
            }).ExecuteAffrows();

            return _FreeSql.Update<T>().SetSource(t).ExecuteAffrows() > 1;
        }
        #endregion




        #region 设置默认值
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
        #endregion
    }
}
