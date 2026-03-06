using AutoMapper;
using MediatR;
using MedicalAPI.Domain.Entities;
using MedicalAPI.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public CreatePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Patient>(request);
            await _patientRepository.Create(patient);
        }
    }
}
