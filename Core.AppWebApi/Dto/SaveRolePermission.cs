using System.Collections.Generic;

namespace Core.AppWebApi
{
    public class SaveRolePermission
    {
        public List<SaveRoleMenusDto> RoleMenus { get; set; }
        public List<SaveRoleButtonsDto> RoleButtons { get; set; }
    }
}
