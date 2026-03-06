using MedicalAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalAPI.Application.Services;
using Microsoft.EntityFrameworkCore;
using MedicalAPI.Infrastructure.Presistance;
using MedicalAPI.Application.MedicalDto;
using Microsoft.AspNetCore.Authorization;
using MedicalAPI.Application.ApplicationUser;
using System.Security.Claims;
using MediatR;
using MedicalAPI.Application.MedicalAPI.Queries.GetAllAppointment;
using MedicalAPI.Application.MedicalAPI.Commands.CreateAppointment;
using MedicalAPI.Application.MedicalAPI.Queries.GetAppointmentById;
using MedicalAPI.Application.MedicalAPI.Commands.EditAppointment;
using AutoMapper;
using MedicalAPI.Application.MedicalAPI.Commands.DeleteAppointment;

namespace MedicalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly MedicalDbContext _dbContext;
        private readonly IMediator _mediator;

        public AppointmentController(MedicalDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllAppointments()
        {
            var appointments = await _mediator.Send(new GetAllAppointmentQuery());
            return Ok(appointments);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var appointments = await _mediator.Send(new GetAppointmentByUserIdQuery(userId));
            return Ok(appointments);
        }

        [HttpGet("{appointmentId}")]
        public async Task<ActionResult<AppointmentDto>> GetById(int appointmentId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var createdById = await _dbContext.Appointment
                .Where(a => a.AppointmentId == appointmentId)
                .Select(a => a.CreatedById)
                .FirstOrDefaultAsync();

            if (createdById != userId)
            {
                return Forbid();
            }

            var appointment = await _mediator.Send(new GetAppointmentByIdQuery(appointmentId));
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpPut("{appointmentId}")]
        public async Task<IActionResult> Edit(int appointmentId, EditAppointmentCommand command)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var createdById = await _dbContext.Appointment
                .Where(a => a.AppointmentId == appointmentId)
                .Select(a => a.CreatedById)
                .FirstOrDefaultAsync();

            if (createdById != userId)
            {
                return Forbid();
            }

            // Ensure the command is targeting the correct resource
            // (Assumes EditAppointmentCommand has an AppointmentId or it's being passed in)
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{appointmentId}")]
        public async Task<IActionResult> Delete(int appointmentId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var createdById = await _dbContext.Appointment
                .Where(a => a.AppointmentId == appointmentId)
                .Select(a => a.CreatedById)
                .FirstOrDefaultAsync();

            if (createdById != userId)
            {
                return Forbid();
            }

            await _mediator.Send(new DeleteAppointmentCommand { AppointmentId = appointmentId });
            return NoContent();
        }
    }
}
