using AutoMapper;
using MediatR;
using MedicalAPI.Domain.Entities;
using MedicalAPI.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<Doctor>(request);
            await _doctorRepository.Create(doctor);
        }
    }
}
