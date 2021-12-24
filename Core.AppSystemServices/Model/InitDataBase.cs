using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;
using System.Linq;
using Core.DataBaseServices;

namespace Core.AppSystemServices
{
    public class InitDataBase
    {
        public InitDataBase()
        {
            ClearTable();
            Init();
        }

        public void ClearTable()
        {

            DataBaseFactory.Core_Application.FreeSql.Ado.ExecuteNonQuery(CommonSQL.ClearTableSql);
        }

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
            InitBaseData();
            InitMenus();
            InitCompanys();
            InitUsers();

            InitConnection();

            InitRole(defaultSelfCompany, defaultSelfUser, defaultSelfRole);
            InitRole(defaultCompanyguid, defaultCompanyUser, defaultCompanyRole);
            InitOrganization(defaultSelfCompany, defaultSelfUser, defaultSelfOrganization, defaultSelfCompanyName);
            InitOrganization(defaultCompanyguid, defaultCompanyUser, defaultOrganization, defaultCompanyName);
            InitCompanyMenuAndUser(defaultSelfCompany, defaultSelfUser);
            InitCompanyMenuAndUser(defaultCompanyguid, defaultCompanyUser);
        }
        #region 初始化菜单
        public void InitMenus()
        {

            Menus menus = new Menus()
            {
                Id = defaultsuppermenuid,
                IsSupper = true,
                MenuName = "系统管理",
                Component = "Layout" ,
                Path = "system",
                MenuIcon = "404",
                MenusId = Guid.Empty,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "系统管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menus).ExecuteAffrows();
            }

            Menus menucompanys = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true ,
                MenuName = "菜单管理" ,
                Sort = 1 ,
                Path = "menus" ,
                MenuIcon = "404" ,
                Component = $"/menus/index" ,
                MenusId = defaultsuppermenuid,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "菜单管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys).ExecuteAffrows();
            }

