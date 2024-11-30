using MedicalAPI.Domain.Entities;
using MedicalAPI.Domain.Interfaces;
using MedicalAPI.Infrastructure.Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Infrastructure.Repositories
{
    internal class AppointmentRepository : IAppointmentRepository
    {
        private readonly MedicalDbContext _dbContext;

        public AppointmentRepository(MedicalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Appointment appointment)
        {
            _dbContext.Add(appointment);
            await _dbContext.SaveChangesAsync();

        }
    }
}
