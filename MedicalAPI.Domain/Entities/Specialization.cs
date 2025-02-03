using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Domain.Entities
{
    public class Specialization
    {
        [Key]
        public int SpecId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        /* public virtual Doctors Doctors { get; set; }*/

        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