            Menus menucompanys2 = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true ,
                MenuName = "角色用户",
                Sort = 1,
                Path = "roleusers" ,
                MenuIcon = "404",
                Component = $"/snippet/gridgrid",
                MenusId = defaultsuppermenuid,
                CompanysId = defaultCompanyguid,
                SourceValue = "Roles",
                TargetSource = "Table",
                RightSourceValue = "RoleUsers",
                RightTargetSource = "Table"
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "角色用户"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys2).ExecuteAffrows();
            }


            Menus menucompanys8 = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "机构用户",
                Sort = 1,
                Path = "organizationusers",
                MenuIcon = "404",
                Component = $"/snippet/treegird",
                MenusId = defaultsuppermenuid,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "机构用户"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys8).ExecuteAffrows();
            }


            Menus menucompanys3 = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true  ,
                MenuName = "用户管理"  ,
                Sort = 1  ,
                Path = "users"  ,
                TargetSource = "Table"  ,
                SourceValue = "Users"  ,
                MenuIcon = "404"  ,
                Component = $"/application/users"  ,
                MenusId = defaultsuppermenuid,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "用户管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys3).ExecuteAffrows();
            }


            Menus menucompanys4 = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "基础数据",
                Sort = 1,
                Path = "basedata",
                TargetSource = "" ,
                SourceValue = "",
                MenuIcon = "404",
                Component = $"/application/basedata",
                MenusId = defaultsuppermenuid,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "基础数据"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys4).ExecuteAffrows();
            }


            Menus menucompanys5 = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "角色管理",
                Sort = 1,
                Path = "roles",
                TargetSource = "Table",
                SourceValue = "Roles",
                MenuIcon = "404",
                Component = $"/snippet/grid",
                MenusId = defaultsuppermenuid,
                CompanysId = defaultCompanyguid,
                ShowCreate = true
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "角色管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys5).ExecuteAffrows();
            }

            Menus menucompanys6 = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "机构管理",
                Sort = 1,
                Path = "organizations",
                TargetSource = "Table",
                SourceValue = "Organizations",
                MenuIcon = "404",
                Component = $"/snippet/tree",
                MenusId = defaultsuppermenuid,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "机构管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys6).ExecuteAffrows();
            }

            Menus menucompanys7 = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "单位管理",
                Sort = 1,
                Path = "companys",
                TargetSource = "Table",
                SourceValue = "Companys",
                MenuIcon = "404",
                Component = $"/application/common",
                MenusId = defaultsuppermenuid,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "单位管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys7).ExecuteAffrows();
            }



            //Menus menuusers = new Menus() { Id = Guid.NewGuid(), IsSupper = true, MenuName = "超级用户管理", Sort = 2, Component = typeof(Users).Name, MenusId = defaultsuppermenuid };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "超级用户管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menuusers).ExecuteAffrows();
            //}

            //Menus menumenus = new Menus() { Id = Guid.NewGuid(), IsSupper = true, MenuName = "超级菜单管理", Sort = 3, Component = typeof(Menus).Name, MenusId = defaultsuppermenuid };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "超级菜单管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menumenus).ExecuteAffrows();
            //}

            //Menus menugrant = new Menus() { Id = Guid.NewGuid(), IsSupper = true, MenuName = "超级授权管理", Sort = 4, Component = "Grant", MenusId = defaultsuppermenuid };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "超级授权管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menugrant).ExecuteAffrows();
            //}


            //Menus companymenus = new Menus() { Id = defaultsystemmenuid,IsDefault = true, MenuName = "系统管理", MenusId = Guid.Empty };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "系统管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(companymenus).ExecuteAffrows();
            //}

            //Menus companymenucompanys = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "单位管理", Sort = 1, Component = typeof(Companys).Name, MenusId = defaultsystemmenuid };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "单位管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(companymenucompanys).ExecuteAffrows();
            //}

            //Menus companymenuusers = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "用户管理", Sort = 2, Component = typeof(Users).Name, MenusId = defaultsystemmenuid };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "用户管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(companymenuusers).ExecuteAffrows();
            //}

            //Menus companymenumenus = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "菜单管理", Sort = 3, Component = typeof(Menus).Name, MenusId = defaultsystemmenuid };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "菜单管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(companymenumenus).ExecuteAffrows();
            //}

            //Menus companygrant = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "菜单授权", Sort = 4, Component = "Grant", IsAuto = false, MenusId = defaultsystemmenuid };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "菜单授权"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(companygrant).ExecuteAffrows();
            //}


            //Menus companyrole = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "角色管理", Sort = 5, Component = typeof(Roles).Name, MenusId = defaultsystemmenuid };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "角色管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(companyrole).ExecuteAffrows();
            //}

            //Menus companyorganzition = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "组织机构管理", Sort = 6, Component = typeof(Organizations).Name, MenusId = defaultsystemmenuid };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "组织机构管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(companyorganzition).ExecuteAffrows();
            //}





            //Menus softtoolsmenus = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "研发管理", MenusId = Guid.Empty };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "研发管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(softtoolsmenus).ExecuteAffrows();
            //}

            //var father = DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Where(x => x.MenuName == "研发管理").ToList<Menus>().FirstOrDefault();

            //Menus codesnippet = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Component = "CodeSnippet", MenuName = "生成模板", MenusId = father.Id };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "生成模板"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(codesnippet).ExecuteAffrows();
            //}

            //Menus codegenerator = new Menus() { Id = Guid.NewGuid(), IsDefault = true,IsAuto = false, Component = "CodeGenerator", MenuName = "生成代码", MenusId = father.Id };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "生成代码"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(codegenerator).ExecuteAffrows();
            //}


            //Menus snippet = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Component = "SnippetRecord", MenuName = "代码片段", MenusId = father.Id };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "代码片段"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(snippet).ExecuteAffrows();
            //}

            //Menus connectionstring = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Component = "ConnectionStringManage", MenuName = "数据库连接管理", MenusId = father.Id };
            //if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "数据库连接管理"))
            //{
            //    DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(connectionstring).ExecuteAffrows();
            //}



            var sorttool = Guid.NewGuid();
            Menus sorttoolmenus = new Menus()
            {
                Id = sorttool,
                IsSupper = true,
                MenuName = "研发工具",
                Component = "Layout",
                Path = "soft",
                MenuIcon = "404",
                MenusId = Guid.Empty,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "研发工具"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(sorttoolmenus).ExecuteAffrows();
            }


            Menus connectionmenus = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "连接管理",
                Sort = 1,
                Path = "connection",
                TargetSource = "Table",
                SourceValue = "ConnectionString",
                MenuIcon = "404",
                Component = $"/soft/connection",
                MenusId = sorttool,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "连接管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(connectionmenus).ExecuteAffrows();
            }

            Menus filedmenus = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "数据库字段",
                Sort = 1,
                Path = "datafileld",
                TargetSource = "",
                SourceValue = "",
                MenuIcon = "404",
                Component = $"/soft/datafileld",
                MenusId = sorttool,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "数据库字段"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(filedmenus).ExecuteAffrows();
            }



            var logmenuid = Guid.NewGuid();
            Menus logmenulmenus = new Menus()
            {
                Id = logmenuid,
                IsSupper = true,
                MenuName = "日志管理",
                Component = "Layout",
                Path = "log",
                MenuIcon = "404",
                MenusId = Guid.Empty,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "日志管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(logmenulmenus).ExecuteAffrows();
            }


            Menus requestlog = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "请求日志",
                Sort = 1,
                Path = "requestreponselog",
                TargetSource = "Table",
                SourceValue = "RequestResponseLogs",
                MenuIcon = "404",
                Component = $"/log/requestreponselog",
                MenusId = logmenuid,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "请求日志"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(requestlog).ExecuteAffrows();
            }

            Menus execptions = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "异常日志",
                Sort = 1,
                Path = "exceptionlogs",
                TargetSource = "Table",
                SourceValue = "ExceptionLogs",
                MenuIcon = "404",
                Component = $"/log/exceptionlogs",
                MenusId = logmenuid,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "异常日志"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(execptions).ExecuteAffrows();
            }

            Menus opeartionlog = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "操作日志",
                Sort = 1,
                Path = "opeartionlogs",
                TargetSource = "Table",
                SourceValue = "OpeartionLogs",
                MenuIcon = "404",
                Component = $"/log/opeartionlogs",
                MenusId = logmenuid,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "操作日志"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(opeartionlog).ExecuteAffrows();
            }

            Menus sqllogmenus = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "SQL日志",
                Sort = 1,
                Path = "sqllogs",
                TargetSource = "Table",
                SourceValue = "SQLLogs",
                MenuIcon = "404",
                Component = $"/log/sqllogs",
                MenusId = logmenuid,
                CompanysId = defaultCompanyguid
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "SQL日志"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(sqllogmenus).ExecuteAffrows();
            }
        }
        #endregion

        #region 初始化单位
        public void InitCompanys()
        {
            Companys selfcompanys = new Companys() { Id = defaultSelfCompany, CompanyName = defaultSelfCompanyName };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Companys>().Any(x => x.Id == defaultSelfCompany))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Companys>(selfcompanys).ExecuteAffrows();
            }

            Companys defaultcompany = new Companys() { Id = defaultCompanyguid, CompanyName = defaultCompanyName };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Companys>().Any(x => x.Id == defaultCompanyguid))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Companys>(defaultcompany).ExecuteAffrows();
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
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Users>().Any(x => x.Id == defaultCompanyUser))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Users>(users).ExecuteAffrows();
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
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Users>().Any(x => x.Id == defaultSelfUser))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Users>(selfusers).ExecuteAffrows();
            }
        }
        #endregion

        #region 初始化角色
        public void InitRole(Guid companyid, Guid userid, Guid? defaultroleid = null)
        {
            var id = defaultroleid.HasValue ? defaultroleid.Value : defaultSelfRole;
            //初始化角色
            Roles roleself = new Roles() { Id = id, Name = DefaultCommonEnum.defaultRole.GetDescription(), CompanysId = companyid };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Roles>().Any(x => x.Id == id && x.CompanysId == companyid))
                DataBaseFactory.Core_Application.FreeSql.Insert<Roles>(roleself).ExecuteAffrows();

            //初始化角色用户
            RoleUsers roleselfUsers = new RoleUsers() { CompanysId = companyid, RolesId = id, UsersId = userid };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<RoleUsers>().Any(x => x.RolesId == id && x.UsersId == userid))
                DataBaseFactory.Core_Application.FreeSql.Insert<RoleUsers>(roleselfUsers).ExecuteAffrows();

            // 初始化角色菜单
            DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Where(x => !!x.IsDefault).ToList().ForEach(p =>
            {
                RoleMenus roleselfMenus = new RoleMenus() { CompanysId = companyid, RolesId = id, MenusId = p.Id };
                if (!DataBaseFactory.Core_Application.FreeSql.Select<RoleMenus>().Any(x => x.RolesId == id && x.MenusId == p.Id))
                    DataBaseFactory.Core_Application.FreeSql.Insert<RoleMenus>(roleselfMenus).ExecuteAffrows();
            });

        }
        #endregion

        #region 初始化组织机构
        public void InitOrganization(Guid companyid, Guid userid, Guid? defaultorganizationid = null, string OrganizationName = "")
        {
            var id = defaultorganizationid.HasValue ? defaultorganizationid.Value : defaultSelfOrganization;
            //初始化组织机构
            Organizations organizationself = new Organizations() { Id = id, Name = OrganizationName, CompanysId = companyid, ParentId = Guid.Empty };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Organizations>().Any(x => x.Id == id && x.CompanysId == companyid))
                DataBaseFactory.Core_Application.FreeSql.Insert<Organizations>(organizationself).ExecuteAffrows();


            //初始化组织机构用户
            OrganizationUsers organizationSelfUsers = new OrganizationUsers() { CompanysId = companyid, OrganizationsId = defaultOrganization, UsersId = userid };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<OrganizationUsers>().Any(x => x.OrganizationsId == defaultOrganization && x.UsersId == userid))
                DataBaseFactory.Core_Application.FreeSql.Insert<OrganizationUsers>(organizationSelfUsers).ExecuteAffrows();


            // 初始化组织机构菜单
            DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Where(x => !!x.IsDefault).ToList().ForEach(p =>
            {
                OrganizationMenus organizationselfMenus = new OrganizationMenus() { CompanysId = companyid, OraganizationsId = id, MenusId = p.Id };
                if (!DataBaseFactory.Core_Application.FreeSql.Select<OrganizationMenus>().Any(x => x.OraganizationsId == id && x.MenusId == p.Id))
                    DataBaseFactory.Core_Application.FreeSql.Insert<OrganizationMenus>(organizationselfMenus).ExecuteAffrows();
            });

        }
        #endregion

        #region 初始化单位菜单和用户
        public void InitCompanyMenuAndUser(Guid companyid, Guid userid)
        {
            //初始单位用户
            CompanyUsers companyselfUsers = new CompanyUsers() { CompanysId = companyid, UsersId = userid };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<CompanyUsers>().Any(x => x.CompanysId == companyid && x.UsersId == userid))
                DataBaseFactory.Core_Application.FreeSql.Insert<CompanyUsers>(companyselfUsers).ExecuteAffrows();

            // 初始单位菜单
            DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Where(x => !!x.IsDefault).ToList().ForEach(p =>
            {
                CompanyMenus companyselfMenus = new CompanyMenus() { CompanysId = companyid, MenusId = p.Id };
                if (!DataBaseFactory.Core_Application.FreeSql.Select<CompanyMenus>().Any(x => x.CompanysId == companyid && x.MenusId == p.Id))
                    DataBaseFactory.Core_Application.FreeSql.Insert<CompanyMenus>(companyselfMenus).ExecuteAffrows();
            });
        }
        #endregion

        #region 初始化基础数据
        public void InitBaseData()
        {

            InitEnum(typeof(SexEnum), true);
            InitEnum(typeof(BooleanEnum), true);
            InitEnum(typeof(ColumnDataAlignEnum));
            InitEnum(typeof(ValidTypeEnum));

        }


        public void InitEnum(Type enumtype, bool getValue = false)
        {
            Guid baseid = Guid.NewGuid();
            var name = enumtype.Name.Replace("Enum", String.Empty);
            if (!DataBaseFactory.Core_Application.FreeSql.Select<BaseData>().Any(x => x.Code == name))
            {
                BaseData basedata = new BaseData()
                {
                    Id = baseid,
                    Code = enumtype.Name.Replace("Enum", String.Empty),
                    Name = enumtype.GetClassOrEnumDescription(),
                    Description = enumtype.GetClassOrEnumDescription(),
                    CompanysId = defaultSelfCompany
                };
                DataBaseFactory.Core_Application.FreeSql.Insert<BaseData>(basedata).ExecuteAffrows();
                enumtype.GetListEnumClass().ForEach(x =>
                {
                    BaseDataDetail basedatatetail = new BaseDataDetail()
                    {
                        Code = (getValue ? (x.Keys).ToString() : x.Name.ToStringExtension()),
                        Name = x.Description.ToStringExtension(),
                        Description = x.Description.ToStringExtension(),
                        BaseDataId = baseid,
                        CompanysId = defaultSelfCompany
                    };
                    DataBaseFactory.Core_Application.FreeSql.Insert<BaseDataDetail>(basedatatetail).ExecuteAffrows();
                });
            }
        }


        #endregion

        #region 初始化连接字符串
        public void InitConnection()
        {

            ConnectionString connectionString = new ConnectionString()
            {
                Address = "192.168.0.100",
                DataType = FreeSql.DataType.SqlServer,
                IsWindows = false,
                UserIds = "u_temp",
                Password = "3GfnOA#hbz%aRWR7njM&",
                CompanysId = DefaultCommonEnum.defaulfSelfCompany.GetDescription().ToGuid()
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<ConnectionString>().Any(x => x.Address == "192.168.0.100"))
                DataBaseFactory.Core_Application.FreeSql.Insert<ConnectionString>(connectionString).ExecuteAffrows();
        }
        #endregion
    }
}
