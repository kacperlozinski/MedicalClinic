using AutoMapper;
using MediatR;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetDoctorById
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDto?>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public GetDoctorByIdQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<DoctorDto?> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetById(request.DoctorId);
            var dto = _mapper.Map<DoctorDto?>(doctor);
            return dto;
        }
    }
}
