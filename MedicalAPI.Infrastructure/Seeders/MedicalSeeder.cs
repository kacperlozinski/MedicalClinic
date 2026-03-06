using MedicalAPI.Infrastructure.Presistance;
using MedicalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicalAPI.Infrastructure.Seeders
{
    public class MedicalSeeder
    {
        private readonly MedicalDbContext _dbContext;

        public MedicalSeeder(MedicalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Specialization.Any())
                {
                    var specializations = GetSpecializations();
                    _dbContext.AddRange(specializations);
                    await _dbContext.SaveChangesAsync();
                }

                if (!_dbContext.Doctor.Any())
                {
                    var doctors = GetDoctors();
                    _dbContext.AddRange(doctors);
                    await _dbContext.SaveChangesAsync();
                }

                if (!_dbContext.Patient.Any())
                {
                    var patients = GetPatients();
                    _dbContext.AddRange(patients);
                    await _dbContext.SaveChangesAsync();
                }

                if (!_dbContext.Appointment.Any())
                {
                    var appointments = await GetAppointments();
                    _dbContext.AddRange(appointments);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Specialization> GetSpecializations()
        {
            return new List<Specialization>
            {
                new Specialization { Name = "Cardiology", Description = "Heart and blood vessels specialist" },
                new Specialization { Name = "Dermatology", Description = "Skin specialist" },
                new Specialization { Name = "Pediatrics", Description = "Child health specialist" },
                new Specialization { Name = "Neurology", Description = "Nervous system specialist" },
                new Specialization { Name = "Orthopedics", Description = "Musculoskeletal system specialist" },
                new Specialization { Name = "Ophthalmology", Description = "Eye specialist" },
                new Specialization { Name = "Psychiatry", Description = "Mental health specialist" },
                new Specialization { Name = "Gastroenterology", Description = "Digestive system specialist" },
                new Specialization { Name = "Oncology", Description = "Cancer specialist" },
                new Specialization { Name = "Urology", Description = "Urinary tract specialist" }
            };
        }

        private IEnumerable<Doctor> GetDoctors()
        {
            var doctors = new List<Doctor>();
            var firstNames = new[] { "John", "Jane", "Robert", "Mary", "Michael", "Linda", "William", "Barbara", "David", "Elizabeth", "Richard", "Susan", "Joseph", "Jessica", "Thomas", "Sarah", "Charles", "Karen", "Christopher", "Nancy" };
            var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin" };
            
            var random = new Random();
            var specCount = _dbContext.Specialization.Count();
            if (specCount == 0) specCount = 10; // Fallback if not saved yet

            for (int i = 0; i < 20; i++)
            {
                doctors.Add(new Doctor
                {
                    FirstName = firstNames[i % firstNames.Length],
                    LastName = lastNames[i % lastNames.Length],
                    SpecializationId = (i % specCount) + 1,
                    AvailableFrom = new TimeOnly(8 + (i % 2), 0),
                    AvailableTo = new TimeOnly(16 + (i % 2), 0)
                });
            }
            return doctors;
        }

        private IEnumerable<Patient> GetPatients()
        {
            var patients = new List<Patient>();
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                patients.Add(new Patient
                {
                    FirstName = $"PatientFS_{i}",
                    LastName = $"PatientLS_{i}",
                    PhoneNumber = $"555-{random.Next(100, 999)}-{random.Next(1000, 9999)}",
                    Email = $"patient{i}@example.com",
                    Password = "HashedPassword123!" // Simple placeholder
                });
            }
            return patients;
        }

        private async Task<IEnumerable<Appointment>> GetAppointments()
        {
            var appointments = new List<Appointment>();
            var random = new Random();
            
            var doctorIds = await _dbContext.Doctor.Select(d => d.DoctorId).ToListAsync();
            // In case we are seeding for the first time in one transaction and IDs are not yet available:
            if (!doctorIds.Any())
            {
                doctorIds = Enumerable.Range(1, 20).ToList();
            }

            // Start date: April 21, 2026 (assuming current year or upcoming)
            var startDate = new DateTime(2026, 4, 21);
            
            for (int i = 0; i < 500; i++)
            {
                var randomDays = random.Next(0, 180); // Next 6 months
                var randomHour = random.Next(8, 17);
                var randomMinute = random.Next(0, 4) * 15; // 0, 15, 30, 45
                
                var visitDate = startDate.AddDays(randomDays).AddHours(randomHour).AddMinutes(randomMinute);

                appointments.Add(new Appointment
                {
                    DoctorId = doctorIds[random.Next(doctorIds.Count)],
                    AppointmentTitle = $"Visit {i + 1}",
                    AppointmentDescription = $"Automated description for visit number {i + 1}.",
                    VisitDate = visitDate
                });
            }
            return appointments;
        }
    }
}
