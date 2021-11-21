using AutoMapper;
using CrimeLogger.Shared;
using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CrimeProvince, CrimeProvinceDTO>().ReverseMap();
        }
    }
}
