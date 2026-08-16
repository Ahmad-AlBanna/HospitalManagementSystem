using HospitalManagementSystem.API.Extensions;
using HospitalManagementSystem.API.Middleware;
using HospitalManagementSystem.Application.Authentication.Commands;
using HospitalManagementSystem.Infrastructure.DependencyInjection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MvcPolicy", policy =>
    {
        policy
            .WithOrigins("https://localhost:7069")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddHsts(options =>
{
    options.MaxAge = TimeSpan.FromDays(365); //default MaxAge is 30 days
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDocumentation();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddDataProtection();

builder.Services.AddApplicationAuthorization();


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(LoginCommandHandler).Assembly);
});


var app = builder.Build();


app.UseSwaggerDocumentation();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts(); // For A02:2025 - Security Misconfiguration
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("MvcPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();