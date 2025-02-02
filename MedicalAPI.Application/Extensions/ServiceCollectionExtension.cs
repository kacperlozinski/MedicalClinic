using MedicalAPI.Application.Mappings;
using MedicalAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddAutoMapper(typeof(AppointmentMappingProfile));

            services.AddScoped<IPatientService, PatientService>();
            services.AddAutoMapper(typeof(PatientMappingProfile));   
        }
    }
}
