using MedicalAPI.Domain.Entities;
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
       
        public string AppointmentTitle { get; set; }
        public string AppointmentDescription { get; set; }
        public DateTime VisitDate { get; set; }

      //  public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
