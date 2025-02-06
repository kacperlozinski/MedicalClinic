using AutoMapper;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public async Task Create(PatientDto patientDto)
        {

            var patient = _mapper.Map<Domain.Entities.Patient>(patientDto);

           // await _patientRepository.Create(patient);
            await _patientRepository.Create(patient);
            
        }
    }
}
