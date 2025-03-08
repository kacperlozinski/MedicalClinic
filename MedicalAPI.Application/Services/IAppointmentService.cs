using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Entities;

namespace MedicalAPI.Application.Services
{
    public interface IAppointmentService
    {
       /* Task Create(AppointmentDto appointment);

        Task<IEnumerable<AppointmentDto>> GetAll();*/
        /*Task<IEnumerable<AppointmentDto>> GetAppointmentsByUserIdAsync(string userId);*/
        //not needed
        Task<AppointmentDto?> GetByIdAsync(int id);

    }
}