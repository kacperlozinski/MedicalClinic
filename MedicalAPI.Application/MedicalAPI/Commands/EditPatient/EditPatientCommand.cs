using MediatR;
using MedicalAPI.Application.MedicalDto;

namespace MedicalAPI.Application.MedicalAPI.Commands.EditPatient
{
    public class EditPatientCommand : PatientDto, IRequest
    {
    }
}
