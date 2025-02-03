using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Application.Services;
using MedicalAPI.Infrastructure.Presistance;
using Microsoft.AspNetCore.Mvc;


namespace MedicalAPI.Controllers
{
    public class DoctorController : Controller
    {
        
        private readonly MedicalDbContext _dbContext;
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService, MedicalDbContext dbContext)
        {
            _doctorService = doctorService;
        }

        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorDto doctor)
        {

            await _doctorService.Create(doctor);
            return RedirectToAction(nameof(Create)); //todo refactor tymczasowo tak żeby nie sadziło błedu, potem gdzies indziej przekierowanie zrobic
        }

    }
}
