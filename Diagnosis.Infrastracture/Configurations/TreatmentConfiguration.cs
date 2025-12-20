using Diagnosis.Domain.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Configurations
{
    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.ToTable("Treatments");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Dosage)
                .HasMaxLength(100);

            builder.Property(t => t.Method)
                .HasMaxLength(100);

            builder.Property(t => t.Frequency)
                .HasMaxLength(100);

            builder.Property(t => t.TotalDuration)
                .HasMaxLength(100);

            builder.Property(t => t.Alternatives)
                .HasMaxLength(500);

            builder.Property(t => t.IsActive)
                .IsRequired();

            builder.HasOne(t => t.Patient)
                .WithMany() // No navigation property on Patient for Treatment
                .HasForeignKey(t => t.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
