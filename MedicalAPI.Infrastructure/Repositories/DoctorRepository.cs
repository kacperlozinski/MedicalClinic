using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalAPI.Domain.Interfaces;
using MedicalAPI.Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Domain.Entities.Doctor>> GetAll()
        {
            return await _dbContext.Doctor
                .Include(d => d.Specialization)
                .ToListAsync();
        }

        public async Task<Domain.Entities.Doctor?> GetById(int id)
        {
            return await _dbContext.Doctor
                .Include(d => d.Specialization)
                .FirstOrDefaultAsync(d => d.DoctorId == id);
        }

        public async Task Delete(int id)
        {
            var doctor = await _dbContext.Doctor.FirstOrDefaultAsync(d => d.DoctorId == id);
            if (doctor != null)
            {
                _dbContext.Doctor.Remove(doctor);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
