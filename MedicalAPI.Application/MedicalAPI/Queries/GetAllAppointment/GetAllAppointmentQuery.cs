using MediatR;
using MedicalAPI.Application.MedicalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetAllAppointment
{
    public class GetAllAppointmentQuery : IRequest<IEnumerable<AppointmentDto>>
    {

    }
}
