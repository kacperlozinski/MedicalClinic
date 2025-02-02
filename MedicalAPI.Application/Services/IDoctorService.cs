using MedicalAPI.Domain.Entities;

namespace MedicalAPI.Application.Services
{
    public interface IDoctorService
    {
        Task Create(Doctor doctor);
    }
}