using AeroclubTimekeeper.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace AeroclubTimekeeper.Storage
{
    public class AeroclubDbContext : DbContext
    {
        public AeroclubDbContext()
        {
        }

        public AeroclubDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<Pilot> Pilots { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<CurrentWeather> CurrentWeathers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={Consts.DatabaseName}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aeroplane>().HasBaseType<Aircraft>();
            modelBuilder.Entity<Glider>().HasBaseType<Aircraft>();

            modelBuilder.Entity<Pilot>()
                .HasMany(x => x.FirstPilotFlights)
                .WithOne(x => x.FirstPilot)
                .HasForeignKey(x => x.FirstPilotId);

            modelBuilder.Entity<Pilot>()
                .HasMany(x => x.SecondPilotFlights)
                .WithOne(x => x.SecondPilot)
                .HasForeignKey(x => x.SecondPilotId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
