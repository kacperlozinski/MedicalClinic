using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Application.MedicalAPI.Commands.CreatePatient;
using MedicalAPI.Application.MedicalAPI.Commands.DeletePatient;
using MedicalAPI.Application.MedicalAPI.Commands.EditPatient;
using MedicalAPI.Application.MedicalAPI.Queries.GetAllPatient;
using MedicalAPI.Application.MedicalAPI.Queries.GetPatientById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
        {
            var patients = await _mediator.Send(new GetAllPatientQuery());
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetById(int id)
        {
            var patient = await _mediator.Send(new GetPatientByIdQuery(id));
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, EditPatientCommand command)
        {
            command.PatientId = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletePatientCommand(id));
            return NoContent();
        }
    }
}
