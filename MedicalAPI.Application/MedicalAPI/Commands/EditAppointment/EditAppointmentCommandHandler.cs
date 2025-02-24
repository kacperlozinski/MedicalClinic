using MediatR;
using MedicalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.EditAppointment
{
    public class EditAppointmentCommandHandler : IRequestHandler<EditAppointmentCommand, Unit>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public EditAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<Unit> Handle(EditAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(request.AppointmentId!);

            appointment.AppointmentDescription = request.AppointmentDescription;
            appointment.VisitDate = request.VisitDate;

            await _appointmentRepository.Commit();

            return Unit.Value;
        }
    }
}
