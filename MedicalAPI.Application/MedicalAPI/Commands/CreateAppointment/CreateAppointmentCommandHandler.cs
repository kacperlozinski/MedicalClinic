using AutoMapper;
using MediatR;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Unit>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            
            var appointment = _mapper.Map<Domain.Entities.Appointment>(request);

            await _appointmentRepository.Create(appointment);

            return Unit.Value;
        }
    }
}
