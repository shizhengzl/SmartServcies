﻿using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;
using System.Linq;

namespace Core.AppSystemServices
{
    public class InitDataBase
    {
        
        public InitDataBase()
        {
            Init();
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

            Menus menus = new Menus() { Id = defaultsuppermenuid,IsSupper=true
                , MenuName = "超级系统管理"
                , Component = "Layout"
                , Path = "table"
                , MenuIcon = "404"
                , MenusId = Guid.Empty };
            if (!FreeSqlFactory.FreeSql.Select<Menus>().Any(x => x.MenuName == "超级系统管理"))
            {
                FreeSqlFactory.FreeSql.Insert<Menus>(menus).ExecuteAffrows();
            }

            Menus menucompanys = new Menus() { Id = Guid.NewGuid(), IsSupper = true
                , MenuName = "超级菜单管理"
                , Sort = 1
                , Path = "menus"
                , MenuIcon = "404"
                , Component = $"/menus/index"// +  typeof(Companys).Name.ToLower()
                , MenusId = defaultsuppermenuid };
            if (!FreeSqlFactory.FreeSql.Select<Menus>().Any(x => x.MenuName == "超级菜单管理"))
            {
                FreeSqlFactory.FreeSql.Insert<Menus>(menucompanys).ExecuteAffrows();
            }

            Menus menucompanys2 = new Menus() { Id = Guid.NewGuid(), IsSupper = true
                , MenuName = "列表页面"
                , Sort = 1
                , Path = "list"
                , MenuIcon = "404"
                , Component = $"/menus/list"// +  typeof(Companys).Name.ToLower()
                , MenusId = defaultsuppermenuid };
            if (!FreeSqlFactory.FreeSql.Select<Menus>().Any(x => x.MenuName == "组件页面"))
            {
                FreeSqlFactory.FreeSql.Insert<Menus>(menucompanys2).ExecuteAffrows();
            }


               Menus menucompanys3 = new Menus() { Id = Guid.NewGuid(), IsSupper = true
                , MenuName = "编辑页面"
                , Sort = 1
                , Path = "editor"
                , MenuIcon = "404"
                , Component = $"/menus/editor"// +  typeof(Companys).Name.ToLower()
                , MenusId = defaultsuppermenuid };
            if (!FreeSqlFactory.FreeSql.Select<Menus>().Any(x => x.MenuName == "编辑页面"))
            {
                FreeSqlFactory.FreeSql.Insert<Menus>(menucompanys3).ExecuteAffrows();
            }


            //Menus menuusers = new Menus() { Id = Guid.NewGuid(), IsSupper = true, MenuName = "超级用户管理", Sort = 2, Component = typeof(Users).Name, MenusId = defaultsuppermenuid };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "超级用户管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(menuusers).ExecuteAffrows();
            //}

            //Menus menumenus = new Menus() { Id = Guid.NewGuid(), IsSupper = true, MenuName = "超级菜单管理", Sort = 3, Component = typeof(Menus).Name, MenusId = defaultsuppermenuid };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "超级菜单管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(menumenus).ExecuteAffrows();
            //}

            //Menus menugrant = new Menus() { Id = Guid.NewGuid(), IsSupper = true, MenuName = "超级授权管理", Sort = 4, Component = "Grant", MenusId = defaultsuppermenuid };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "超级授权管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(menugrant).ExecuteAffrows();
            //}


            //Menus companymenus = new Menus() { Id = defaultsystemmenuid,IsDefault = true, MenuName = "系统管理", MenusId = Guid.Empty };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "系统管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(companymenus).ExecuteAffrows();
            //}

            //Menus companymenucompanys = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "单位管理", Sort = 1, Component = typeof(Companys).Name, MenusId = defaultsystemmenuid };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "单位管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(companymenucompanys).ExecuteAffrows();
            //}

            //Menus companymenuusers = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "用户管理", Sort = 2, Component = typeof(Users).Name, MenusId = defaultsystemmenuid };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "用户管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(companymenuusers).ExecuteAffrows();
            //}

            //Menus companymenumenus = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "菜单管理", Sort = 3, Component = typeof(Menus).Name, MenusId = defaultsystemmenuid };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "菜单管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(companymenumenus).ExecuteAffrows();
            //}

            //Menus companygrant = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "菜单授权", Sort = 4, Component = "Grant", IsAuto = false, MenusId = defaultsystemmenuid };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "菜单授权"))
            //{
            //    factory.FreeSql.Insert<Menus>(companygrant).ExecuteAffrows();
            //}


            //Menus companyrole = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "角色管理", Sort = 5, Component = typeof(Roles).Name, MenusId = defaultsystemmenuid };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "角色管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(companyrole).ExecuteAffrows();
            //}

            //Menus companyorganzition = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "组织机构管理", Sort = 6, Component = typeof(Organizations).Name, MenusId = defaultsystemmenuid };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "组织机构管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(companyorganzition).ExecuteAffrows();
            //}





            //Menus softtoolsmenus = new Menus() { Id = Guid.NewGuid(), IsDefault = true, MenuName = "研发管理", MenusId = Guid.Empty };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "研发管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(softtoolsmenus).ExecuteAffrows();
            //}

            //var father = factory.FreeSql.Select<Menus>().Where(x => x.MenuName == "研发管理").ToList<Menus>().FirstOrDefault();

            //Menus codesnippet = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Component = "CodeSnippet", MenuName = "生成模板", MenusId = father.Id };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "生成模板"))
            //{
            //    factory.FreeSql.Insert<Menus>(codesnippet).ExecuteAffrows();
            //}

            //Menus codegenerator = new Menus() { Id = Guid.NewGuid(), IsDefault = true,IsAuto = false, Component = "CodeGenerator", MenuName = "生成代码", MenusId = father.Id };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "生成代码"))
            //{
            //    factory.FreeSql.Insert<Menus>(codegenerator).ExecuteAffrows();
            //}


            //Menus snippet = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Component = "SnippetRecord", MenuName = "代码片段", MenusId = father.Id };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "代码片段"))
            //{
            //    factory.FreeSql.Insert<Menus>(snippet).ExecuteAffrows();
            //}

            //Menus connectionstring = new Menus() { Id = Guid.NewGuid(), IsDefault = true, Component = "ConnectionStringManage", MenuName = "数据库连接管理", MenusId = father.Id };
            //if (!factory.FreeSql.Select<Menus>().Any(x => x.MenuName == "数据库连接管理"))
            //{
            //    factory.FreeSql.Insert<Menus>(connectionstring).ExecuteAffrows();
            //}
        }
        #endregion

