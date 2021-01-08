using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Data
{
    public class DataContext : 
        IdentityDbContext
        <
            AppUser,
            AppRole,
            int,
            IdentityUserClaim<int>,
            AppUserRole,
            IdentityUserLogin<int>,
            IdentityRoleClaim<int>,
            IdentityUserToken<int>
            >
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activities> Activities { get; set; }
        public DbSet<ActivityTimes> ActivityTimes { get; set; }
        public DbSet<Affirmation> Affirmations { get; set; }
        public DbSet<AlternativeThought> AlternativeThoughts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentQuestion> AppointmentQuestions { get; set; }
        public DbSet<Attitude> Attitudes { get; set; }
        public DbSet<AutomaticThought> AutomaticThoughts { get; set; }
        public DbSet<ChuffChartItem> ChuffChartitems { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Fantasy> Fantasies { get; set; }
        public DbSet<Feeling> Feelings { get; set; }
        public DbSet<GenericText> GenericTexts { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationReminder> MedicationReminders { get; set; }
        public DbSet<MedicationSpread> MedicationsSpreads { get; set; }
        public DbSet<MedicationTime> MedicationTimes { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<MoodList> MoodLists { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<ProblemIdea> ProblemIdeas { get; set; }
        public DbSet<ProblemProCon> ProblemProCons { get; set; }
        public DbSet<ProblemStep> ProblemSteps { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<ReRateMood> ReRateMoods { get; set; }
        public DbSet<SafetyPlanCard> SafetyPlanCards { get; set; }
        public DbSet<Situation> Situations { get; set; }
        public DbSet<SolutionPlan> SolutionsPlans { get; set; }
        public DbSet<SolutionReview> SolutionReviews { get; set; }
        public DbSet<TellMyself> TellMyselfList { get; set; }
        public DbSet<ThoughtRecord> ThoughtRecords { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<Activities>()
                .HasKey(key => new { key.Id });
            builder.Entity<Activities>()
                .HasOne(u => u.User)
                .WithMany(a => a.Activities)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ActivityTimes>()
                .HasKey(key => new { key.Id });

            builder.Entity<ActivityTimes>()
                .HasOne(a => a.Activity)
                .WithMany(at => at.ActivityTimes)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Affirmation>().HasKey(a => new { a.Id });
            builder.Entity<Affirmation>()
                .HasOne(u => u.User)
                .WithMany(af => af.Affirmations)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ThoughtRecord>()
                .HasKey(k => new { k.Id });

            builder.Entity<Situation>().HasKey(k => new { k.Id });
            builder.Entity<Situation>()
                .HasOne(tr => tr.ThoughtRecord);

            builder.Entity<Mood>().HasKey(k => new { k.Id });
            builder.Entity<Mood>()
                .HasOne(tr => tr.ThoughtRecord)
                .WithMany(m => m.Moods)
                .HasForeignKey(k => k.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AutomaticThought>().HasKey(k => new { k.Id });
            builder.Entity<AutomaticThought>()
                .HasOne(tr => tr.ThoughtRecord)
                .WithMany(at => at.AutomaticThoughts)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<EvidenceForHotThought>().HasKey(k => new { k.Id });
            builder.Entity<EvidenceForHotThought>()
                .HasOne(at => at.AutomaticThought)
                .WithMany(ef => ef.EvidenceForHotThought)
                .HasForeignKey(k => k.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<EvidenceAgainstHotThought>().HasKey(k => new { k.Id });
            builder.Entity<EvidenceAgainstHotThought>()
                .HasOne(at => at.AutomaticThought)
                .WithMany(ea => ea.EvidenceAgainstHotThought)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AlternativeThought>().HasKey(k => new { k.Id });
            builder.Entity<AlternativeThought>()
                .HasOne(tr => tr.ThoughtRecord)
                .WithMany(at => at.AlternativeThoughts)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ReRateMood>().HasKey(k => new { k.Id });
            builder.Entity<ReRateMood>()
                .HasOne(tr => tr.ThoughtRecord)
                .WithMany(rm => rm.ReRateMoods)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ReRateMood>()
                .HasOne(m => m.Mood);

            builder.Entity<Appointment>()
                .HasKey(k => new { k.Id });
            builder.Entity<Appointment>()
                .HasOne(u => u.User)
                .WithMany(ap => ap.Appointments)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppointmentQuestion>()
                .HasOne(a => a.Appointment)
                .WithMany(aq => aq.Questions)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Attitude>()
                .HasKey(k => new { k.Id });
            builder.Entity<Attitude>()
                .HasOne(u => u.User)
                .WithMany(at => at.Attitudes)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ChuffChartItem>()
                .HasKey(k => new { k.Id });
            builder.Entity<ChuffChartItem>()
                .HasOne(u => u.User)
                .WithMany(cc => cc.ChuffChartItems)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Contact>()
                .HasKey(k => new { k.Id });
            builder.Entity<Contact>()
                .HasOne(u => u.User)
                .WithMany(c => c.Contacts)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Fantasy>()
                .HasKey(k => new { k.Id });
            builder.Entity<Fantasy>()
                .HasOne(u => u.User)
                .WithMany(f => f.Fantasies)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Feeling>()
                .HasKey(k => new { k.Id });
            builder.Entity<Feeling>()
                .HasOne(u => u.User)
                .WithMany(f => f.Feelings)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<GenericText>()
                .HasKey(k => new { k.Id });
            builder.Entity<GenericText>()
                .HasOne(u => u.User)
                .WithMany(gt => gt.GenericTexts)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Health>()
                .HasKey(k => new { k.Id });
            builder.Entity<Health>()
                .HasOne(u => u.User)
                .WithMany(h => h.Healths)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Image>()
                .HasKey(k => new { k.Id });

            builder.Entity<MedicationReminder>()
                .HasKey(k => new { k.Id });
            builder.Entity<MedicationReminder>()
                .HasOne(ms => ms.MedicationSpread)
                .WithOne(mr => mr.MedicationTakeReminder)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MedicationTime>()
                .HasKey(k => new { k.Id });
            builder.Entity<MedicationTime>()
                .HasOne(ms => ms.Spread)
                .WithOne(mt => mt.MedicationTime)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MedicationSpread>()
                .HasKey(k => new { k.Id });
            builder.Entity<Medication>()
                .HasKey(k => new { k.Id });
            builder.Entity<MedicationSpread>()
                .HasOne(m => m.Medication)
                .WithMany(mt => mt.MedicationSpreads)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<MedicationReminder>()
                .HasOne(ms => ms.MedicationSpread)
                .WithOne(mr => mr.MedicationTakeReminder)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<MedicationTime>()
                .HasOne(ms => ms.Spread)
                .WithOne(mt => mt.MedicationTime)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Medication>()
                .HasOne(p => p.Prescription)
                .WithMany(m => m.Medications)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Prescription>()
                .HasKey(k => k.Id);
            builder.Entity<Prescription>()
                .HasOne(u => u.User)
                .WithMany(p => p.Prescriptions)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MoodList>()
                .HasKey(k => new { k.Id });

            builder.Entity<PlayList>()
                .HasKey(k => new { k.Id });
            builder.Entity<PlayList>()
                .HasOne(u => u.User)
                .WithMany(pl => pl.PlayLists)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Problem>()
                .HasKey(k => new { k.Id });
            builder.Entity<ProblemStep>()
                .HasOne(p => p.Problem)
                .WithMany(ps => ps.Steps)
                .HasForeignKey(k => k.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProblemIdea>()
                .HasOne(p => p.Problem);
            builder.Entity<ProblemIdea>()
                .HasOne(ps => ps.Step)
                .WithMany(pi => pi.Ideas)
                .HasForeignKey(k => k.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProblemProCon>()
                .HasOne(p => p.Problem);
            builder.Entity<ProblemProCon>()
                .HasOne(ps => ps.Step);
            builder.Entity<ProblemProCon>()
                .HasOne(pi => pi.Idea)
                .WithMany(pp => pp.ProsAndCons)
                .HasForeignKey(k => k.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Reaction>()
                .HasKey(k => new { k.Id });

            builder.Entity<Relationship>()
                .HasKey(k => new { k.Id });

            builder.Entity<SafetyPlanCard>()
                .HasKey(k => new { k.Id });

            builder.Entity<SolutionPlan>()
                .HasKey(k => new { k.Id });
            builder.Entity<SolutionPlan>()
                .HasOne(sr => sr.SolutionReview)
                .WithMany(ss => ss.SolutionSteps)
                .HasForeignKey(k => k.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<SolutionReview>()
                .HasOne(pi => pi.Idea);

            builder.Entity<TellMyself>()
                .HasKey(k => new { k.Id });

            builder.Entity<PlayList>()
                .HasKey(k => new { k.Id });
            builder.Entity<Track>()
                .HasKey(k => new { k.Id });
            builder.Entity<Track>()
                .HasOne(pl => pl.PlayList)
                .WithMany(tr => tr.Tracks)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
