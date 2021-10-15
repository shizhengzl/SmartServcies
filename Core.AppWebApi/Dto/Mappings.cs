using AutoMapper;
using Core.AppSystemServices;
using System.Collections.Generic;

namespace Core.AppWebApi
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<DtoUser, Users>();
            CreateMap<Users, DtoUser>();
            CreateMap<List<DtoUser>, List<Users>>();
            CreateMap<List<Users>, List<DtoUser>>();
        }
    }
}
