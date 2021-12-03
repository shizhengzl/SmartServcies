using Core.FreeSqlServices;
using Core.UsuallyCommon;
using FreeSql.Internal.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Core.AppSystemServices
{
    /// <summary>
    /// 公用服务
    /// </summary>
    [AppServiceAttribute]
    public class CommonServices: SystemServices
    {
        public CommonServices() : base(DataBaseFactory.Core_Application.FreeSql)
        {

        }

        /// <summary>
        /// 获取基础数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<BaseDataDetail> GetBaseDataDeatil(string name,Guid companyId)
        {
            List<BaseDataDetail> response = new List<BaseDataDetail>();
            var parentId = GetEntitys<BaseData>().Where(x => x.Name == name && x.CompanysId == companyId).ToList().FirstOrDefault();
            if(parentId != null)
                response = GetEntitys<BaseDataDetail>().Where(x => x.BaseDataId == parentId.Id).ToList();
            return response;
        }


        /// <summary>
        /// 是否存在配置
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public bool CheckShowColumns(string TableName)
        {
            return GetEntitys<ShowColumns>().Any(x => x.TableName == TableName);
        }

        /// <summary>
        /// 保存显示列
        /// </summary>
        /// <param name="showColumns"></param>
        /// <returns></returns>
        public bool SaveShowColumns(List<ShowColumns> showColumns)
        {
            var response = Create<ShowColumns>(showColumns);
            return response.Count > 0;
        }


        /// <summary>
        /// 获取显示列
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public List<ShowColumns> GetShowColumns(string TableName)
        {
            return GetEntitys<ShowColumns>().Where(x => x.TableName == TableName && x.IsShow).OrderBy(x=>x.Sort).ToList();
        }

        /// <summary>
        /// 获取列表
        /// </summary> 
        /// <param name="request"></param> 
        /// <returns></returns>
        public List<object> GetList(BaseRequest<string> request) 
        {
            return GetEntitys(request); 
        }


        /// <summary>
        /// 获取列表
        /// </summary> 
        /// <param name="request"></param> 
        /// <returns></returns>
        public string Save(dynamic request)
        {
            return SaveEntitys(request);
        }
    }
}
