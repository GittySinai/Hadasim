using AutoMapper;
using AutoMapper.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_BL
{
    internal class AutoMapperManager
    {
        public static Mapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
                         {
                 cfg.CreateMap<HMO_API.models.Member, HMO_DTO.models.Member>();
                 cfg.CreateMap<HMO_API.models.Member, HMO_DTO.models.Member>().ReverseMap();
                 cfg.CreateMap<HMO_API.models.MedicalEvent, HMO_DTO.models.MedicalEvent>();
                 cfg.CreateMap<HMO_API.models.MedicalEvent, HMO_DTO.models.MedicalEvent>().ReverseMap();
                 cfg.CreateMap<HMO_API.models.VaccinEvent, HMO_DTO.models.MedicalEvent>();
                 cfg.CreateMap<HMO_API.models.VaccinEvent, HMO_DTO.models.MedicalEvent>().ReverseMap();
             });


            var mapper = new Mapper(config);
            return mapper;
        }


    }
}
