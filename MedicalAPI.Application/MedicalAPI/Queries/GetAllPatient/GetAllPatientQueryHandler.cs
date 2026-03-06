using AutoMapper;
using MediatR;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetAllPatient
{
    public class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, IEnumerable<PatientDto>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetAllPatientQueryHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<PatientDto>>(patients);
            return dtos;
        }
    }
}
