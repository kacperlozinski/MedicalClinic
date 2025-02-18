using AutoMapper;
using MediatR;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Entities;
using MedicalAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Unit>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Unit> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var appointment = new Appointment
            {
                AppointmentTitle = request.AppointmentTitle,
                AppointmentDescription = request.AppointmentDescription,
                DoctorId = request.DoctorId,
                CreatedById = userId,
                VisitDate = request.VisitDate

            };

            await _appointmentRepository.Create(appointment);

            return Unit.Value;
        }
    }
}
