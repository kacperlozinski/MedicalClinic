using MediatR;
using MedicalAPI.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
    {
        private readonly IDoctorRepository _doctorRepository;

        public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            await _doctorRepository.Delete(request.DoctorId);
        }
    }
}
