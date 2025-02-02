using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalAPI.Domain.Interfaces;
using MedicalAPI.Infrastructure.Presistance;

namespace MedicalAPI.Infrastructure.Repositories
{
    internal class DoctorRepository : IDoctorRepository
    {
        private readonly MedicalDbContext _dbContext;

        public DoctorRepository(MedicalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Domain.Entities.Doctor doctor)
        {
            _dbContext.Add(doctor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
