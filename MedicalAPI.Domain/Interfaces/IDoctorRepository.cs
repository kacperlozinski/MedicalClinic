using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        Task Create(Domain.Entities.Doctor doctor);
    }
}
