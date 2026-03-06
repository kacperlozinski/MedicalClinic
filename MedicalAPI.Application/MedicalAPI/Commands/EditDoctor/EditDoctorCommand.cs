using MediatR;
using MedicalAPI.Application.MedicalDto;

namespace MedicalAPI.Application.MedicalAPI.Commands.EditDoctor
{
    public class EditDoctorCommand : DoctorDto, IRequest
    {
    }
}
