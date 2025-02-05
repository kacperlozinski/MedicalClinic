using MedicalAPI.Application.MedicalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.Services
{
    public interface IPatientService
    {
        Task Create(Application.MedicalDto.PatientDto patient);

        
    }
}
