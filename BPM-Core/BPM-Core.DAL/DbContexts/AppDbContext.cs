using BPM_Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BPM_Core.DAL.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMembership> TeamMemberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.TeamMemberships)
                .WithOne(tm => tm.User)
                .HasForeignKey(tm => tm.UserId);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.TeamMemberships)
                .WithOne(tm => tm.Team)
                .HasForeignKey(tm => tm.TeamId);

            modelBuilder.Entity<TeamMembership>()
                .HasOne(tm => tm.Supervisor)
                .WithMany()
                .HasForeignKey(tm => tm.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
