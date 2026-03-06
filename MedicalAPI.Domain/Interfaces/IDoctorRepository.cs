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
        Task<IEnumerable<Domain.Entities.Doctor>> GetAll();
        Task<Domain.Entities.Doctor?> GetById(int id);
        Task Delete(int id);
        Task Commit();
    }
}
