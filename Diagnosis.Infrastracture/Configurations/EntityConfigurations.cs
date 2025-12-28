    using Diagnosis.Domain.Entites;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PatientConfiguration : IEntityTypeConfiguration <Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

        

            builder.HasMany(p => p.Consultations)
                   .WithOne(a => a.Patient)
                   .HasForeignKey(a => a.PatientId)
                   .OnDelete(DeleteBehavior.NoAction);

        // One-to-Many: Patient -> Prescriptions (through Appointments)
        builder.HasMany(p => p.Prescriptions)
                   .WithOne(d => d.Patient)
                   .HasForeignKey(p => p.PatientId)
                   .OnDelete(DeleteBehavior.NoAction);

            // One-to-Many: Patient -> LabResults
            builder.HasMany(p => p.LabResults)
                   .WithOne(l => l.Patient)
                   .HasForeignKey(l => l.PatientId)
                   .OnDelete(DeleteBehavior.NoAction);

          
    }
    }

    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasMany(d => d.Consultations)
                   .WithOne(a => a.Doctor)
                   .HasForeignKey(a => a.DoctorId)
                   .OnDelete(DeleteBehavior.NoAction);

            // One-to-Many: Doctor -> Payments
            builder.HasMany(d => d.Payments)
                   .WithOne(p => p.Doctor)
                   .HasForeignKey(p => p.DoctorId)
                   .OnDelete(DeleteBehavior.NoAction);

            // One-to-Many: Doctor -> Prescriptions
            builder.HasMany(d => d.Prescriptions)
                   .WithOne(p => p.Doctor)
                   .HasForeignKey(p => p.DoctorId)
                   .OnDelete(DeleteBehavior.NoAction);

            // One-to-Many: Doctor -> LabResults
            builder.HasMany(d => d.LabResults)
                   .WithOne(l => l.Doctor)
                   .HasForeignKey(l => l.DoctorId)
                   .OnDelete(DeleteBehavior.NoAction);

            // One-to-Many: Doctor -> Prescriptions
           

    }
    }

    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.PaymentDate)
                   .HasDatabaseName("idx_payment_date");
        }
    }

    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.Id);

            // One-to-Many: Prescription -> PrescriptionItems
            builder.HasMany(p => p.PrescriptionItems)
                   .WithOne(pi => pi.Prescription)
                   .HasForeignKey(pi => pi.PrescriptionId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }

    public class PrescriptionItemConfiguration : IEntityTypeConfiguration<PrescriptionItem>
    {
        public void Configure(EntityTypeBuilder<PrescriptionItem> builder)
        {
            builder.HasKey(pi => pi.Id);
        }
    }

    public class LabResultConfiguration : IEntityTypeConfiguration<LabResult>
    {
        public void Configure(EntityTypeBuilder<LabResult> builder)
        {
            builder.HasKey(l => l.Id);
        }
    }


    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            // Indexes
            builder.HasIndex(n => new { n.UserId, n.IsRead })
                   .HasDatabaseName("idx_user_unread");
            builder.HasIndex(n => n.CreatedOn)
                   .HasDatabaseName("idx_created_at");
        }
    }
