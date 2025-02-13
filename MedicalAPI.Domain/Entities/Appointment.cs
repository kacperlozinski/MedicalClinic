using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Domain.Entities
{
    public class Appointment
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }
        //public int PatientId { get; set; }

        public int DoctorId { get; set; }
        public string AppointmentTitle { get; set; }
        public string? AppointmentDescription { get; set; } = string.Empty;
        public DateTime VisitDate { get; set; }

        public string? CreatedById { get; set; }
                                                        //PotrzebnyCqrs aby pozbyć się tego z Dto
        public IdentityUser? CreatedBy { get; set; }

        public virtual Doctor Doctor { get; set; } 

        //public virtual Patient Patient { get; set; }

       

        // public string EncodedName { get; private set; } = default!;

        // public void EncodeName() => EncodedName = AppointmentTitle.ToLower().Replace(" ","-");
    }
}