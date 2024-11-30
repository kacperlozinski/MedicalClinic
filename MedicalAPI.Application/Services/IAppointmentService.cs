using MedicalAPI.Domain.Entities;

namespace MedicalAPI.Application.Services
{
    public interface IAppointmentService
    {
        Task Create(Domain.Entities.Appointment appointment);
    }
}