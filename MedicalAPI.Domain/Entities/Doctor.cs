using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Domain.Entities
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SpecializationId { get; set; }

        public TimeOnly? AvailableFrom { get; set; }
        public TimeOnly? AvailableTo { get; set; }

        public virtual User User { get; set; }

        public virtual Specialization Specialization { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }





    }
}
