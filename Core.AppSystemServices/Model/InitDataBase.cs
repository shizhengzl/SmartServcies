using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;

namespace Core.AppSystemServices
{
    public class InitDataBase
    {

        public FreeSqlFactory factory = new FreeSqlFactory();
        public Guid companyId = DefaultCommonEnum.defaultCompany.GetDescription().ToGuid();
        Guid defaultsuppermenuid = DefaultCommonEnum.defaultsuppermenuid.GetDescription().ToGuid();
        Guid defaultsystemmenuid = DefaultCommonEnum.defaultsystemmenuid.GetDescription().ToGuid();

        public Guid defaultguid = Guid.Empty;

        public void Init()
        {
            InitMenus();
            InitCompanys();
            InitUsers();
            InitCompanyMenus();
        }
        #region 初始化菜单
        public void InitMenus()
        {

            Menus menus = new Menus() { Id = defaultsuppermenuid,IsSupper=true, Name = "超级系统管理", MenusId = Guid.Empty };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "超级系统管理"))
            {
                factory.FreeSql.Insert<Menus>(menus).ExecuteAffrows();
            }

            Menus menucompanys = new Menus() { Id = Guid.NewGuid(), IsSupper = true, Name = "超级单位管理", Sort = 1, Url = typeof(Companys).Name, MenusId = defaultsuppermenuid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "超级单位管理"))
            {
                factory.FreeSql.Insert<Menus>(menucompanys).ExecuteAffrows();
            }

            Menus menuusers = new Menus() { Id = Guid.NewGuid(), IsSupper = true, Name = "超级用户管理", Sort = 2, Url = typeof(Users).Name, MenusId = defaultsuppermenuid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "超级用户管理"))
            {
                factory.FreeSql.Insert<Menus>(menuusers).ExecuteAffrows();
            }

            Menus menumenus = new Menus() { Id = Guid.NewGuid(), IsSupper = true, Name = "超级菜单管理", Sort = 3, Url = typeof(Menus).Name, MenusId = defaultsuppermenuid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "超级菜单管理"))
            {
                factory.FreeSql.Insert<Menus>(menumenus).ExecuteAffrows();
            }


            Menus companymenus = new Menus() { Id = defaultsystemmenuid,IsDefault = true, Name = "系统管理", MenusId = Guid.Empty };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "系统管理"))
            {
                factory.FreeSql.Insert<Menus>(companymenus).ExecuteAffrows();
            }

            Menus companymenucompanys = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Name = "单位管理", Sort = 1, Url = typeof(Companys).Name, MenusId = defaultsystemmenuid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "单位管理"))
            {
                factory.FreeSql.Insert<Menus>(companymenucompanys).ExecuteAffrows();
            }

            Menus companymenuusers = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Name = "用户管理", Sort = 2, Url = typeof(Users).Name, MenusId = defaultsystemmenuid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "用户管理"))
            {
                factory.FreeSql.Insert<Menus>(companymenuusers).ExecuteAffrows();
            }

            Menus companymenumenus = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Name = "菜单管理", Sort = 3, Url = typeof(Menus).Name, MenusId = defaultsystemmenuid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "菜单管理"))
            {
                factory.FreeSql.Insert<Menus>(companymenumenus).ExecuteAffrows();
            }
        }
        #endregion

        #region 初始化单位
        public void InitCompanys()
        {
            Companys selfcompanys = new Companys() { Id = companyId, CompanyName = "智能科技云计算技术有限公司" };
            if (!factory.FreeSql.Select<Companys>().Any(x => x.CompanyName == "智能科技云计算技术有限公司"))
            {
                factory.FreeSql.Insert<Companys>(selfcompanys).ExecuteAffrows();
            }

            Companys defaultcompany = new Companys() { Id = defaultguid, CompanyName = "隔壁老王管理公司" };
            if (!factory.FreeSql.Select<Companys>().Any(x => x.CompanyName == "隔壁老王管理公司"))
            {
                factory.FreeSql.Insert<Companys>(defaultcompany).ExecuteAffrows();
            }

        }
        #endregion

        #region 初始化单位菜单
        public void InitCompanyMenus()
        {
            factory.FreeSql.Select<Menus>().Where(x => x.IsDefault).ToList().ForEach(p=> {
                CompanyMenus companyMenus = new CompanyMenus() { CompanysId = companyId ,MenusId = p.Id };
                factory.FreeSql.Insert<CompanyMenus>(companyMenus).ExecuteAffrows();
            });

            factory.FreeSql.Select<Menus>().Where(x => x.IsDefault).ToList().ForEach(p => {
                CompanyMenus companyMenus = new CompanyMenus() { CompanysId = defaultguid, MenusId = p.Id };
                factory.FreeSql.Insert<CompanyMenus>(companyMenus).ExecuteAffrows();
            });

            factory.FreeSql.Select<Menus>().Where(x => x.IsSupper).ToList().ForEach(p => {
                CompanyMenus companyMenus = new CompanyMenus() { CompanysId = companyId, MenusId = p.Id };
                factory.FreeSql.Insert<CompanyMenus>(companyMenus).ExecuteAffrows();
            });

        }
        #endregion

        #region 初始化用户
        public void InitUsers()
        {
            Users users = new Users()
            {
                Id = Guid.NewGuid(),
                UserName = "007admin",
                NikeName = "老王",
                Phone = "13700000000",
                Email = "13700000000@qq.com",
                PassWord = "007admin".Tomd5(),
                IsAdmin = true,
                DefaultCompany = defaultguid
            };
            if (!factory.FreeSql.Select<Users>().Any(x => x.UserName == users.UserName))
            {
                factory.FreeSql.Insert<Users>(users).ExecuteAffrows();
            }

            Users selfusers = new Users()
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                NikeName = "老施",
                Phone = "13701859214",
                Email = "13701859214@qq.com",
                IsAdmin = true,
                PassWord = "admin".Tomd5(),
                DefaultCompany = companyId
            };
            if (!factory.FreeSql.Select<Users>().Any(x => x.UserName == selfusers.UserName))
            {
                factory.FreeSql.Insert<Users>(selfusers).ExecuteAffrows();
            }
        }
        #endregion


        #region 初始化角色
        Roles roles = new Roles() { Name = DefaultCommonEnum.defaultRole.GetDescription() };
        #endregion

        #region 初始化组织机构

        #endregion

    }
}
