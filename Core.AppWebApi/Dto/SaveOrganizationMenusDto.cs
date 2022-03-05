using System;
using System.Collections.Generic;

namespace Core.AppWebApi
{
    public class SaveOrganizationMenusDto
    {
        public Guid OrganizationId { get; set; }

        public Guid MenuId { get; set; } 
    }
}
