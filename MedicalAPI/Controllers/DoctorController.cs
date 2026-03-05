using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Application.Services;
using MedicalAPI.Infrastructure.Presistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly MedicalDbContext _dbContext;
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService, MedicalDbContext dbContext)
        {
            _doctorService = doctorService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll()
        {
            // Assuming DoctorService has a way to get all doctors or we can query DB
            var doctors = await _dbContext.Doctor
                .Include(d => d.Specialization)
                .ToListAsync();
            
            // This is a simple projection, ideally use Mapper or a Service method
            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorDto doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _doctorService.Create(doctor);
            return Ok();
        }

        [HttpGet("specializations")]
        public async Task<IActionResult> GetSpecializations()
        {
            var specializations = await _dbContext.Specialization
                .Select(s => new { s.SpecId, s.Name })
                .ToListAsync();

            return Ok(specializations);
        }
    }
}
