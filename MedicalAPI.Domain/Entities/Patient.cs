using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Domain.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

       // public int UserId { get; set; }

        public int AppointmentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string Password { get; set; }

      //  public virtual User User { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        

    }
}
