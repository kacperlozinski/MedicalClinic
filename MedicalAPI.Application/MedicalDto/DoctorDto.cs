using MedicalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalDto
{
    public class DoctorDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }

        public int SpecializationId { get; set; }

        public TimeOnly? AvailableFrom { get; set; }
        public TimeOnly? AvailableTo { get; set; }

        public virtual Specialization Specialization { get; set; }

       // public virtual ICollection<Domain.Entities.Patient> Patients { get; set; } 

        public virtual ICollection<Domain.Entities.Appointment> Appointments { get; set; } = new List<Domain.Entities.Appointment>();
    }
}
