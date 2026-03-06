using AutoMapper;
using MediatR;
using MedicalAPI.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Application.MedicalAPI.Commands.EditPatient
{
    public class EditPatientCommandHandler : IRequestHandler<EditPatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public EditPatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task Handle(EditPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetById(request.PatientId);
            if (patient != null)
            {
                patient.FirstName = request.FirstName;
                patient.LastName = request.LastName;
                patient.PhoneNumber = request.PhoneNumber;
                patient.Email = request.Email;
                // Password usually shouldn't be updated here without hashing, 
                // but let's follow existing pattern if any.
                patient.Password = request.Password;

                await _patientRepository.Commit();
            }
        }
    }
}
