using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;
using System.Linq;

namespace Core.AppSystemServices
{
    public class InitDataBase
    {

        public FreeSqlFactory factory = new FreeSqlFactory();
        public Guid defaultSelfCompany = DefaultCommonEnum.defaulfSelfCompany.GetDescription().ToGuid();


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

        public Guid defaultCompanyguid = DefaultCommonEnum.defaultCompany.GetDescription().ToGuid();

        public void Init()
        {
            InitMenus();
            InitCompanys();
            InitUsers();

            InitRole(defaultSelfCompany,defaultSelfUser,defaultSelfRole);
            InitRole(defaultCompanyguid, defaultCompanyUser,defaultCompanyRole);
            InitOrganization(defaultSelfCompany, defaultSelfUser,defaultSelfOrganization,defaultSelfCompanyName);
            InitOrganization(defaultCompanyguid, defaultCompanyUser, defaultOrganization,defaultCompanyName);
            InitCompanyMenuAndUser(defaultSelfCompany, defaultSelfUser);
            InitCompanyMenuAndUser(defaultCompanyguid, defaultCompanyUser);
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

            Menus menugrant = new Menus() { Id = Guid.NewGuid(), IsSupper = true, Name = "超级授权管理", Sort = 4, Url = "Grant", MenusId = defaultsuppermenuid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "超级授权管理"))
            {
                factory.FreeSql.Insert<Menus>(menugrant).ExecuteAffrows();
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

            Menus companygrant = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Name = "菜单授权", Sort = 4, Url = "Grant", IsAuto = false, MenusId = defaultsystemmenuid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "菜单授权"))
            {
                factory.FreeSql.Insert<Menus>(companygrant).ExecuteAffrows();
            }


