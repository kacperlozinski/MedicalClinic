using MediatR;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetAllCarWorkshops
{
    public class GetAppointmentByUserIdQuery : IRequest<IEnumerable<Appointment>>
    {
        public string UserId { get; set; }

        public GetAppointmentByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
