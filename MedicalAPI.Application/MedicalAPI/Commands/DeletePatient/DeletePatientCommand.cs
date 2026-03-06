using MediatR;

namespace MedicalAPI.Application.MedicalAPI.Commands.DeletePatient
{
    public class DeletePatientCommand : IRequest
    {
        public int PatientId { get; set; }

        public DeletePatientCommand(int patientId)
        {
            PatientId = patientId;
        }
    }
}