            Menus companyrole = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Name = "角色管理", Sort = 5, Url = typeof(Roles).Name, MenusId = defaultsystemmenuid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "角色管理"))
            {
                factory.FreeSql.Insert<Menus>(companyrole).ExecuteAffrows();
            }

            Menus companyorganzition = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Name = "组织机构管理", Sort = 6, Url = typeof(Organizations).Name, MenusId = defaultsystemmenuid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "组织机构管理"))
            {
                factory.FreeSql.Insert<Menus>(companyorganzition).ExecuteAffrows();
            }





            Menus softtoolsmenus = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Name = "研发管理", MenusId = Guid.Empty };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "研发管理"))
            {
                factory.FreeSql.Insert<Menus>(softtoolsmenus).ExecuteAffrows();
            }

            var father = factory.FreeSql.Select<Menus>().Where(x => x.Name == "研发管理").ToList<Menus>().FirstOrDefault();

            Menus codesnippet = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Url = "CodeSnippet", Name = "生成模板", MenusId = father.Id };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "生成模板"))
            {
                factory.FreeSql.Insert<Menus>(codesnippet).ExecuteAffrows();
            }

            Menus codegenerator = new Menus() { Id = Guid.NewGuid(), IsDefault = true,IsAuto = false, Url = "CodeGenerator", Name = "生成代码", MenusId = father.Id };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "生成代码"))
            {
                factory.FreeSql.Insert<Menus>(codegenerator).ExecuteAffrows();
            }


            Menus snippet = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Url = "SnippetRecord", Name = "代码片段", MenusId = father.Id };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "代码片段"))
            {
                factory.FreeSql.Insert<Menus>(snippet).ExecuteAffrows();
            }

            Menus connectionstring = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Url = "ConnectionStringManage", Name = "数据库连接管理", MenusId = father.Id };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "数据库连接管理"))
            {
                factory.FreeSql.Insert<Menus>(connectionstring).ExecuteAffrows();
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
                CompanysId = defaultCompanyguid
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
                CompanysId = defaultSelfCompany
            };
            if (!factory.FreeSql.Select<Users>().Any(x => x.Id == defaultSelfUser))
            {
                factory.FreeSql.Insert<Users>(selfusers).ExecuteAffrows();
            }
        }
        #endregion

        #region 初始化角色
        public void InitRole(Guid companyid,Guid userid,Guid? defaultroleid = null)
        {
            var id = defaultroleid.HasValue ? defaultroleid.Value : defaultSelfRole;
            //初始化角色
            Roles roleself = new Roles() { Id = id , Name = DefaultCommonEnum.defaultRole.GetDescription(), CompanysId = companyid };
            if (!factory.FreeSql.Select<Roles>().Any(x => x.Id == id && x.CompanysId == companyid))
                factory.FreeSql.Insert<Roles>(roleself).ExecuteAffrows(); 

            //初始化角色用户
            RoleUsers roleselfUsers = new RoleUsers() { CompanysId = companyid, RolesId = id,UsersId = userid };
            if (!factory.FreeSql.Select<RoleUsers>().Any(x => x.RolesId == id && x.UsersId == userid))
                factory.FreeSql.Insert<RoleUsers>(roleselfUsers).ExecuteAffrows(); 

            // 初始化角色菜单
            factory.FreeSql.Select<Menus>().Where(x => !!x.IsDefault).ToList().ForEach(p => {
                RoleMenus roleselfMenus = new RoleMenus() {CompanysId = companyid, RolesId = id, MenusId = p.Id };
                if (!factory.FreeSql.Select<RoleMenus>().Any(x => x.RolesId == id && x.MenusId == p.Id))
                    factory.FreeSql.Insert<RoleMenus>(roleselfMenus).ExecuteAffrows();
            }); 
          
        } 
        #endregion

        #region 初始化组织机构
        public void InitOrganization(Guid companyid,Guid userid,Guid? defaultorganizationid = null,string OrganizationName="")
        {
            var id = defaultorganizationid.HasValue ? defaultorganizationid.Value : defaultSelfOrganization;
            //初始化组织机构
            Organizations organizationself = new Organizations() { Id = id, Name = OrganizationName, CompanysId = companyid };
            if (!factory.FreeSql.Select<Organizations>().Any(x => x.Id == id && x.CompanysId == companyid))
                factory.FreeSql.Insert<Organizations>(organizationself).ExecuteAffrows();


            //初始化组织机构用户
            OrganizationUsers organizationSelfUsers = new OrganizationUsers() {CompanysId = companyid, OrganizationsId = defaultOrganization, UsersId = userid };
            if (!factory.FreeSql.Select<OrganizationUsers>().Any(x => x.OrganizationsId == defaultOrganization && x.UsersId == userid))
                factory.FreeSql.Insert<OrganizationUsers>(organizationSelfUsers).ExecuteAffrows();


            // 初始化组织机构菜单
            factory.FreeSql.Select<Menus>().Where(x => !!x.IsDefault).ToList().ForEach(p => {
                OrganizationMenus organizationselfMenus = new OrganizationMenus() {CompanysId = companyid,  OraganizationsId = id, MenusId = p.Id };
                if (!factory.FreeSql.Select<OrganizationMenus>().Any(x => x.OraganizationsId == id && x.MenusId == p.Id))
                    factory.FreeSql.Insert<OrganizationMenus>(organizationselfMenus).ExecuteAffrows();
            });

        }
        #endregion

        #region 初始化单位菜单和用户
        public void InitCompanyMenuAndUser(Guid companyid, Guid userid)
        {
            //初始单位用户
            CompanyUsers companyselfUsers = new CompanyUsers() { CompanysId = companyid, UsersId = userid };
            if (!factory.FreeSql.Select<CompanyUsers>().Any(x => x.CompanysId == companyid && x.UsersId == userid))
                factory.FreeSql.Insert<CompanyUsers>(companyselfUsers).ExecuteAffrows(); 

            // 初始单位菜单
            factory.FreeSql.Select<Menus>().Where(x => !!x.IsDefault).ToList().ForEach(p => {
                CompanyMenus companyselfMenus = new CompanyMenus() { CompanysId = companyid, MenusId = p.Id };
                if (!factory.FreeSql.Select<CompanyMenus>().Any(x => x.CompanysId == companyid && x.MenusId == p.Id))
                    factory.FreeSql.Insert<CompanyMenus>(companyselfMenus).ExecuteAffrows();
            });
        }
        #endregion

    }
}
