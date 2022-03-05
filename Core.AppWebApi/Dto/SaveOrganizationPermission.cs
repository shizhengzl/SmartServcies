using System.Collections.Generic;

namespace Core.AppWebApi
{
    public class SaveOrganizationPermission
    {
        public List<SaveOrganizationMenusDto> OrganizationMenus { get; set; }
        public List<SaveOrganizationButtonsDto> OrganizationButtons { get; set; }
    }
}
