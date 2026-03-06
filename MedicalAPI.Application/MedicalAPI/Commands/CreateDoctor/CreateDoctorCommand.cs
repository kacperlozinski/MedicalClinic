using MediatR;
using MedicalAPI.Application.MedicalDto;

namespace MedicalAPI.Application.MedicalAPI.Commands.CreateDoctor
{
    public class CreateDoctorCommand : DoctorDto, IRequest
    {
    }
}
