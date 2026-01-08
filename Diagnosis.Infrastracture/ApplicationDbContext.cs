using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<SupportTicket> SupportTickets { get; set; }
    public DbSet<PhysiotherapyExercise> PhysiotherapyExercises { get; set; }
    public DbSet<Drug> Drugs { get; set; }
    public DbSet<Inquiry> Inquiries { get; set; }
    public DbSet<BoneFraction> BoneFractions { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<UserAIUsage> Usages { get; set; }
    public DbSet<UsageConfig> UsageConfig { get; set; }
    public DbSet<MedicalFiles> MedicalFiles { get; set; }
    public DbSet<PregnancyRiskCategory> PregnancyRiskCategory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
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
            .HasOne(u => u.Usage)
            .WithOne(p => p.User)
            .HasForeignKey<UserAIUsage>(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ApplicationUser>()
          .HasMany(u => u.SupportTickets)
          .WithOne(p => p.User)
          .HasForeignKey(p => p.userId)
          .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Notifications)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Inquiry>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");


        modelBuilder.Entity<BoneFraction>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Doctor>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<MedicalFiles>()
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


        modelBuilder.Entity<Inquiry>()
            .Property(c => c.Status)
            .HasConversion<string>();


        modelBuilder.Entity<Notification>()
            .Property(p => p.NotificationType)
            .HasConversion<string>();

        modelBuilder.Entity<MedicalFiles>()
            .Property(p => p.Type)
            .HasConversion<string>();

        modelBuilder.Entity<Request>()
        .Property(p => p.Status)
        .HasConversion<string>();

        modelBuilder.Entity<Faq>()
            .Property(p => p.Type)
            .HasConversion<string>();


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
                ExperienceYears = 8,
                Rating = 4.7m,
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
        // Notification
        // ----------------------
        modelBuilder.Entity<Notification>().HasData(
            new Notification
            {
                Id = -1,
                UserId = "user-2",
                Title = "Appointment Confirmed",
                Message = "Your appointment is confirmed.",
                NotificationType = NotificationType.Consultation,
                IsRead = false,
                RelatedId = -1,
                ModifiedOn = null,
                IsDeleted = false
            }
        );


        // ----------------------
        // Consultation
        // ----------------------
        modelBuilder.Entity<Inquiry>().HasData(
            new Inquiry
            {
                Id = 1,
                PatientId = -1,
                DoctorId = -1,
                Symptoms = "Headache, fever, and fatigue.",
                Description = "Patient reports symptoms for 3 days.",
                Status = ConsultationStatus.Pending
            }
        );

        modelBuilder.Entity<PregnancyRiskCategory>().HasData(
            new PregnancyRiskCategory
            {
                Id = 1,
                Category = "A",
                RiskLevel = "Very Low",
                RecommendedAction = "Safe to use during pregnancy"
            },
            new PregnancyRiskCategory
            {
                Id = 2,
                Category = "B",
                RiskLevel = "Low",
                RecommendedAction = "Use with caution and under doctor supervision"
            },
            new PregnancyRiskCategory
            {
                Id = 3,
                Category = "C",
                RiskLevel = "Moderate",
                RecommendedAction = "Use only if benefits outweigh risks"
            },
            new PregnancyRiskCategory
            {
                Id = 4,
                Category = "D",
                RiskLevel = "High",
                RecommendedAction = "Use only in necessary cases and under strict monitoring"
            },
            new PregnancyRiskCategory
            {
                Id = 5,
                Category = "X",
                RiskLevel = "Very High",
                RecommendedAction = "Contraindicated during pregnancy"
            },
            new PregnancyRiskCategory
            {
                Id = 6,
                Category = "N",
                RiskLevel = "Unknown",
                RecommendedAction = "Consult a doctor before use; exercise caution"
            }
        );

        modelBuilder.Entity<Drug>().HasData(
        new Drug
        {
            Id = 1,
            DrugName = "doxycycline",
            RxOtc = "Rx",
            DrugClasses = "Miscellaneous antimalarials, Tetracyclines",
            Csa = "N",
            Alcohol = "X",
            GenericName = "doxycycline",
            MedicalCondition = "Acne",
            Activity = 87
        },
        new Drug
        {
            Id = 2,
            DrugName = "spironolactone",
            RxOtc = "Rx",
            DrugClasses = "Aldosterone receptor antagonists, Potassium-sparing diuretics",
            Csa = "N",
            Alcohol = "X",
            GenericName = "spironolactone",
            MedicalCondition = "Acne",
            Activity = 82
        },
        new Drug
        {
            Id = 3,
            DrugName = "minocycline",
            RxOtc = "Rx",
            DrugClasses = "Tetracyclines",
            Csa = "N",
            Alcohol = "Unknown",
            GenericName = "minocycline",
            MedicalCondition = "Acne",
            Activity = 48
        },
        new Drug
        {
            Id = 4,
            DrugName = "Accutane",
            RxOtc = "Rx",
            DrugClasses = "Miscellaneous antineoplastics",
            Csa = "N",
            Alcohol = "X",
            GenericName = "isotretinoin (oral)",
            MedicalCondition = "Acne",
            Activity = 41
        },
        new Drug
        {
            Id = 5,
            DrugName = "clindamycin",
            RxOtc = "Rx",
            DrugClasses = "Topical acne agents, Vaginal anti-infectives",
            Csa = "N",
            Alcohol = "Unknown",
            GenericName = "clindamycin topical",
            MedicalCondition = "Acne",
            Activity = 39
        },
        new Drug
        {
            Id = 6,
            DrugName = "Aldactone",
            RxOtc = "Rx",
            DrugClasses = "Aldosterone receptor antagonists, Potassium-sparing diuretics",
            Csa = "N",
            Alcohol = "X",
            GenericName = "spironolactone",
            MedicalCondition = "Acne",
            Activity = 35
        },
        new Drug
        {
            Id = 7,
            DrugName = "tretinoin",
            RxOtc = "Rx",
            DrugClasses = "Topical acne agents",
            Csa = "N",
            Alcohol = "Unknown",
            GenericName = "tretinoin topical",
            MedicalCondition = "Acne",
            Activity = 30
        },
        new Drug
        {
            Id = 8,
            DrugName = "isotretinoin",
            RxOtc = "Rx",
            DrugClasses = "Miscellaneous antineoplastics",
            Csa = "N",
            Alcohol = "X",
            GenericName = "isotretinoin (oral)",
            MedicalCondition = "Acne",
            Activity = 26
        },
        new Drug
        {
            Id = 9,
            DrugName = "Bactrim",
            RxOtc = "Rx",
            DrugClasses = "Sulfonamides",
            Csa = "N",
            Alcohol = "X",
            GenericName = "sulfamethoxazole and trimethoprim",
            MedicalCondition = "Acne",
            Activity = 20
        },
        new Drug
        {
            Id = 10,
            DrugName = "Retin-A",
            RxOtc = "Rx",
            DrugClasses = "Topical acne agents",
            Csa = "N",
            Alcohol = "Unknown",
            GenericName = "Retin-A",
            MedicalCondition = "Acne",
            Activity = 17
        }
    );

        // --------------------
        // Faq
        // --------------------

        modelBuilder.Entity<Faq>().HasData(
        new Faq
        {
            Id = 1,
            Type = FaqType.Patient,
            Question = "How can I book an appointment?",
            Answer = "You can book an appointment through the mobile application."
        },
        new Faq
        {
            Id = 2,
            Type = FaqType.Patient,
            Question = "Can I cancel or reschedule my appointment?",
            Answer = "Yes, you can cancel or reschedule your appointment from your profile."
        },
        new Faq
        {
            Id = 3,
            Type = FaqType.Patient,
            Question = "How do I view my medical history?",
            Answer = "Your medical history is available in the medical records section."
        },
        new Faq
        {
            Id = 4,
            Type = FaqType.Patient,
            Question = "Is my personal data secure?",
            Answer = "Yes, all your data is securely stored and protected."
        },

    // Doctor FAQs
        new Faq
        {
            Id = 5,
            Type = FaqType.Doctor,
            Question = "How can I manage my appointments?",
            Answer = "You can manage your appointments from the doctor dashboard."
        },
        new Faq
        {
            Id = 6,
            Type = FaqType.Doctor,
            Question = "How do I update my availability?",
            Answer = "You can update your availability from your profile settings."
        },
        new Faq
        {
            Id = 7,
            Type = FaqType.Doctor,
            Question = "Can I access patient medical records?",
            Answer = "Yes, you can access medical records for patients assigned to you."
        },
        new Faq
        {
            Id = 8,
            Type = FaqType.Doctor,
            Question = "How do I receive payments?",
            Answer = "Payments are transferred to your registered bank account."
        }
        );  


        modelBuilder.Entity<PhysiotherapyExercise>().HasData(

        // 🔹 BACK
        new PhysiotherapyExercise
        {
            Id = 1,
            Title = "Back Stretch Exercise",
            BodyPart = "Back",
            Difficulty = "Easy",
            DurationMinutes = 4,
            YoutubeUrl = "https://www.youtube.com/watch?v=4BOTvaRaDjI",
            ThumbnailUrl = "https://img.youtube.com/vi/4BOTvaRaDjI/hqdefault.jpg"
        },
        new PhysiotherapyExercise
        {
            Id = 2,
            Title = "Lower Back Mobility Routine",
            BodyPart = "Back",
            Difficulty = "Easy",
            DurationMinutes = 6,
            YoutubeUrl = "https://www.youtube.com/watch?v=DWmGArQBtFI",
            ThumbnailUrl = "https://img.youtube.com/vi/DWmGArQBtFI/hqdefault.jpg"
        },

        // 🔹 SHOULDER
        new PhysiotherapyExercise
        {
            Id = 3,
            Title = "Shoulder Strengthening Exercise",
            BodyPart = "Shoulder",
            Difficulty = "Medium",
            DurationMinutes = 5,
            YoutubeUrl = "https://www.youtube.com/watch?v=1g6L2HkZz9Y",
            ThumbnailUrl = "https://img.youtube.com/vi/1g6L2HkZz9Y/hqdefault.jpg"
        },
        new PhysiotherapyExercise
        {
            Id = 4,
            Title = "Rotator Cuff Rehab Exercise",
            BodyPart = "Shoulder",
            Difficulty = "Medium",
            DurationMinutes = 7,
            YoutubeUrl = "https://www.youtube.com/watch?v=PPzD2w6pXyE",
            ThumbnailUrl = "https://img.youtube.com/vi/PPzD2w6pXyE/hqdefault.jpg"
        },

        // 🔹 LEGS
        new PhysiotherapyExercise
        {
            Id = 5,
            Title = "Leg Balance Exercise",
            BodyPart = "Legs",
            Difficulty = "Hard",
            DurationMinutes = 6,
            YoutubeUrl = "https://www.youtube.com/watch?v=Z8nQXn1pXyE",
            ThumbnailUrl = "https://img.youtube.com/vi/Z8nQXn1pXyE/hqdefault.jpg"
        },
        new PhysiotherapyExercise
        {
            Id = 6,
            Title = "Knee Stability Exercise",
            BodyPart = "Legs",
            Difficulty = "Medium",
            DurationMinutes = 5,
            YoutubeUrl = "https://www.youtube.com/watch?v=R1rYz6k2KpU",
            ThumbnailUrl = "https://img.youtube.com/vi/R1rYz6k2KpU/hqdefault.jpg"
        });
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(w =>
         w.Ignore(RelationalEventId.PendingModelChangesWarning));

    }
}