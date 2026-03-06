using MediatR;
using MedicalAPI.Application.MedicalDto;
using System.Collections.Generic;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetAllPatient
{
    public class GetAllPatientQuery : IRequest<IEnumerable<PatientDto>>
    {
    }
}
