using MediatR;
using MedicalAPI.Application.MedicalDto;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetDoctorById
{
    public class GetDoctorByIdQuery : IRequest<DoctorDto?>
    {
        public int DoctorId { get; set; }

        public GetDoctorByIdQuery(int doctorId)
        {
            DoctorId = doctorId;
        }
    }
}
