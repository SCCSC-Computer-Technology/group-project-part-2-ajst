using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class SportsDbContext : DbContext
    {
        public SportsDbContext(DbContextOptions<SportsDbContext> options)
            : base(options)
        {
        }

        public DbSet<NBAPlayer> NBAPlayers { get; set; }
        public DbSet<NBATeam> NBATeams { get; set; }
        public DbSet<NBASchedule> NBASchedules { get; set; }
        public DbSet<NFLSchedule> NFLSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NBAPlayer>().ToTable("nbaCurrentPlayers");

            modelBuilder.Entity<NBAPlayer>().HasKey(p => p.PlayerID);

            modelBuilder.Entity<NBASchedule>().HasNoKey().ToTable("nbaSchedule");

            modelBuilder.Entity<NFLSchedule>().HasNoKey().ToTable("nflSchedule");
        }
    }
}