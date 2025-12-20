// Data/ApplicationDbContext.cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Diagnosis.Infrastracture.Configurations;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<DoctorClinic> DoctorClinics { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Billing> Billings { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
    public DbSet<LabResult> LabResults { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Treatment> Treatments { get; set; }    
    public DbSet<SideEffect> SideEffects { get; set; }

    //var seedDate = new DateTime(2024, 01, 01);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new ClinicConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorClinicConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new BillingConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionItemConfiguration());
        modelBuilder.ApplyConfiguration(new LabResultConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        modelBuilder.ApplyConfiguration(new RequestConfiguration());
        modelBuilder.ApplyConfiguration(new TreatmentConfiguration());
        //modelBuilder.ApplyConfiguration(new SideEffectConfiguration());

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

        modelBuilder.Entity<Patient>()
            .HasMany(u => u.Treatments)
            .WithOne(p => p.Patient)
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Treatment>()
            .HasMany(u => u.SideEffects)
            .WithOne(p => p.Treatment)
            .HasForeignKey(p => p.TreatmentId)
            .OnDelete(DeleteBehavior.NoAction);


        // ----------------------
        // Identity Roles
        // ----------------------
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "role-doctor", Name = "Doctor", NormalizedName = "DOCTOR" },
            new IdentityRole { Id = "role-patient", Name = "Patient", NormalizedName = "PATIENT" }
        );

        // ----------------------
        // Users
        // ----------------------
        modelBuilder.Entity<ApplicationUser>().HasData(
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
        // Clinic
        // ----------------------
        modelBuilder.Entity<Clinic>().HasData(
            new Clinic
            {
                Id = -1,
                Name = "Downtown Clinic",
                Address = "Main Street",
                City = "Cairo",
                Latitude = 30.05m,
                Longitude = 31.23m,
                Phone = "01012345789",
                Description = "General medical services",
                ModifiedOn = null,
                IsDeleted = false
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
        // DoctorClinic
        // ----------------------
        modelBuilder.Entity<DoctorClinic>().HasData(
            new DoctorClinic
            {
                Id = -1,
                DoctorId = -1,
                ClinicId = -1,
                ConsultationFees = 300,
                FollowUpFees = 150,
                ModifiedOn = null,
                IsDeleted = false
            }
        );

        // ----------------------
        // Appointment
        // ----------------------
        modelBuilder.Entity<Appointment>().HasData(
            new Appointment
            {
                Id = -1,
                PatientId = -1,
                DoctorId = -1,
                AppointmentType = "InPerson",
                Status = "Confirmed",
                ConsultationType = "General",
                Notes = "Initial Checkup",
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
        // Billing
        // ----------------------
        modelBuilder.Entity<Billing>().HasData(
            new Billing
            {
                Id = -1,
                PatientId = -1,
                PatientName = "Hager",
                AmountPaid = 250,
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
        // Request
        // ----------------------
        modelBuilder.Entity<Request>().HasData(
            new Request
            {
                Id = -1,
                PatientId = -1,
                DoctorId = -1,
                RequestType = "FollowUp",
                Status = "Pending",
                Priority = "High",
                Message = "Need urgent follow-up.",
                ModifiedOn = null,
                IsDeleted = false
            }
        );

        // ----------------------
        // Review
        // ----------------------
        modelBuilder.Entity<Review>().HasData(
            new Review
            {
                Id = -1,
                PatientId = -1,
                DoctorId = -1,
                AppointmentId = -1,
                RatingValue = 5,
                ReviewText = "Excellent doctor!",
                ModifiedOn = null,
                IsDeleted = false
            }
        );
        // ----------------------
        //treatment
        modelBuilder.Entity<Treatment>().HasData(
            new Treatment
            {
                Id = -1,
                Name = "Physical Therapy",
                Dosage = "N/A",
                Method = "In-person sessions",
                Frequency = "3 times a week",
                TotalDuration = "6 weeks",
                Alternatives = "Home exercises",
                IsActive = true,
                PatientId = -1,
                ModifiedOn = null,
                IsDeleted = false
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