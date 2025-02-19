using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Entities;
using MedicalAPI.Domain.Interfaces;
using MedicalAPI.Infrastructure.Presistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
       //     var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT AppointmentId ON");
           // appointment.CreatedById = "dupa";
            _dbContext.Add(appointment);
            await _dbContext.SaveChangesAsync();
            //await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT AppointmentId OFF");

        }

        public async  Task<IEnumerable<Appointment>> GetAll()
        => await _dbContext.Appointment.ToListAsync();

        public async Task<IEnumerable<Appointment>> GetAppointmentsByUserIdAsync(string userId)
        {
            return await _dbContext.Appointment
                .Where(a => a.CreatedById == userId)
                .ToListAsync();
        }

        public async Task<Appointment?> GetId(int id)
        {
            return await _dbContext.Appointment
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
        }

        public async Task<Appointment> GetAppointmentById(int id)
        => await _dbContext.Appointment.FirstOrDefaultAsync(a => a.AppointmentId == id);


    }
}
