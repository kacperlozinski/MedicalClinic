using AutoMapper;
using MedicalAPI.Application.Appointment;
using MedicalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.Mappings
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<AppointmentDto, Domain.Entities.Appointment>()
                .ForMember(e => e.Patient, opt => opt.MapFrom(src => new Patient()
                {
                    AppointmentId = src.AppointmentId,
                    PatientId = src.PatientId
                }));
           //CreateMap<DoctorDto>     todo: dodać potem mapping 
        }
    }
}
