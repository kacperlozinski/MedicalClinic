using MediatR;
using MedicalAPI.Application.MedicalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MedicalAPI.Application.MedicalAPI.Commands.EditAppointment
{
    public class EditAppointmentCommand : AppointmentDto, IRequest<Unit>
    {
        [Required]
        public string AppointmentDescription { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }
    }
}

