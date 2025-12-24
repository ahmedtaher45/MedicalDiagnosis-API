using Diagnosis.Application.DTOs;
using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;


namespace Diagnosis.Application.UseCases.Dashboard;

public class GetRecentAppointmentsUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetRecentAppointmentsUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<RecentAppointmentDto>> ExecuteAsync(int count = 10)
    {
        var appointments = await _appointmentRepository.GetRecentAsync(count);

        return appointments.Select(a => new RecentAppointmentDto
        {
            Id = a.Id,
            PatientName = a.Patient != null ? $"{a.Patient.FName} {a.Patient.LName}" : "Unknown",
            DoctorName = a.Doctor != null ? $"{a.Doctor.FName} {a.Doctor.LName}" : "Unknown",
            AppointmentDate = a.AppointmentDateTime,
            Time = a.AppointmentDateTime.ToString("hh:mm tt"),
            Status = a.Status ?? "Unknown",
            Type = a.AppointmentType ?? "General"
        }).ToList();
    }
}