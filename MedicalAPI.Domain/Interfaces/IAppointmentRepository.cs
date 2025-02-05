using MedicalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        Task Create(Domain.Entities.Appointment appointment);  

        Task<IEnumerable<Domain.Entities.Appointment>> GetAll();

        Task<IEnumerable<Appointment>> GetAppointmentsByUserIdAsync(string userId);
    }
}
