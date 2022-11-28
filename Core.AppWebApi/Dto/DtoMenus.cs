using Core.AppSystemServices;
using System.Collections.Generic;

namespace Core.AppWebApi
{
    public class DtoMenus : Menus
    {
        public List<DtoMenus> children { get; set; }


        public List<PermissionButton> buttons { get; set; }


        public bool HasButton { get; set; } = false;

        public string Description { get; set; }
    }
}
