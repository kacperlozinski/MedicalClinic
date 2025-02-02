using MedicalAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Infrastructure.Presistance
{


    public class MedicalDbContext :DbContext
    {
        public MedicalDbContext(DbContextOptions<MedicalDbContext> options):base(options) 
        {
            
        }

        public DbSet<Domain.Entities.Appointment> Appointment { get; set; }
        public DbSet<Domain.Entities.Doctor> Doctor { get; set; }
        public DbSet<Domain.Entities.Patient> Patient { get; set; }
        public DbSet<Domain.Entities.Specialization> Specialization { get; set; }
      //  public DbSet<Domain.Entities.User> User { get; set; }
       

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Medi;User Id=sa;Password=Kacper123;TrustServerCertificate=True;");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Doctors>()
         .HasKey(d => d.DoctorId);

             modelBuilder.Entity<Doctors>()
         .HasOne(d => d.User)
         .WithOne(u => u.Doctors)
         .HasForeignKey<Doctors>(d => d.UserId);


             modelBuilder.Entity<Doctors>()
         .HasMany(d => d.Patients)
         .WithOne(p => p.Doctors)
         .HasForeignKey(p => p.doctorId);


             modelBuilder.Entity<Patients>()
                 .HasOne(p => p.User)
                 .WithMany()
                 .HasForeignKey(p => p.userId)
                 .OnDelete(DeleteBehavior.Restrict);



             modelBuilder.Entity<Specialization>()
                 .HasKey(s => s.SpecId);*/

            modelBuilder.Entity<Doctor>()
              .HasMany(d => d.Appointments)
              .WithOne(p => p.Doctor)
              .HasForeignKey(p => p.DoctorId)
              .OnDelete(DeleteBehavior.Restrict);



           /* modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithMany(u => u.Patients)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);*/
/*
            modelBuilder.Entity<Doctor>()
         .HasOne(d => d.User) // Jeden Doctor ma jednego Usera
         .WithOne(u => u.Doctor) // Jeden User ma jednego Doctora
         .HasForeignKey<Doctor>(d => d.UserId) // Klucz obcy w tabeli Doctor
         .OnDelete(DeleteBehavior.Cascade); // Możesz ustawić kaskadowe usuwanie

*/
        }
    }
}
