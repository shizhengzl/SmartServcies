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
        public Guid defaultSelfCompany = DefaultCommonEnum.defaultCompany.GetDescription().ToGuid();
        Guid defaultsuppermenuid = DefaultCommonEnum.defaultsuppermenuid.GetDescription().ToGuid();
        Guid defaultsystemmenuid = DefaultCommonEnum.defaultsystemmenuid.GetDescription().ToGuid();

        Guid defaultSelfRole = DefaultCommonEnum.defaultSelfRole.GetDescription().ToGuid();
        Guid defaultCompanyRole = DefaultCommonEnum.defaultCompanyRole.GetDescription().ToGuid();

        Guid defaultSelfUser = DefaultCommonEnum.defaultSelfUser.GetDescription().ToGuid();
        Guid defaultCompanyUser = DefaultCommonEnum.defaultCompanyUser.GetDescription().ToGuid();

        Guid defaultSelfOrganization = DefaultCommonEnum.defaultSelfOrganization.GetDescription().ToGuid();
        Guid defaultOrganization = DefaultCommonEnum.defaultOrganization.GetDescription().ToGuid();


        string defaultSelfCompanyName = DefaultCommonEnum.defaultSelfCompanyName.GetDescription();
        string defaultCompanyName = DefaultCommonEnum.defaultCompanyName.GetDescription();

        public Guid defaultCompanyguid = Guid.Empty;

        public void Init()
        {
            InitMenus();
            InitCompanys();
            InitUsers();


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
            Companys selfcompanys = new Companys() { Id = defaultSelfCompany, CompanyName = defaultSelfCompanyName };
            if (!factory.FreeSql.Select<Companys>().Any(x => x.Id == defaultSelfCompany))
            {
                factory.FreeSql.Insert<Companys>(selfcompanys).ExecuteAffrows();
            }

            Companys defaultcompany = new Companys() { Id = defaultCompanyguid, CompanyName = defaultCompanyName };
            if (!factory.FreeSql.Select<Companys>().Any(x => x.Id == defaultCompanyguid))
            {
                factory.FreeSql.Insert<Companys>(defaultcompany).ExecuteAffrows();
            }

        }
        #endregion

        //#region 初始化单位菜单
        //public void InitCompanyMenus()
        //{
        //    factory.FreeSql.Select<Menus>().Where(x => x.IsDefault).ToList().ForEach(p=> {
        //        CompanyMenus companyMenus = new CompanyMenus() { CompanysId = defaultSelfCompany ,MenusId = p.Id };
        //        factory.FreeSql.Insert<CompanyMenus>(companyMenus).ExecuteAffrows();
        //    });

        //    factory.FreeSql.Select<Menus>().Where(x => x.IsDefault).ToList().ForEach(p => {
        //        CompanyMenus companyMenus = new CompanyMenus() { CompanysId = defaultCompanyguid, MenusId = p.Id };
        //        factory.FreeSql.Insert<CompanyMenus>(companyMenus).ExecuteAffrows();
        //    });

        //    factory.FreeSql.Select<Menus>().Where(x => x.IsSupper).ToList().ForEach(p => {
        //        CompanyMenus companyMenus = new CompanyMenus() { CompanysId = defaultSelfCompany, MenusId = p.Id };
        //        factory.FreeSql.Insert<CompanyMenus>(companyMenus).ExecuteAffrows();
        //    });

        //}
        //#endregion

        #region 初始化用户
        public void InitUsers()
        {
            Users users = new Users()
            {
                Id = defaultCompanyUser,
                UserName = "007admin",
                NikeName = "老王",
                Phone = "13700000000",
                Email = "13700000000@qq.com",
                PassWord = "007admin".Tomd5(),
                IsAdmin = true,
                DefaultCompany = defaultCompanyguid
            };
            if (!factory.FreeSql.Select<Users>().Any(x => x.Id == defaultCompanyUser))
            {
                factory.FreeSql.Insert<Users>(users).ExecuteAffrows();
            }

            Users selfusers = new Users()
            {
                Id = defaultSelfUser,
                UserName = "admin",
                NikeName = "老施",
                Phone = "13701859214",
                Email = "13701859214@qq.com",
                IsAdmin = true,
                PassWord = "admin".Tomd5(),
                DefaultCompany = defaultSelfCompany
            };
            if (!factory.FreeSql.Select<Users>().Any(x => x.Id == defaultSelfUser))
            {
                factory.FreeSql.Insert<Users>(selfusers).ExecuteAffrows();
            }
        }
        #endregion


        #region 初始化角色
        public void InitRole()
        {
            //初始化角色
            Roles roleself = new Roles() {Id = defaultSelfRole , Name = DefaultCommonEnum.defaultRole.GetDescription(), CompanysId = defaultSelfCompany };
            if (!factory.FreeSql.Select<Roles>().Any(x => x.Id == defaultSelfRole && x.CompanysId == defaultSelfCompany))
                factory.FreeSql.Insert<Roles>(roleself).ExecuteAffrows();
            
            Roles roles = new Roles() { Id = defaultCompanyRole, Name = DefaultCommonEnum.defaultRole.GetDescription(), CompanysId = defaultCompanyguid };
            if (!factory.FreeSql.Select<Roles>().Any(x => x.Id == defaultCompanyRole && x.CompanysId == defaultCompanyguid))
                factory.FreeSql.Insert<Roles>(roles).ExecuteAffrows();

            //初始化角色用户
            RoleUsers roleselfUsers = new RoleUsers() { RolesId = defaultSelfRole,UsersId = defaultSelfUser };
            if (!factory.FreeSql.Select<RoleUsers>().Any(x => x.RolesId == defaultSelfRole && x.UsersId == defaultSelfUser))
                factory.FreeSql.Insert<RoleUsers>(roleselfUsers).ExecuteAffrows();

            RoleUsers roleUsers = new RoleUsers() { RolesId = defaultCompanyRole, UsersId = defaultCompanyUser };
            if (!factory.FreeSql.Select<RoleUsers>().Any(x => x.RolesId == defaultCompanyRole && x.UsersId == defaultCompanyUser))
                factory.FreeSql.Insert<RoleUsers>(roleUsers).ExecuteAffrows();

            // 初始化角色菜单
            factory.FreeSql.Select<Menus>().Where(x => x.IsDefault || x.IsSupper).ToList().ForEach(p => {
                RoleMenus roleselfMenus = new RoleMenus() { RolesId = defaultSelfRole, MenusId = p.Id };
                if (!factory.FreeSql.Select<RoleMenus>().Any(x => x.RolesId == defaultSelfRole && x.MenusId == p.Id))
                    factory.FreeSql.Insert<RoleMenus>(roleselfMenus).ExecuteAffrows();
            });

            factory.FreeSql.Select<Menus>().Where(x => x.IsDefault).ToList().ForEach(p => {
                RoleMenus RoleMenus = new RoleMenus() { RolesId = defaultCompanyRole, MenusId = p.Id };
                if (!factory.FreeSql.Select<RoleMenus>().Any(x => x.RolesId == defaultCompanyRole && x.MenusId == p.Id))
                    factory.FreeSql.Insert<RoleMenus>(RoleMenus).ExecuteAffrows();
            });
          
        }


        #endregion

        #region 初始化组织机构
        public void InitOrganization()
        {
            //初始化组织机构
            Organizations organizationself = new Organizations() { Id = defaultSelfOrganization, Name = defaultSelfCompanyName, CompanysId = defaultSelfCompany };
            if (!factory.FreeSql.Select<Organizations>().Any(x => x.Id == defaultSelfOrganization && x.CompanysId == defaultSelfCompany))
                factory.FreeSql.Insert<Organizations>(organizationself).ExecuteAffrows();

            Organizations organization = new Organizations() { Id = defaultOrganization, Name =defaultCompanyName, CompanysId = defaultCompanyguid };
            if (!factory.FreeSql.Select<Organizations>().Any(x => x.Id == defaultOrganization && x.CompanysId == defaultCompanyguid))
                factory.FreeSql.Insert<Organizations>(organization).ExecuteAffrows();

            //初始化组织机构用户
            OrganizationUsers organizationSelfUsers = new OrganizationUsers() { OrganizationsId = defaultOrganization, UsersId = defaultSelfUser };
            if (!factory.FreeSql.Select<OrganizationUsers>().Any(x => x.OrganizationsId == defaultOrganization && x.UsersId == defaultSelfUser))
                factory.FreeSql.Insert<OrganizationUsers>(organizationSelfUsers).ExecuteAffrows();

            OrganizationUsers organizationUsers = new OrganizationUsers() { OrganizationsId = defaultCompanyRole, UsersId = defaultCompanyUser };
            if (!factory.FreeSql.Select<OrganizationUsers>().Any(x => x.OrganizationsId == defaultCompanyRole && x.UsersId == defaultCompanyUser))
                factory.FreeSql.Insert<OrganizationUsers>(organizationUsers).ExecuteAffrows();

            // 初始化组织机构菜单
            factory.FreeSql.Select<Menus>().Where(x => x.IsDefault || x.IsSupper).ToList().ForEach(p => {
                OrganizationMenus organizationselfMenus = new OrganizationMenus() { OraganizationsId = defaultSelfOrganization, MenusId = p.Id };
                if (!factory.FreeSql.Select<OrganizationMenus>().Any(x => x.OraganizationsId == defaultSelfOrganization && x.MenusId == p.Id))
                    factory.FreeSql.Insert<OrganizationMenus>(organizationselfMenus).ExecuteAffrows();
            });

            factory.FreeSql.Select<Menus>().Where(x => x.IsDefault).ToList().ForEach(p => {
                OrganizationMenus organizationMenus = new OrganizationMenus() { OraganizationsId = defaultOrganization, MenusId = p.Id };
                if (!factory.FreeSql.Select<OrganizationMenus>().Any(x => x.OraganizationsId == defaultOrganization && x.MenusId == p.Id))
                    factory.FreeSql.Insert<OrganizationMenus>(organizationMenus).ExecuteAffrows();
            });
        }
        #endregion

    }
}
