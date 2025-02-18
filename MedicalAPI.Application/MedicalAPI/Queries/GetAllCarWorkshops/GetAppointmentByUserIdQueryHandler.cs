using MedicalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalAPI.Domain.Entities;
using MedicalAPI.Application.MedicalDto;
using System.Security.Claims;
using MedicalAPI.Application.ApplicationUser;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using MediatR;



namespace MedicalAPI.Application.MedicalAPI.Queries.GetAllCarWorkshops
{
    public class GetAppointmentByUserIdQueryHandler : IRequestHandler<GetAppointmentByUserIdQuery, IEnumerable<Appointment>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUserContext _userContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAppointmentByUserIdQueryHandler(IAppointmentRepository appointmentRepository, IUserContext userContext, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentRepository = appointmentRepository;
            _userContext = userContext;
            _httpContextAccessor = httpContextAccessor;
        }
       
      /*  var appointments = await _appointmentRepository.GetAppointmentsByUserIdAsync(userId);
            return appointments.Select(a => new AppointmentDto
            {
                CreatedById = a.CreatedById,
                AppointmentTitle = a.AppointmentTitle,
                VisitDate = a.VisitDate
    }).ToList();*/
      public async Task<IEnumerable<Appointment>> Handle(GetAppointmentByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //  var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointments = await _appointmentRepository.GetAppointmentsByUserIdAsync(request.UserId);
            return appointments;
        }
    }
}
