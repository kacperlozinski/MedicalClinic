using MedicalAPI.Application.Services;
using MedicalAPI.Infrastructure.Presistance;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MedicalAPI.Domain.Entities;


namespace MedicalAPI.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly MedicalDbContext _dbContext;

        public PatientController(IPatientService patientService, MedicalDbContext dbContext)
        {
            _patientService = patientService;
            _dbContext = dbContext;
        }

        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.Patient patient)
        {

            await _patientService.Create(patient);
            return RedirectToAction(nameof(Create)); //todo refactor tymczasowo tak żeby nie sadziło błedu, potem gdzies indziej przekierowanie zrobic
        }

    }
}
