using MediatR;
using MedicalAPI.Application.MedicalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetAppointmentById
{
    public class GetAppointmentByIdQuery : IRequest<AppointmentDto>
    {
        public int AppointmentId { get; set; }

        public GetAppointmentByIdQuery(int appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}
