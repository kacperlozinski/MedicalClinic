using MedicalAPI.Application.MedicalDto;

namespace MedicalAPI.Application.Services
{
    public interface IAppointmentService
    {
        Task Create(AppointmentDto appointment);

        Task<IEnumerable<AppointmentDto>> GetAll();

        Task<IEnumerable<AppointmentDto>> GetAppointmentsByUserIdAsync(string userId);
    }
}
