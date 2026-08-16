using MediatR;

namespace HospitalManagementSystem.Application.Doctors.Commands.DeleteDoctor;

public record DeleteDoctorCommand(int Id) : IRequest<bool>;