using MedicalAPI.Application.Services;
using MedicalAPI.Infrastructure.Presistance;
using Microsoft.AspNetCore.Mvc;
using MedicalAPI.Application.MedicalDto;
using Microsoft.AspNetCore.Authorization;

namespace MedicalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly MedicalDbContext _dbContext;

        public PatientController(IPatientService patientService, MedicalDbContext dbContext)
        {
            _patientService = patientService;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientDto patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _patientService.Create(patient);
            return Ok();
        }
    }
}
