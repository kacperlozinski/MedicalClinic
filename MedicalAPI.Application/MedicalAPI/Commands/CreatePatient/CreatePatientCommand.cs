using MediatR;
using MedicalAPI.Application.MedicalDto;

namespace MedicalAPI.Application.MedicalAPI.Commands.CreatePatient
{
    public class CreatePatientCommand : PatientDto, IRequest
    {
    }
}
