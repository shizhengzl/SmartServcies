using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppEntitys
{
    /// <summary>
    /// 初始化数据库
    /// </summary>
    public class InitdataBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public InitdataBase()
        {
            var companyid = Guid.NewGuid();
            var userid = Guid.NewGuid(); 
            InitCompany(companyid, userid);
            InitUser(companyid, userid);
        }
        public string defaultCompanyName = "智能科技云计算技术有限公司";
        public string defaultUserName = "13701859214";
        public FreeSqlFactory factory = new FreeSqlFactory();

        #region 初始化用户
        public void InitUser(Guid companyid, Guid userid)
        {
            if (!factory.FreeSql.Select<Users>().Where(x => x.UserName.Equals(defaultUserName)).Any())
            {
                Users users = new Users()
                {
                    Id = userid,
                    UserName = defaultUserName,
                    DefaultCompany = companyid,
                    CreateTime = DateTime.UtcNow,
                    CreateUserId = userid,
                    Phone = defaultUserName
                };
                factory.FreeSql.Insert<Users>(users).ExecuteAffrows();
            }
        }
        #endregion

        #region 初始化单位
        public void InitCompany(Guid companyid, Guid userid)
        {
            if (!factory.FreeSql.Select<Companys>().Where(x => x.CompanyName.Equals(defaultCompanyName)).Any())
            {
                Companys companys = new Companys()
                {
                    CompanyName = defaultCompanyName,
                    Id = companyid,
                    CreateTime = DateTime.UtcNow,
                    CreateUserId = userid
                }; 
                factory.FreeSql.Insert<Companys>(companys).ExecuteAffrows();
            }
        }
        #endregion
    }
}
