﻿using AutoMapper;
using MedicalAPI.Application.MedicalAPI.Commands.EditAppointment;
using MedicalAPI.Application.MedicalAPI.Queries.GetAppointmentById;
using MedicalAPI.Application.MedicalDto;
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
            CreateMap<AppointmentDto, Domain.Entities.Appointment>();
                /*.ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(dest => dest.Patient, opt => opt.Ignore());*/

            CreateMap<Appointment, AppointmentDto>();
            // .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId));
           // CreateMap<AppointmentDto, GetAppointmentByIdQuery>();
            CreateMap<AppointmentDto, EditAppointmentCommand>();


            //CreateMap<DoctorDto>     todo: dodać potem mapping 

        }
    }
}
