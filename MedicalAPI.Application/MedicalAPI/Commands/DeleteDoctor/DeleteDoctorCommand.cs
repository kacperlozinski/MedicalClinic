using MediatR;

namespace MedicalAPI.Application.MedicalAPI.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest
    {
        public int DoctorId { get; set; }

        public DeleteDoctorCommand(int doctorId)
        {
            DoctorId = doctorId;
        }
    }
}
