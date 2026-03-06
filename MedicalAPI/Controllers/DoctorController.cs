using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Application.MedicalAPI.Commands.CreateDoctor;
using MedicalAPI.Application.MedicalAPI.Commands.DeleteDoctor;
using MedicalAPI.Application.MedicalAPI.Commands.EditDoctor;
using MedicalAPI.Application.MedicalAPI.Queries.GetAllDoctor;
using MedicalAPI.Application.MedicalAPI.Queries.GetDoctorById;
using MedicalAPI.Infrastructure.Presistance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MedicalDbContext _dbContext;

        public DoctorController(IMediator mediator, MedicalDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll()
        {
            var doctors = await _mediator.Send(new GetAllDoctorQuery());
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetById(int id)
        {
            var doctor = await _mediator.Send(new GetDoctorByIdQuery(id));
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, EditDoctorCommand command)
        {
            command.DoctorId = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteDoctorCommand(id));
            return NoContent();
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
