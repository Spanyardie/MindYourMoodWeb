using Microsoft.EntityFrameworkCore;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Data
{
    public class ProblemStepContext : DataContext
    {
        public ProblemStepContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProblemStep> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProblemStep>()
                .HasOne(p => p.Problem)
                .WithMany(ps => ps.Steps)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
