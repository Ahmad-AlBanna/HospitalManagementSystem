using MediatR;

public record BookAppointmentCommand
(
    int PatientId,
    int DoctorId,
    DateTime AppointmentDate,
    string Notes,
    int UserId
)
    : IRequest<int>;
