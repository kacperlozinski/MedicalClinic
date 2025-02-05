using MedicalAPI.Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;
using MedicalAPI.Infrastructure.Extensions;
using MedicalAPI.Infrastructure.Seeders;
using MedicalAPI.Application.Extensions;
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.GetConnectionString("DefaultConnection");
/*builder.Services.AddDbContext<MedicalDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")));*/
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<MedicalSeeder>();

await seeder.Seed();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();    

app.Run();
