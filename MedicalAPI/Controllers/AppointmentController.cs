using MedicalAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalAPI.Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalAPI.Infrastructure.Presistance;

namespace MedicalAPI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly MedicalDbContext _dbContext;

        public AppointmentController(IAppointmentService appointmentService,MedicalDbContext dbContext)
        {
            _appointmentService = appointmentService;
            _dbContext = dbContext;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.Appointment appointment)
        {
         
            await _appointmentService.Create(appointment);
            return RedirectToAction(nameof(Create)); //todo refactor
        }
    }
}
