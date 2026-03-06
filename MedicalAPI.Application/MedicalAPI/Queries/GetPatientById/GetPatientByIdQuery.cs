using MediatR;
using MedicalAPI.Application.MedicalDto;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetPatientById
{
    public class GetPatientByIdQuery : IRequest<PatientDto?>
    {
        public int PatientId { get; set; }

        public GetPatientByIdQuery(int patientId)
        {
            PatientId = patientId;
        }
    }
}
