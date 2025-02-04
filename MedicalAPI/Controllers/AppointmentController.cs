using MedicalAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalAPI.Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalAPI.Infrastructure.Presistance;
using MedicalAPI.Application.MedicalDto;

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
            var patients = _dbContext.Patient
        .Select(p => new
        {
            p.PatientId,
            FullName = p.FirstName + " " + p.LastName
        })
        .ToList();


        var doctors = _dbContext.Doctor
        .Select(d => new 
        { 
            d.DoctorId, 
            FullName = d.FirstName + " " + d.LastName // Zakładamy, że Doctor ma FirstName i LastName
        })
        .ToList();

            // Przekazanie danych do widoku za pomocą ViewBag
            ViewBag.Patients = new SelectList(patients, "PatientId", "FullName");
            ViewBag.Doctors = new SelectList(doctors, "DoctorId", "FullName");

            // Przekazanie danych do widoku za pomocą ViewBag
            ViewBag.Patients = new SelectList(patients, "PatientId", "FullName");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Application.MedicalDto.AppointmentDto appointment)
        {
         
            await _appointmentService.Create(appointment);
            return RedirectToAction(nameof(Create)); //todo refactor tymczasowo tak żeby nie sadziło błedu, potem gdzies indziej przekierowanie zrobic
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentService.GetAll();
            return View(appointments);
        }
    }
}
