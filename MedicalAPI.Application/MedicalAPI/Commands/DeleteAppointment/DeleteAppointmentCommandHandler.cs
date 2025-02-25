using AutoMapper;
using MediatR;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, AppointmentDto>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task<AppointmentDto> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointmentId = await _appointmentRepository.GetAppointmentById(request.AppointmentId);

            var dto = _mapper.Map<AppointmentDto>(appointmentId);

            await _appointmentRepository.Delete(request.AppointmentId);

            return dto;
        }
    }
}
