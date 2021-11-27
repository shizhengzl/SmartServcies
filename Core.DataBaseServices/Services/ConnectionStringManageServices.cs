using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;

namespace Core.DataBaseServices
{
    public class ConnectionStringManageServices : SystemServices
    {

        public ConnectionStringManageServices() : base(DataBaseFactory.Core_DataBase.FreeSql)
        {

        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<ConnectionString> GetConnections(ConnectionString search)
        {
            var response = GetEntitys<ConnectionString>();
            if (!search.IsNull() && !search.CompanysId.IsNullOrEmpty())
                response = GetEntitys<ConnectionString>().Where(x => x.CompanysId == search.CompanysId);
            return response.ToList();
        } 
    }
}
