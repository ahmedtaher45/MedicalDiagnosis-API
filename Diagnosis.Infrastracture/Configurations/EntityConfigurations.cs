// Configurations/EntityConfigurations.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PatientConfiguration : IEntityTypeConfiguration <Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.PatientId);

        // One-to-Many: Patient -> Appointments
        builder.HasMany(p => p.Appointments)
               .WithOne(a => a.Patient)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Patient -> Prescriptions (through Appointments)
        builder.HasMany(p => p.Prescriptions)
               .WithOne()
               .HasForeignKey(p => p.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Patient -> LabResults
        builder.HasMany(p => p.LabResults)
               .WithOne(l => l.Patient)
               .HasForeignKey(l => l.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Patient -> Reviews
        builder.HasMany(p => p.Reviews)
               .WithOne(r => r.Patient)
               .HasForeignKey(r => r.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Patient -> Billings
        builder.HasMany(p => p.Billings)
               .WithOne(b => b.Patient)
               .HasForeignKey(b => b.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Patient -> Requests
        builder.HasMany(p => p.Requests)
               .WithOne(r => r.Patient)
               .HasForeignKey(r => r.PatientId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.DoctorId);
        builder.HasIndex(d => d.Email).IsUnique();

        // One-to-Many: Doctor -> Appointments
        builder.HasMany(d => d.Appointments)
               .WithOne(a => a.Doctor)
               .HasForeignKey(a => a.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Doctor -> DoctorClinics
        builder.HasMany(d => d.DoctorClinics)
               .WithOne(dc => dc.Doctor)
               .HasForeignKey(dc => dc.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Doctor -> Payments
        builder.HasMany(d => d.Payments)
               .WithOne(p => p.Doctor)
               .HasForeignKey(p => p.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Doctor -> Prescriptions
        builder.HasMany(d => d.Prescriptions)
               .WithOne()
               .HasForeignKey(p => p.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Doctor -> LabResults
        builder.HasMany(d => d.LabResults)
               .WithOne(l => l.Doctor)
               .HasForeignKey(l => l.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Doctor -> Reviews
        builder.HasMany(d => d.Reviews)
               .WithOne(r => r.Doctor)
               .HasForeignKey(r => r.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many: Doctor -> Requests
        builder.HasMany(d => d.Requests)
               .WithOne(r => r.Doctor)
               .HasForeignKey(r => r.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.HasKey(c => c.ClinicId);

        // One-to-Many: Clinic -> DoctorClinics
        builder.HasMany(c => c.DoctorClinics)
               .WithOne(dc => dc.Clinic)
               .HasForeignKey(dc => dc.ClinicId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

public class DoctorClinicConfiguration : IEntityTypeConfiguration<DoctorClinic>
{
    public void Configure(EntityTypeBuilder<DoctorClinic> builder)
    {
        builder.HasKey(dc => dc.DoctorClinicId);

        // Composite key alternative for many-to-many
        builder.HasIndex(dc => new { dc.DoctorId, dc.ClinicId }).IsUnique();
    }
}

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.AppointmentId);

        // Indexes
        builder.HasIndex(a => a.AppointmentDateTime)
               .HasDatabaseName("idx_appointment_date");
        builder.HasIndex(a => a.Status)
               .HasDatabaseName("idx_status");

        // One-to-One: Appointment -> Prescription
        builder.HasOne(a => a.Prescription)
               .WithOne(p => p.Appointment)
               .HasForeignKey<Prescription>(p => p.AppointmentId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-One: Appointment -> Review
        builder.HasOne(a => a.Review)
               .WithOne(r => r.Appointment)
               .HasForeignKey<Review>(r => r.AppointmentId)
               .OnDelete(DeleteBehavior.SetNull);

        // One-to-Many: Appointment -> Payments
        builder.HasMany(a => a.Payments)
               .WithOne(p => p.Appointment)
               .HasForeignKey(p => p.AppointmentId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.PaymentId);
        builder.HasIndex(p => p.PaymentDate)
               .HasDatabaseName("idx_payment_date");
    }
}

public class BillingConfiguration : IEntityTypeConfiguration<Billing>
{
    public void Configure(EntityTypeBuilder<Billing> builder)
    {
        builder.HasKey(b => b.BillingId);
        builder.HasIndex(b => b.AppointmentDate)
               .HasDatabaseName("idx_appointment_date");
    }
}

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.PrescriptionId);

        // One-to-Many: Prescription -> PrescriptionItems
        builder.HasMany(p => p.PrescriptionItems)
               .WithOne(pi => pi.Prescription)
               .HasForeignKey(pi => pi.PrescriptionId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

public class PrescriptionItemConfiguration : IEntityTypeConfiguration<PrescriptionItem>
{
    public void Configure(EntityTypeBuilder<PrescriptionItem> builder)
    {
        builder.HasKey(pi => pi.ItemId);
    }
}

public class LabResultConfiguration : IEntityTypeConfiguration<LabResult>
{
    public void Configure(EntityTypeBuilder<LabResult> builder)
    {
        builder.HasKey(l => l.ResultId);
    }
}

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.ReviewsId);

        // Check constraint for rating value
        builder.HasCheckConstraint("CK_Review_RatingValue", "rating_value >= 0 AND rating_value <= 5");
    }
}

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(n => n.NotificationId);

        // Indexes
        builder.HasIndex(n => new { n.UserId, n.IsRead })
               .HasDatabaseName("idx_user_unread");
        builder.HasIndex(n => n.CreatedAt)
               .HasDatabaseName("idx_created_at");
    }
}

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(r => r.RequestId);
    }
}