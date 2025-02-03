using AutoMapper;
using MedicalAPI.Application.MedicalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.Mappings
{
    internal class PatientMappingProfile : Profile
    {
        public PatientMappingProfile() {
        
            CreateMap<PatientDto, Domain.Entities.Patient>();
        
        }
        
    }
}
