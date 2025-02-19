using MedicalAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalAPI.Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalAPI.Infrastructure.Presistance;
using MedicalAPI.Application.MedicalDto;
using Microsoft.AspNetCore.Authorization;
using MedicalAPI.Application.ApplicationUser;
using System.Security.Claims;
using MedicalAPI.Domain.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MedicalAPI.Application.MedicalAPI.Commands;
using MediatR;
using MedicalAPI.Application.MedicalAPI.Queries.GetAllCarWorkshops;
using MedicalAPI.Application.MedicalAPI.Commands.CreateAppointment;
using MedicalAPI.Application.MedicalAPI.Queries.GetAppointmentById;

namespace MedicalAPI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly MedicalDbContext _dbContext;
        private readonly IUserContext _userContext;
        private readonly IMediator _mediator;

        public AppointmentController(IAppointmentService appointmentService, MedicalDbContext dbContext, IUserContext userContext, IMediator mediator)
        {
            _appointmentService = appointmentService;
            _dbContext = dbContext;
            _userContext = userContext;
            _mediator = mediator;
        }
        [Authorize]
        public IActionResult Create()
        {
            var doctors = _dbContext.Doctor
                    .Include(d => d.Specialization)
            .Select(d => new
            {
                d.DoctorId,
                FullName = d.FirstName + " " + d.LastName + " - " + d.Specialization.Name
            })
            .ToList();

            ViewBag.Doctors = new SelectList(doctors, "DoctorId", "FullName");

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAppointmentCommand command)
        {
            User.IsInRole("Patient");
            /*appointment.CreatedById = _userContext.GetCurrentUser().Id;*/

            // await _appointmentService.Create(appointment);
            await _mediator.Send(command);
            return RedirectToAction(nameof(Create)); //todo refactor tymczasowo tak żeby nie sadziło błedu, potem gdzies indziej przekierowanie zrobic
        }

        /*  public async Task<IActionResult> Edit(int id)
          {
              var dto = _appointmentService.GetByIdAsync(id);

          }*/

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(Application.MedicalDto.AppointmentDto appointment)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //var appointments = await _appointmentService.GetAppointmentsByUserIdAsync(userId);
            var appointments = await _mediator.Send(new GetAppointmentByUserIdQuery(userId));
            return View(appointments);
        }

        [HttpGet]
        [Authorize]
        [Route("/Appointment/{AppointmentId}")]
        public async Task<IActionResult> Details(int AppointmentId)
        {
            /*var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var CreatedById = _dbContext.Appointment.FirstOrDefaultAsync(a => a.CreatedById == userId);
            *//*if (CreatedById is null)
            {
                return NotFound();
            }*/

            var appointmentId = await _mediator.Send(new GetAppointmentByIdQuery(AppointmentId));

            return View(appointmentId);
        }
    }
}
