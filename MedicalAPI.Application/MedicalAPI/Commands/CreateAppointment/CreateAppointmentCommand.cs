using MediatR;
using MedicalAPI.Application.MedicalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.CreateAppointment
{
    public class CreateAppointmentCommand : AppointmentDto, IRequest<Unit>
    {
       

    }
}
