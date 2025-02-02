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
    internal class PatientRepository : IPatientRepository
    {
        private readonly MedicalDbContext _dbContext;

        public PatientRepository(MedicalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Patient patient)
        {
            _dbContext.Add(patient);
            await _dbContext.SaveChangesAsync();
        }
    }
}
