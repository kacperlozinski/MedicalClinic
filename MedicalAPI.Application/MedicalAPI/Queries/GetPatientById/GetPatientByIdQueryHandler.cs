using AutoMapper;
using MediatR;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetPatientById
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDto?>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetPatientByIdQueryHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<PatientDto?> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetById(request.PatientId);
            var dto = _mapper.Map<PatientDto?>(patient);
            return dto;
        }
    }
}
