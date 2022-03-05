using System.Collections.Generic;

namespace Core.AppWebApi
{
    public class SaveUserPermission
    {

        public List<SaveUserMenusDto> UserMenus { get; set; }
        public List<SaveUserButtonsDto> UserButtons { get; set; }
    }
}
