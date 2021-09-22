using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;

namespace Core.DataBaseServices
{
    public class ConnectionStringManageServices : SystemServices
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<ConnectionStringManage> GetConnections(ConnectionStringManage search)
        {
            var response = GetEntitys<ConnectionStringManage>();
            if (!search.IsNull() && !search.CompanysId.IsNullOrEmpty())
                response = GetEntitys<ConnectionStringManage>().Where(x => x.CompanysId == search.CompanysId);
            return response.ToList();
        } 
    }
}
