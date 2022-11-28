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
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "系统管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menus).ExecuteAffrows();
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
                CompanysId = defaultSelfCompany,
                SourceValue = "Roles",
                TargetSource = "Table",
                RightSourceValue = "RoleUsers",
                RightTargetSource = "Table"
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "角色用户"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys2).ExecuteAffrows();

                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", MenusId = menucompanys2.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", MenusId = menucompanys2.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", MenusId = menucompanys2.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();

            } 
            Menus menucompanys8 = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "机构用户",
                Sort = 1,
                Path = "organizationusers",
                MenuIcon = "404",
                Component = $"/snippet/treegrid",
                MenusId = defaultsuppermenuid,
                CompanysId = defaultSelfCompany,
                TargetSource = "Table",
                SourceValue= "Organizations",
                RightTargetSource = "Table",
                RightSourceValue = "OrganizationUsers"
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "机构用户"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys8).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate",CompanysId = defaultSelfCompany, MenusId = menucompanys8.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = menucompanys8.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = menucompanys8.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
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
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "用户管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys3).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = menucompanys3.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = menucompanys3.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = menucompanys3.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
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
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "基础数据"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys4).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = menucompanys4.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = menucompanys4.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = menucompanys4.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
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
                CompanysId = defaultSelfCompany,
                ShowCreate = true
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "角色管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys5).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = menucompanys5.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = menucompanys5.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = menucompanys5.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
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
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "机构管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys6).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = menucompanys6.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = menucompanys6.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = menucompanys6.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
            }
            var permissionid = Guid.Parse("d8e7d9d6-5807-2bb2-312e-24b8c57d42a4");
            Menus permission = new Menus()
            {
                Id = permissionid,
                IsSupper = true,
                MenuName = "权限管理",
                Sort = 1,
                Path = "permission",
                MenuIcon = "404",
                Component = "Layout",
                MenusId = Guid.Empty,
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "权限管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(permission).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = permission.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = permission.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = permission.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
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
                Component = $"/application/companys",
                MenusId = permissionid,
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "单位管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys7).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = menucompanys7.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = menucompanys7.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = menucompanys7.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
            }
            Menus menucompanys = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "菜单管理",
                Sort = 1,
                Path = "menus",
                MenuIcon = "404",
                Component = $"/menus/index",
                MenusId = permissionid,
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "菜单管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menucompanys).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = menucompanys.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = menucompanys.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = menucompanys.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
            }

            Menus menupermission = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "菜单按钮",
                Sort = 1,
                Path = "buttonpermission",
                MenuIcon = "404",
                Component = $"/menus/buttonpermission",
                MenusId = permissionid,
                SourceValue = "Menus",
                TargetSource = "Table",
                RightTargetSource = "Table",
                RightSourceValue = "PermissionButton",
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "菜单按钮"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menupermission).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = menupermission.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = menupermission.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = menupermission.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
            }


            Menus menupermissionbtn = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "授权管理",
                Sort = 1,
                Path = "grantpermission",
                MenuIcon = "404",
                Component = $"/menus/grantpermission",
                MenusId = permissionid,
                SourceValue = "",
                TargetSource = "",
                RightTargetSource = "",
                RightSourceValue = "",
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "授权管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(menupermissionbtn).ExecuteAffrows();
                //PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = menupermission.Id };
                //DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                //PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = menupermission.Id };
                //DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                //PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = menupermission.Id };
                //DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
            }




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
                CompanysId = defaultSelfCompany
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
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "连接管理"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(connectionmenus).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = connectionmenus.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = connectionmenus.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = connectionmenus.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
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
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "数据库字段"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(filedmenus).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = filedmenus.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = filedmenus.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = filedmenus.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
            }


            Menus intellisencemenus = new Menus()
            {
                Id = Guid.NewGuid(),
                IsSupper = true,
                MenuName = "代码片段",
                Sort = 1,
                Path = "intellisence",
                TargetSource = "Table",
                SourceValue = "Intellisence",
                MenuIcon = "404",
                Component = $"/soft/intellisence",
                MenusId = sorttool,
                
                CompanysId = defaultSelfCompany
            };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Any(x => x.MenuName == "代码片段"))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Menus>(intellisencemenus).ExecuteAffrows();
                PermissionButton p1 = new PermissionButton() { Name = "添加", WebKey = "btncreate", CompanysId = defaultSelfCompany, MenusId = intellisencemenus.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p1).ExecuteAffrows();
                PermissionButton p2 = new PermissionButton() { Name = "修改", WebKey = "btnmodify", CompanysId = defaultSelfCompany, MenusId = intellisencemenus.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p2).ExecuteAffrows();
                PermissionButton p3 = new PermissionButton() { Name = "删除", WebKey = "btndelete", CompanysId = defaultSelfCompany, MenusId = intellisencemenus.Id };
                DataBaseFactory.Core_Application.FreeSql.Insert<PermissionButton>(p3).ExecuteAffrows();
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
                CompanysId = defaultSelfCompany
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
                CompanysId = defaultSelfCompany
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
                CompanysId = defaultSelfCompany
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
                CompanysId = defaultSelfCompany
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
                CompanysId = defaultSelfCompany
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
            Companys selfcompanys = new Companys() { Id = defaultSelfCompany, CompanyName = defaultSelfCompanyName
                ,GrantMode = GrantMode.RoleGrant };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<Companys>().Any(x => x.Id == defaultSelfCompany))
            {
                DataBaseFactory.Core_Application.FreeSql.Insert<Companys>(selfcompanys).ExecuteAffrows();
            }

            Companys defaultcompany = new Companys() { Id = defaultCompanyguid, CompanyName = defaultCompanyName
                , GrantMode = GrantMode.RoleGrant
            };
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
            OrganizationUsers organizationSelfUsers = new OrganizationUsers() { CompanysId = companyid, OrganizationsId = id, UsersId = userid };
            if (!DataBaseFactory.Core_Application.FreeSql.Select<OrganizationUsers>().Any(x => x.OrganizationsId == id && x.UsersId == userid))
                DataBaseFactory.Core_Application.FreeSql.Insert<OrganizationUsers>(organizationSelfUsers).ExecuteAffrows();


            // 初始化组织机构菜单
            DataBaseFactory.Core_Application.FreeSql.Select<Menus>().Where(x => !!x.IsDefault).ToList().ForEach(p =>
            {
                OrganizationMenus organizationselfMenus = new OrganizationMenus() { CompanysId = companyid, OrganizationsId = id, MenusId = p.Id };
                if (!DataBaseFactory.Core_Application.FreeSql.Select<OrganizationMenus>().Any(x => x.OrganizationsId == id && x.MenusId == p.Id))
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
