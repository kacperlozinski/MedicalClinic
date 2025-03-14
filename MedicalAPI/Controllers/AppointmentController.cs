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
using MedicalAPI.Application.MedicalAPI.Commands.EditAppointment;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MedicalAPI.Application.MedicalAPI.Commands.DeleteAppointment;

namespace MedicalAPI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly MedicalDbContext _dbContext;
        private readonly IUserContext _userContext;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, MedicalDbContext dbContext, IUserContext userContext, IMediator mediator, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _dbContext = dbContext;
            _userContext = userContext;
            _mediator = mediator;
            _mapper = mapper;
        }
        [Authorize]
        public IActionResult Create()
        {
            var doctors = _dbContext.Doctor
                .Include(d => d.Specialization)
                .Select(d => new
                {
                    d.DoctorId,
                    FullName = d.FirstName + " " + d.LastName + " - " + d.Specialization.Name,
                    AvailableFrom = d.AvailableFrom, 
                    AvailableTo = d.AvailableTo
                })
                .ToList();

            ViewBag.DoctorsList = doctors; // Przekazujemy pełne dane
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
            if(!ModelState.IsValid)
            { return BadRequest(); }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Create)); //todo refactor tymczasowo tak żeby nie sadziło błedu, potem gdzies indziej przekierowanie zrobic
        }

        /*  public async Task<IActionResult> Edit(int id)
          {
              var dto = _appointmentService.GetByIdAsync(id);

          }*/

        [HttpGet("/Appointment/All")]
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
        [Route("/Appointment/Details/{AppointmentId}")]
        public async Task<IActionResult> Details(int AppointmentId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var CreatedById = await _dbContext.Appointment
                .Where(a => a.AppointmentId == AppointmentId)
                .Select(a => a.CreatedById)
                .FirstOrDefaultAsync();
            if (CreatedById != userId)
            {
                return NotFound();
            }
            var appointmentId = await _mediator.Send(new GetAppointmentByIdQuery(AppointmentId));

            return View(appointmentId);
        }


 
        [Route("/Appointment/Edit/{AppointmentId}")]
        public async Task<IActionResult> Edit(int AppointmentId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var CreatedById = await _dbContext.Appointment
                .Where(a => a.AppointmentId == AppointmentId)
                .Select(a => a.CreatedById)
                .FirstOrDefaultAsync();
            var doctors = _dbContext.Doctor
               .Include(d => d.Specialization)
               .Select(d => new
               {
                   d.DoctorId,
                   FullName = d.FirstName + " " + d.LastName + " - " + d.Specialization.Name,
                   AvailableFrom = d.AvailableFrom,
                   AvailableTo = d.AvailableTo
               })
               .ToList();

            ViewBag.DoctorsList = doctors; // Przekazujemy pełne dane
            ViewBag.Doctors = new SelectList(doctors, "DoctorId", "FullName");
            if (CreatedById != userId)
            {
                return NotFound();
            }
            var dto = await _mediator.Send(new GetAppointmentByIdQuery(AppointmentId));
            EditAppointmentCommand model = _mapper.Map<EditAppointmentCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("/Appointment/Edit/{AppointmentId}")]
        public async Task<IActionResult> Edit(int AppointmentId, EditAppointmentCommand command)
        {
            
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [Route("/Appointment/Delete/{AppointmentId}")]
        public async Task<IActionResult> Delete(int AppointmentId, DeleteAppointmentCommand deleteAppointment)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var CreatedById = await _dbContext.Appointment
                .Where(a => a.AppointmentId == AppointmentId)
                .Select(a => a.CreatedById)
                .FirstOrDefaultAsync();
            if (CreatedById != userId)
            {
                return NotFound();
            }

            await _mediator.Send(deleteAppointment);

            return RedirectToAction(nameof(Index));
        }


    }
}
