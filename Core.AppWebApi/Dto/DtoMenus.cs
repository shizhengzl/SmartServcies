using Core.AppSystemServices;
using System.Collections.Generic;

namespace Core.AppWebApi
{
    public class DtoMenus : Menus
    {
        public List<DtoMenus> children {  get; set; }
    }
}
