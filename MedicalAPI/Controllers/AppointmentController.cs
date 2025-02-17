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

namespace MedicalAPI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly MedicalDbContext _dbContext;
        private readonly IUserContext _userContext;

        public AppointmentController(IAppointmentService appointmentService,MedicalDbContext dbContext, IUserContext userContext)
        {
            _appointmentService = appointmentService;
            _dbContext = dbContext;
            _userContext = userContext;
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
        public async Task<IActionResult> Create(Application.MedicalDto.AppointmentDto appointment)
        {
            User.IsInRole("Patient");
            appointment.CreatedById = _userContext.GetCurrentUser().Id;
         
            await _appointmentService.Create(appointment);
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            var appointments = await _appointmentService.GetAppointmentsByUserIdAsync(userId); 
            return View(appointments); 
        }
    }
}
