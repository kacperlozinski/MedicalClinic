using AutoMapper;
using MediatR;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetAllDoctor
{
    public class GetAllDoctorQueryHandler : IRequestHandler<GetAllDoctorQuery, IEnumerable<DoctorDto>>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public GetAllDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDto>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<DoctorDto>>(doctors);
            return dtos;
        }
    }
}
