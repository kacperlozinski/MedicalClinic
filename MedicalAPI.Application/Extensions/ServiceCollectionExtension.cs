using MedicalAPI.Application.ApplicationUser;
using MedicalAPI.Application.Mappings;
using MedicalAPI.Application.MedicalDto;
using MedicalAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

using MedicalAPI.Application.MedicalAPI.Commands.CreateAppointment;
using MedicalAPI.Application.MedicalAPI.Queries.GetAllCarWorkshops;


namespace MedicalAPI.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {

            services.AddScoped<IAppointmentService, AppointmentService>(); // to potem to wywalenia jak się zrobi wszystko przez mediatora

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAppointmentCommand).Assembly));

           // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAppointmentByUserIdQuery).Assembly));

            services.AddAutoMapper(typeof(AppointmentDto));

            services.AddScoped<IDoctorService,DoctorService>();

            services.AddAutoMapper(typeof(DoctorMappingProfile));

            services.AddScoped<IUserContext, UserContext>();

        }
    }
}
