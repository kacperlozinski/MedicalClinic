using MedicalAPI.Infrastructure.Presistance;
using MedicalAPI.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAPI.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MedicalDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<MedicalSeeder>();
        }
    }
}
