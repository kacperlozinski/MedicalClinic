using MediatR;
using MedicalAPI.Application.MedicalDto;
using System.Collections.Generic;

namespace MedicalAPI.Application.MedicalAPI.Queries.GetAllDoctor
{
    public class GetAllDoctorQuery : IRequest<IEnumerable<DoctorDto>>
    {
    }
}
