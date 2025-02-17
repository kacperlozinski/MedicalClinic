using AutoMapper;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalAPI.Domain.Entities;

namespace MedicalAPI.Application.Services
{
    internal class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository,IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task Create(AppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Domain.Entities.Appointment>(appointmentDto);

            await _appointmentRepository.Create(appointment);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAll()
        {
            var appointments = await _appointmentRepository.GetAll();

            var dtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            return dtos;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByUserIdAsync(string userId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByUserIdAsync(userId);
            return appointments.Select(a => new AppointmentDto
            {
                CreatedById = a.CreatedById,
                AppointmentTitle = a.AppointmentTitle,
                VisitDate = a.VisitDate
            }).ToList();
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            var appointment = await _appointmentRepository.GetId(id);
            return appointment == null ? null : new Appointment
            {
                AppointmentId = appointment.AppointmentId,
                AppointmentDescription = appointment.AppointmentDescription,
                AppointmentTitle = appointment.AppointmentTitle
            };
        }



    }
}
