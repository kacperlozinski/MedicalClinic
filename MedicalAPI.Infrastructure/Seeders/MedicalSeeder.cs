using MedicalAPI.Infrastructure.Presistance;
using MedicalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                if (!_dbContext.User.Any())
                {
                    var users = GetUsers();
                    _dbContext.AddRange(users);
                    await _dbContext.SaveChangesAsync(); ;
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
                    var appointments = GetAppointments();
                 
                    _dbContext.AddRange(appointments);
                    await _dbContext.SaveChangesAsync(); ;
                }
            }
        }

        private IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User { UserName = "doctor1", UserEmail = "doctor1@example.com", Password = "password1" },
                new User { UserName = "doctor2", UserEmail = "doctor2@example.com", Password = "password2" },
                new User { UserName = "patient1", UserEmail = "patient1@example.com", Password = "password3" },
                new User { UserName = "patient2", UserEmail = "patient2@example.com", Password = "password4" },
                new User { UserName = "patient3", UserEmail = "patient3@example.com", Password = "password5" }
            };
        }

        private IEnumerable<Specialization> GetSpecializations()
        {
            return new List<Specialization>
            {
                new Specialization { Name = "Cardiology", Description = "Heart and blood vessels specialist" },
                new Specialization { Name = "Dermatology", Description = "Skin specialist" }
            };
        }

        private IEnumerable<Doctor> GetDoctors()
        {
            return new List<Doctor>
            {
                new Doctor
                {
                    UserId = 1, // Id Usera z listy Users
                    FirstName = "John",
                    LastName = "Doe",
                    SpecializationId = 1, // Cardiology
                    AvailableFrom = new TimeOnly(9, 0),
                    AvailableTo = new TimeOnly(17, 0)
                },
                new Doctor
                {
                    UserId = 2, // Id Usera z listy Users
                    FirstName = "Jane",
                    LastName = "Smith",
                    SpecializationId = 2, // Dermatology
                    AvailableFrom = new TimeOnly(8, 0),
                    AvailableTo = new TimeOnly(16, 0)
                }
            };
        }

        private IEnumerable<Patient> GetPatients()
        {
            return new List<Patient>
            {
                new Patient
                {
                    UserId = 3, // Id Usera z listy Users
                    FirstName = "Alice",
                    LastName = "Johnson",
                    PhoneNumber = "123-456-7890",

                },
                new Patient
                {
                    UserId = 4, // Id Usera z listy Users
                    FirstName = "Bob",
                    LastName = "Williams",
                    PhoneNumber = "098-765-4321",

                },
                new Patient
                {
                    UserId = 5, // Id Usera z listy Users
                    FirstName = "Charlie",
                    LastName = "Brown",
                    PhoneNumber = "555-555-5555",

                }
            };
        }

        private IEnumerable<Appointment> GetAppointments()
        {
            return new List<Appointment>
            {
                new Appointment
                {
                    PatientId = 1, // Id pacjenta z listy Patients
                    DoctorId = 1,  // Id doktora z listy Doctors
                    AppointmentTitle = "Cardiology Consultation",
                    AppointmentDescription = "Consultation regarding heart health.",
                    VisitDate = DateTime.Now.AddDays(1),
                    
                },
                new Appointment
                {
                    PatientId = 2, // Id pacjenta z listy Patients
                    DoctorId = 2,  // Id doktora z listy Doctors
                    AppointmentTitle = "Skin Checkup",
                    AppointmentDescription = "Regular skin examination.",
                    VisitDate = DateTime.Now.AddDays(2)
                },
                new Appointment
                {
                    PatientId = 3, // Id pacjenta z listy Patients
                    DoctorId = 1,  // Id doktora z listy Doctors
                    AppointmentTitle = "Follow-up Cardiology Visit",
                    AppointmentDescription = "Follow-up after initial consultation.",
                    VisitDate = DateTime.Now.AddDays(3)
                }
               
            };
            
        }
    }

}

