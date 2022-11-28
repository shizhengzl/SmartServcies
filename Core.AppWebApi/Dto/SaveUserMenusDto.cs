using System;
using System.Collections.Generic;

namespace Core.AppWebApi
{
    public class SaveUserMenusDto
    {
        public Guid UserId { get; set; }

        public Guid MenuId { get; set; } 
    }
}
