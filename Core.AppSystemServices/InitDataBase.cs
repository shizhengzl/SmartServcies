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

        public void Init() {
            InitCompanys();
            InitUsers();
            InitMenus();
        }

        #region 初始化单位
        public void InitCompanys() {
            Companys companys = new Companys() { Id = Guid.Empty, CompanyName = "隔壁老王管理公司" };
            if (!factory.FreeSql.Select<Companys>().Any(x => x.CompanyName == "隔壁老王管理公司")) {
                factory.FreeSql.Insert<Companys>(companys).ExecuteAffrows();
            }
        }
        #endregion

        #region 初始化用户
        public void InitUsers()
        {
            Users users = new Users() { Id = Guid.Empty, UserName = "admin"
                , NikeName = "老王", Phone = "13701859214", Email = "shizheng89@qq.com"
               , PassWord = "admin13701859214".Tomd5()
            };
            if (!factory.FreeSql.Select<Companys>().Any(x => x.Id == users.Id))
            {
                factory.FreeSql.Insert<Users>(users).ExecuteAffrows();
            }
        }
        #endregion


        #region 初始化菜单
        public void InitMenus() {
            Guid defaultguid = Guid.NewGuid();
            Menus menus = new Menus() {  Id = defaultguid, Name = "超级系统管理",MenusId = Guid.Empty};
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "超级系统管理"))
            {
                factory.FreeSql.Insert<Menus>(menus).ExecuteAffrows();
            }

            Menus menuusers = new Menus() { Id = Guid.NewGuid(), Name = "超级用户管理",Sort = 2,Url =typeof(Users).Name, MenusId = defaultguid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "超级用户管理"))
            {
                factory.FreeSql.Insert<Menus>(menuusers).ExecuteAffrows();
            }

            Menus menucompanys = new Menus() { Id = Guid.NewGuid(), Name = "超级单位管理",Sort = 1, Url = typeof(Companys).Name, MenusId = defaultguid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "超级单位管理"))
            {
                factory.FreeSql.Insert<Menus>(menucompanys).ExecuteAffrows();
            }


            Menus menumenus = new Menus() { Id = Guid.NewGuid(), Name = "超级菜单管理",Sort = 3, Url = typeof(Menus).Name, MenusId = defaultguid };
            if (!factory.FreeSql.Select<Menus>().Any(x => x.Name == "超级菜单管理"))
            {
                factory.FreeSql.Insert<Menus>(menumenus).ExecuteAffrows();
            }
        }
        #endregion
    }
}
