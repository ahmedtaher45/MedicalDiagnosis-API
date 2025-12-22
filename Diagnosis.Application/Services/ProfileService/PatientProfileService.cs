using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Services.ProfileService
{
    public class PatientProfileService
    {
       
        
            private readonly IAppointmentRepository _appointmentRepo;

            public PatientProfileService(IAppointmentRepository appointmentRepo)
            {
                _appointmentRepo = appointmentRepo;
            }

            public async Task<List<AppointmentHistoryDto>> GetPatientHistory(int patientId)
            {
                var appointments = await _appointmentRepo.GetByPatientIdAsync(patientId);

                return appointments.Select(a => new AppointmentHistoryDto
                {
                    DoctorName = a.Doctor.FName + " " + a.Doctor.LName,
                    PatientName = a.Patient.FName + " " + a.Patient.LName,
                    Diagnosis = a.Notes, // Changed from a.Diagnosis to a.Notes
                    Type = a.AppointmentType, // Changed from a.Type to a.AppointmentType
                    Date = a.AppointmentDateTime // Added missing Date property
                }).ToList();
            }
     }
}
