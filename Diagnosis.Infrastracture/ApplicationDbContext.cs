// Data/ApplicationDbContext.cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
    public DbSet<LabResult> LabResults { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<DoctorDiagnosis> Diagnosises { get; set; }
    public DbSet<Symptom> Symptoms { get; set; }
    public DbSet<ClinicalFinding> ClinicalFindings { get; set; }
    public DbSet<SuggestedMedication> SuggestedMedications { get; set; }
    public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionItemConfiguration());
        modelBuilder.ApplyConfiguration(new LabResultConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());

        modelBuilder.Entity<ApplicationUser>()
        .HasOne(u => u.Doctor)
        .WithOne(d => d.User)
        .HasForeignKey<Doctor>(d => d.UserId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(u => u.Patient)
            .WithOne(p => p.User)
            .HasForeignKey<Patient>(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Notifications)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity <Consultation>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Doctor>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<LabResult>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Notification>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Patient>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Payment>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Prescription>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<PrescriptionItem>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Consultation>()
            .Property(c => c.Status)
            .HasConversion<string>();


        modelBuilder.Entity<Consultation>()
            .Property(c => c.Type)
            .HasConversion<string>();

        modelBuilder.Entity<Notification>()
            .Property(p => p.NotificationType)
            .HasConversion<string>();

        modelBuilder.Entity<DoctorDiagnosis>(d => 
        {
            d.HasMany(c => c.Symptoms)
            .WithOne(c => c.Diagnosis)
            .HasForeignKey(c => c.DiagnosisId)
            .OnDelete(DeleteBehavior.NoAction);

            d.HasMany(d => d.SuggestedMedications)
            .WithOne(c => c.Diagnosis)
            .HasForeignKey(c => c.DiagnosisId)
            .OnDelete(DeleteBehavior.NoAction);

            d.HasMany(d => d.ClinicalFindings)
            .WithOne(c => c.Diagnosis)
            .HasForeignKey(d => d.DiagnosisId)
            .OnDelete(DeleteBehavior.NoAction);
        });


        // ================== 1 ====================
        modelBuilder.Entity<DoctorDiagnosis>().HasData(
            new DoctorDiagnosis
            {
                Id = 1,
                Title = "Cold & Flu",
                Name = "Upper Respiratory Infection",
                Description = "Viral infection affecting upper respiratory tract",
                PatientSymptoms = "Fever, cough, sore throat, runny nose"
            }
            );

        modelBuilder.Entity<Symptom>().HasData(
            new Symptom { Id = 1, Name = "Fever", DiagnosisId = 1 },
            new Symptom { Id = 2, Name = "Cough", DiagnosisId = 1 },
            new Symptom { Id = 3, Name = "Sore throat", DiagnosisId = 1 },
            new Symptom { Id = 4, Name = "Runny nose", DiagnosisId = 1 },
            new Symptom { Id = 5, Name = "Body aches", DiagnosisId = 1 }
        );

        modelBuilder.Entity<ClinicalFinding>().HasData(

            new ClinicalFinding { Id = 1, Name = "Body Temperature", Value = "38.5°C", Notes = "Fever", DiagnosisId = 1 },
            new ClinicalFinding { Id = 2, Name = "Oxygen Saturation", Value = "98%", Notes = "Normal", DiagnosisId = 1 }

        );

        modelBuilder.Entity<SuggestedMedication>().HasData(
            new SuggestedMedication
            {
                Id = 1,
                Name = "Paracetamol",
                Dosage = "500 mg",
                Frequency = "Every 8 hours",
                DiagnosisId = 1
            },
            new SuggestedMedication
            {
                Id = 2,
                Name = "Antihistamine",
                Dosage = "10 mg",
                Frequency = "Once daily",
                DiagnosisId = 1
            }

        );

        //============== 2 ================

        modelBuilder.Entity<DoctorDiagnosis>().HasData(
            new DoctorDiagnosis
            {
                Id = 2,
                Title = "Stomach Pain",
                Name = "Gastritis",
                Description = "Inflammation of stomach lining",
                PatientSymptoms = "Abdominal pain, nausea, vomiting"
            }
         );

        modelBuilder.Entity<Symptom>().HasData(
            new Symptom { Id = 6, Name = "Abdominal pain", DiagnosisId = 2 },
            new Symptom { Id = 7, Name = "Nausea", DiagnosisId = 2 },
            new Symptom { Id = 8, Name = "Vomiting", DiagnosisId = 2 },
            new Symptom { Id = 9, Name = "Bloating", DiagnosisId = 2 }

        );

        modelBuilder.Entity<ClinicalFinding>().HasData(

           new ClinicalFinding { Id = 3, Name = "Abdominal tenderness", Value = "Present", Notes = "Epigastric area", DiagnosisId = 2 }
        );

        modelBuilder.Entity<SuggestedMedication>().HasData(
            new SuggestedMedication
            {
                Id = 3,
                Name = "Omeprazole",
                Dosage = "20 mg",
                Frequency = "Once daily before meals",
                DiagnosisId = 2
            },
            new SuggestedMedication
            {
                Id = 4,
                Name = "Antacid",
                Dosage = "10 ml",
                Frequency = "After meals",
                DiagnosisId = 2
            }
        );


        // =============== 3 ===============

        modelBuilder.Entity<DoctorDiagnosis>().HasData(
            new DoctorDiagnosis
                {
                    Id = 3,
                    Title = "Hypertension",
                    Name = "High Blood Pressure",
                    Description = "Chronic elevation of blood pressure",
                    PatientSymptoms = "Headache, dizziness, blurred vision"
                }

         );

        modelBuilder.Entity<Symptom>().HasData(
            new Symptom { Id = 10, Name = "Headache", DiagnosisId = 3 },
            new Symptom { Id = 11, Name = "Dizziness", DiagnosisId = 3 },
            new Symptom { Id = 12, Name = "Blurred vision", DiagnosisId = 3 }
        );

        modelBuilder.Entity<ClinicalFinding>().HasData(

            new ClinicalFinding
            {
                Id = 4,
                Name = "Blood Pressure",
                Value = "150/95 mmHg",
                Notes = "Elevated",
                DiagnosisId = 3
            }
        );

        modelBuilder.Entity<SuggestedMedication>().HasData(
            new SuggestedMedication
            {
                Id = 5,
                Name = "Amlodipine",
                Dosage = "5 mg",
                Frequency = "Once daily",
                DiagnosisId = 3
            },
            new SuggestedMedication
            {
                Id = 6,
                Name = "Lifestyle modification",
                Dosage = "-",
                Frequency = "Low salt diet & exercise",
                DiagnosisId = 3
            }
        );

        // ================= 4 =================

        modelBuilder.Entity<DoctorDiagnosis>().HasData(
            new DoctorDiagnosis
            {
                Id = 4,
                Title = "Diabetes Follow-up",
                Name = "Type 2 Diabetes Mellitus",
                Description = "Routine diabetes follow-up and monitoring",
                PatientSymptoms = "Fatigue, frequent urination"
            }

         );

        modelBuilder.Entity<Symptom>().HasData(
        new Symptom { Id = 13, Name = "Fatigue", DiagnosisId = 4 },
        new Symptom { Id = 14, Name = "Frequent urination", DiagnosisId = 4 }

        );

        modelBuilder.Entity<ClinicalFinding>().HasData(
            new ClinicalFinding
            {
                Id = 5,
                Name = "HbA1c",
                Value = "7.1%",
                Notes = "Above target",
                DiagnosisId = 4
            },
            new ClinicalFinding
            {
                Id = 6,
                Name = "Fasting Blood Glucose",
                Value = "140 mg/dL",
                Notes = "Elevated",
                DiagnosisId = 4
            }

        );

        modelBuilder.Entity<SuggestedMedication>().HasData(
            new SuggestedMedication
            {
                Id = 7,
                Name = "Metformin",
                Dosage = "500 mg",
                Frequency = "Twice daily",
                DiagnosisId = 4
            }
        );


        // ----------------------
        // Identity Roles
        // ----------------------
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "role-admin", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "role-doctor", Name = "Doctor", NormalizedName = "DOCTOR" },
            new IdentityRole { Id = "role-patient", Name = "Patient", NormalizedName = "PATIENT" }
        );

        // ----------------------
        // Users
        // ----------------------
        modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "user-0",
                UserName = "admin@diagnosis.com",
                NormalizedUserName = "ADMIN@DIAGNOSIS.COM",
                Email = "admin@diagnosis.com",
                NormalizedEmail = "ADMIN@DIAGNOSIS.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = ""
            },
            new ApplicationUser
            {
                Id = "user-1",
                UserName = "doctor@test.com",
                NormalizedUserName = "DOCTOR@TEST.COM",
                Email = "doctor@test.com",
                NormalizedEmail = "DOCTOR@TEST.COM",
                EmailConfirmed = true,
                SecurityStamp = "stamp1",
                PasswordHash = ""
            },
            new ApplicationUser
            {
                Id = "user-2",
                UserName = "patient@test.com",
                NormalizedUserName = "PATIENT@TEST.COM",
                Email = "patient@test.com",
                NormalizedEmail = "PATIENT@TEST.COM",
                EmailConfirmed = true,
                SecurityStamp = "stamp2",
                PasswordHash = ""
            }
        );

        // ----------------------
        // Doctor
        // ----------------------
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                Id = -1,
                UserId = "user-1",
                FName = "Ahmed",
                LName = "Mahmoud",
                Specialization = "Dermatology",
                Bio = "Skin specialist",
                ExperienceYears = 8,
                Rating = 4.7m,
                LicenseNumber = "LIC-001",
                ProfileImageUrl = "",
                ModifiedOn = null,
                IsDeleted = false
            }
        );

        // ----------------------
        // Patient
        // ----------------------
        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                Id = -1,
                UserId = "user-2",
                FName = "Sara",
                LName = "Ali",
                DateOfBirth = new DateTime(1996, 6, 15),
                Gender = "Female",
                Address = "Cairo",
                BloodType = "A+",
                Allergies = "None",
                ProfileImageUrl = "",
                IsNewPatient = true,
                IsUrgent = false,
                ModifiedOn = null,
                IsDeleted = false
            }
        );


        // ----------------------
        // Prescription
        // ----------------------
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                Id = -1,
                AppointmentId = -1,
                DoctorId = -1,
                PatientId = -1,
                Specialization = "Dermatology",
                Notes = "Use cream twice daily",
                DiagnosisName = "Skin Irritation",
                Severity = "Mild",
                ModifiedOn = null,
                IsDeleted = false
            }
        );

        // ----------------------
        // PrescriptionItem
        // ----------------------
        modelBuilder.Entity<PrescriptionItem>().HasData(
            new PrescriptionItem
            {
                Id = -1,
                PrescriptionId = -1,
                MedicineName = "Skin Cream",
                ModifiedOn = null,
                IsDeleted = false
            }
        );

        // ----------------------
        // Payment
        // ----------------------
        modelBuilder.Entity<Payment>().HasData(
            new Payment
            {
                Id = -1,
                DoctorId = -1,
                AppointmentId = -1,
                Amount = 300,
                PaymentMethod = "Cash",
                PaymentStatus = "Paid",
                Notes = "",
                ModifiedOn = null,
                IsDeleted = false
            }
        );

        // ----------------------
        // LabResult
        // ----------------------
        modelBuilder.Entity<LabResult>().HasData(
            new LabResult
            {
                Id = -1,
                PatientId = -1,
                DoctorId = -1,
                TestName = "Blood Test",
                ResultValue = "Normal",
                ResultStatus = "Completed",
                LabNotes = "Good condition",
                FileUrl = "",
                ModifiedOn = null,
                IsDeleted = false
            }
        );

        // ----------------------
        // Notification
        // ----------------------
        modelBuilder.Entity<Notification>().HasData(
            new Notification
            {
                Id = -1,
                UserId = "user-2",
                UserType = "Patient",
                Title = "Appointment Confirmed",
                Message = "Your appointment is confirmed.",
                NotificationType = "Appointment",
                IsRead = false,
                RelatedId = -1,
                RelatedType = "Appointment",
                ReadAt = null,
                ModifiedOn = null,
                IsDeleted = false
            }
        );


        // ----------------------
        // Consultation
        // ----------------------
        modelBuilder.Entity<Consultation>().HasData(
            new Consultation
            {
                Id = 1,
                PatientId = -1,
                DoctorId = -1,
                Symptoms = "Headache, fever, and fatigue.",
                Notes = "Patient reports symptoms for 3 days.",
                Status = ConsultationStatus.Pending,
                Type = ConsultationType.Inquiry,
                Date = new DateTime(2025, 1, 1),
                ConfidenceLevel = 0,
                Description = "General inquiry about symptoms"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(w =>
         w.Ignore(RelationalEventId.PendingModelChangesWarning));

    }
}