using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Task Create(Domain.Entities.Patient patient);
        Task<IEnumerable<Domain.Entities.Patient>> GetAll();
        Task<Domain.Entities.Patient?> GetById(int id);
        Task Delete(int id);
        Task Commit();
    }
}
