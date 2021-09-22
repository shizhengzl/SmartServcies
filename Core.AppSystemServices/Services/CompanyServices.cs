using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.FreeSqlServices;
using Core.UsuallyCommon;
namespace Core.AppSystemServices
{
    /// <summary>
    /// 单位服务
    /// </summary>
    public class CompanyServices : SystemServices
    {
        /// <summary>
        /// 获取单位
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<Companys> GetCompanys(Companys search = null)
        {
            var response = GetEntitys<Companys>();

            if (!search.IsNull() && search.CompanyName.IsNullOrEmpty())
                response = response.Where(x => x.CompanyName.Contains(search.CompanyName));
            return response.ToList();
        }




        /// <summary>
        /// 获取单位菜单
        /// </summary>
        public List<Menus> GetCompanyMenus(Companys company)
        { 
            var menus = GetEntitys<CompanyMenus>().Where(x => x.CompanysId == company.Id).ToList().Select(p => p.MenusId.ToString().ToUpper()).ToList();
            return GetEntitys<Menus>().Where(x => menus.Contains(x.Id.ToString().ToUpper())).ToList();
        }

        /// <summary>
        /// 保存单位菜单
        /// </summary>
        /// <param name="menus"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public Boolean SaveCompanyMenus(List<Menus> menus, Companys company)
        {
            var response = true;
            // 删除原来所有单位
            var companyMenus = GetEntitys<CompanyMenus>().Where(x => x.CompanysId == company.Id).ToList();
            companyMenus.ForEach(x =>
            {
                Remove<CompanyMenus>(x);
            });


            menus.ForEach(x => {
                Create<CompanyMenus>(new CompanyMenus() { CompanysId = company.Id, MenusId = x.Id });
            });

            return response;
        }
    }
}
