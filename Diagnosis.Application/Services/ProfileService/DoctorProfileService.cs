using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Services.ProfileService
{
    public class DoctorProfileService
    {
        private readonly IAppointmentRepository _appointmentRepo;

        public DoctorProfileService(IAppointmentRepository appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        // تاريخ المواعيد للدوكتور
        public async Task<List<AppointmentHistoryDto>> GetDoctorHistory(int doctorId)
        {
            var appointments = await _appointmentRepo.GetByDoctorIdAsync(doctorId);

            return appointments.Select(a => new AppointmentHistoryDto
            {
                DoctorName = a.Doctor != null ? a.Doctor.FName + " " + a.Doctor.LName : "Unknown",
                PatientName = a.Patient != null ? a.Patient.FName + " " + a.Patient.LName : "Unknown",
                Diagnosis = a.Notes,
                Type = a.AppointmentType,
                Date = a.AppointmentDateTime
            }).ToList();
        }

        // إحصائيات عن الدكتور
        public async Task<DoctorStatisticsDto> GetDoctorStatistics(int doctorId)
        {
            var appointments = await _appointmentRepo.GetByDoctorIdAsync(doctorId);

            return new DoctorStatisticsDto
            {
                TotalAppointments = appointments.Count,
                AIConsultations = appointments.Count(a => a.AppointmentType == "AI"),
                CompletedConsultations = appointments.Count(a => a.Status == "Completed"),
                ActivePatients = appointments.Select(a => a.PatientId).Distinct().Count()
            };
        }
    }
}
