using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string AppointmentTitle { get; set; }
        public string AppointmentDescription { get; set; }
        public DateTime VisitDate { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }

        // public string EncodedName { get; private set; } = default!;

        // public void EncodeName() => EncodedName = AppointmentTitle.ToLower().Replace(" ","-");
    }
}