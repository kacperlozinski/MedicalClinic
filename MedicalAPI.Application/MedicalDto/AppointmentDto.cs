using MedicalAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalDto
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
       
        public string AppointmentTitle { get; set; } = string.Empty;
        public string AppointmentDescription { get; set; } = string.Empty;
        public DateTime VisitDate { get; set; }

        public string? CreatedById { get; set; }
                                                    //potrzebny cqrs aby pozbyć się tego z dto 
        public IdentityUser? CreatedBy { get; set; }

        //  public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
