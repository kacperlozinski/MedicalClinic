using AutoMapper;
using MedicalAPI.Application.MedicalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.Mappings
{
    public class DoctorMappingProfile : Profile
    {

        public DoctorMappingProfile()
        {

            CreateMap<DoctorDto, Domain.Entities.Doctor>();

            

        }
    }
}
