using MediatR;
using MedicalAPI.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public DeletePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            await _patientRepository.Delete(request.PatientId);
        }
    }
}