        #region 初始化单位
        public void InitCompanys()
        {
            Companys selfcompanys = new Companys() { Id = defaultSelfCompany, CompanyName = defaultSelfCompanyName };
            if (!FreeSqlFactory.FreeSql.Select<Companys>().Any(x => x.Id == defaultSelfCompany))
            {
                FreeSqlFactory.FreeSql.Insert<Companys>(selfcompanys).ExecuteAffrows();
            }

            Companys defaultcompany = new Companys() { Id = defaultCompanyguid, CompanyName = defaultCompanyName };
            if (!FreeSqlFactory.FreeSql.Select<Companys>().Any(x => x.Id == defaultCompanyguid))
            {
                FreeSqlFactory.FreeSql.Insert<Companys>(defaultcompany).ExecuteAffrows();
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
            if (!FreeSqlFactory.FreeSql.Select<Users>().Any(x => x.Id == defaultCompanyUser))
            {
                FreeSqlFactory.FreeSql.Insert<Users>(users).ExecuteAffrows();
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
            if (!FreeSqlFactory.FreeSql.Select<Users>().Any(x => x.Id == defaultSelfUser))
            {
                FreeSqlFactory.FreeSql.Insert<Users>(selfusers).ExecuteAffrows();
            }
        }
        #endregion

        #region 初始化角色
        public void InitRole(Guid companyid,Guid userid,Guid? defaultroleid = null)
        {
            var id = defaultroleid.HasValue ? defaultroleid.Value : defaultSelfRole;
            //初始化角色
            Roles roleself = new Roles() { Id = id , Name = DefaultCommonEnum.defaultRole.GetDescription(), CompanysId = companyid };
            if (!FreeSqlFactory.FreeSql.Select<Roles>().Any(x => x.Id == id && x.CompanysId == companyid))
                FreeSqlFactory.FreeSql.Insert<Roles>(roleself).ExecuteAffrows(); 

            //初始化角色用户
            RoleUsers roleselfUsers = new RoleUsers() { CompanysId = companyid, RolesId = id,UsersId = userid };
            if (!FreeSqlFactory.FreeSql.Select<RoleUsers>().Any(x => x.RolesId == id && x.UsersId == userid))
                FreeSqlFactory.FreeSql.Insert<RoleUsers>(roleselfUsers).ExecuteAffrows();

            // 初始化角色菜单
            FreeSqlFactory.FreeSql.Select<Menus>().Where(x => !!x.IsDefault).ToList().ForEach(p => {
                RoleMenus roleselfMenus = new RoleMenus() {CompanysId = companyid, RolesId = id, MenusId = p.Id };
                if (!FreeSqlFactory.FreeSql.Select<RoleMenus>().Any(x => x.RolesId == id && x.MenusId == p.Id))
                    FreeSqlFactory.FreeSql.Insert<RoleMenus>(roleselfMenus).ExecuteAffrows();
            }); 
          
        } 
        #endregion

        #region 初始化组织机构
        public void InitOrganization(Guid companyid,Guid userid,Guid? defaultorganizationid = null,string OrganizationName="")
        {
            var id = defaultorganizationid.HasValue ? defaultorganizationid.Value : defaultSelfOrganization;
            //初始化组织机构
            Organizations organizationself = new Organizations() { Id = id, Name = OrganizationName, CompanysId = companyid };
            if (!FreeSqlFactory.FreeSql.Select<Organizations>().Any(x => x.Id == id && x.CompanysId == companyid))
                FreeSqlFactory.FreeSql.Insert<Organizations>(organizationself).ExecuteAffrows();


            //初始化组织机构用户
            OrganizationUsers organizationSelfUsers = new OrganizationUsers() {CompanysId = companyid, OrganizationsId = defaultOrganization, UsersId = userid };
            if (!FreeSqlFactory.FreeSql.Select<OrganizationUsers>().Any(x => x.OrganizationsId == defaultOrganization && x.UsersId == userid))
                FreeSqlFactory.FreeSql.Insert<OrganizationUsers>(organizationSelfUsers).ExecuteAffrows();


            // 初始化组织机构菜单
            FreeSqlFactory.FreeSql.Select<Menus>().Where(x => !!x.IsDefault).ToList().ForEach(p => {
                OrganizationMenus organizationselfMenus = new OrganizationMenus() {CompanysId = companyid,  OraganizationsId = id, MenusId = p.Id };
                if (!FreeSqlFactory.FreeSql.Select<OrganizationMenus>().Any(x => x.OraganizationsId == id && x.MenusId == p.Id))
                    FreeSqlFactory.FreeSql.Insert<OrganizationMenus>(organizationselfMenus).ExecuteAffrows();
            });

        }
        #endregion

        #region 初始化单位菜单和用户
        public void InitCompanyMenuAndUser(Guid companyid, Guid userid)
        {
            //初始单位用户
            CompanyUsers companyselfUsers = new CompanyUsers() { CompanysId = companyid, UsersId = userid };
            if (!FreeSqlFactory.FreeSql.Select<CompanyUsers>().Any(x => x.CompanysId == companyid && x.UsersId == userid))
                FreeSqlFactory.FreeSql.Insert<CompanyUsers>(companyselfUsers).ExecuteAffrows();

            // 初始单位菜单
            FreeSqlFactory.FreeSql.Select<Menus>().Where(x => !!x.IsDefault).ToList().ForEach(p => {
                CompanyMenus companyselfMenus = new CompanyMenus() { CompanysId = companyid, MenusId = p.Id };
                if (!FreeSqlFactory.FreeSql.Select<CompanyMenus>().Any(x => x.CompanysId == companyid && x.MenusId == p.Id))
                    FreeSqlFactory.FreeSql.Insert<CompanyMenus>(companyselfMenus).ExecuteAffrows();
            });
        }
        #endregion

        #region 初始化基础数据
        public void InitBaseData() {
            Guid basesexid = Guid.NewGuid();
            BaseData baseDatasex = new BaseData()
            {
                Id = basesexid,
                Code = "Sex",
                Name = "性别",
                Description = "性别基础数据"
            };

            BaseDataDeatil baseDataDeatilB = new BaseDataDeatil()
            {
                Code = "Body",
                Name = "男",
                Description = "先生",
                BaseDataId = basesexid
            };

            BaseDataDeatil baseDataDeatilG = new BaseDataDeatil()
            {
                Code = "Girl",
                Name = "女",
                Description = "女士",
                BaseDataId = basesexid
            };
            if (!FreeSqlFactory.FreeSql.Select<BaseData>().Any(x => x.Code == "Sex"))
            {
                FreeSqlFactory.FreeSql.Insert<BaseData>(baseDatasex).ExecuteAffrows();
            }
            if (!FreeSqlFactory.FreeSql.Select<BaseDataDeatil>().Any(x => x.Code == "Body"))
            {
                FreeSqlFactory.FreeSql.Insert<BaseDataDeatil>(baseDataDeatilB).ExecuteAffrows();
            }
            if (!FreeSqlFactory.FreeSql.Select<BaseDataDeatil>().Any(x => x.Code == "Girl"))
            {
                FreeSqlFactory.FreeSql.Insert<BaseDataDeatil>(baseDataDeatilG).ExecuteAffrows();
            }


            Guid basealignid = Guid.NewGuid();
            BaseData baseDataalign = new BaseData()
            {
                Id = basealignid,
                Code = "Align",
                Name = "显示位置（左中右）",
                Description = "显示位置（左中右）"
            };

            BaseDataDeatil baseDataDeatilleft = new BaseDataDeatil()
            {
                Code = "Left",
                Name = "居左",
                Description = "居左",
                BaseDataId = basealignid
            };

            BaseDataDeatil baseDataDeatilCenter = new BaseDataDeatil()
            {
                Code = "Center",
                Name = "居中",
                Description = "居中",
                BaseDataId = basealignid
            };

            BaseDataDeatil baseDataDeatilRight = new BaseDataDeatil()
            {
                Code = "Right",
                Name = "居右",
                Description = "居右",
                BaseDataId = basealignid
            };
            if (!FreeSqlFactory.FreeSql.Select<BaseData>().Any(x => x.Code == "Align"))
            {
                FreeSqlFactory.FreeSql.Insert<BaseData>(baseDataalign).ExecuteAffrows();
            }
            if (!FreeSqlFactory.FreeSql.Select<BaseDataDeatil>().Any(x => x.Code == "Left"))
            {
                FreeSqlFactory.FreeSql.Insert<BaseDataDeatil>(baseDataDeatilleft).ExecuteAffrows();
            }
            if (!FreeSqlFactory.FreeSql.Select<BaseDataDeatil>().Any(x => x.Code == "Center"))
            {
                FreeSqlFactory.FreeSql.Insert<BaseDataDeatil>(baseDataDeatilCenter).ExecuteAffrows();
            }
            if (!FreeSqlFactory.FreeSql.Select<BaseDataDeatil>().Any(x => x.Code == "Right"))
            {
                FreeSqlFactory.FreeSql.Insert<BaseDataDeatil>(baseDataDeatilRight).ExecuteAffrows();
            }
        }
       

        #endregion
    }
}
