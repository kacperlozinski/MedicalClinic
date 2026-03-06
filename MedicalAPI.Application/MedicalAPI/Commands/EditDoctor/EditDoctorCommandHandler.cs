using AutoMapper;
using MediatR;
using MedicalAPI.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.EditDoctor
{
    public class EditDoctorCommandHandler : IRequestHandler<EditDoctorCommand>
    {
        private readonly IDoctorRepository _doctorRepository;

        public EditDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task Handle(EditDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetById(request.DoctorId);
            if (doctor != null)
            {
                doctor.FirstName = request.FirstName;
                doctor.LastName = request.LastName;
                doctor.SpecializationId = request.SpecializationId;
                doctor.AvailableFrom = request.AvailableFrom;
                doctor.AvailableTo = request.AvailableTo;

                await _doctorRepository.Commit();
            }
        }
    }
}
