using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Entities;
using MedicalAPI.Domain.Interfaces;
using MedicalAPI.Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _dbContext.Patient.ToListAsync();
        }

        public async Task<Patient?> GetById(int id)
        {
            return await _dbContext.Patient.FirstOrDefaultAsync(p => p.PatientId == id);
        }

        public async Task Delete(int id)
        {
            var patient = await _dbContext.Patient.FirstOrDefaultAsync(p => p.PatientId == id);
            if (patient != null)
            {
                _dbContext.Patient.Remove(patient);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
