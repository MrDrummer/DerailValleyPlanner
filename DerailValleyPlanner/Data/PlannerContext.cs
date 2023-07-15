using DerailValleyPlanner.Models;
using DerailValleyPlanner.Services;
using Microsoft.EntityFrameworkCore;

namespace DerailValleyPlanner.Data;

public class PlannerContext : DbContext
{
    private ConfigService _config;
    public PlannerContext(DbContextOptions<PlannerContext> options, ConfigService Config)
        : base(options)
    {
        _config = Config;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>().HasData(
            new Job
            {
                JobId = 1,
                ConsistId = "HB-FH-92",
                FromYard = "HB",
                FromTrack = "E-3-O",
                ToYard = "CSW",
                ToTrack = "C-2-I",
                Mass = 186,
                Length = 72.18,
                Pays = 19134,
                Wagons = 4,
                Description = "Shipping containers"
            },
            new Job
            {
                JobId = 2,
                ConsistId = "HB-FH-08",
                FromYard = "HB",
                FromTrack = "E-2-O",
                ToYard = "CSW",
                ToTrack = "C-2-I",
                Mass = 312,
                Length = 101.66,
                Pays = 54798,
                Wagons = 7,
                Description = "Diesel & Gasoline"
            }
        );
    
        modelBuilder.Entity<Stop>().HasData(
            new Stop
            {
                StopId = 1,
                Index = 0,
                Type = Stop.Kind.Load,
                Yard = "HB",
                Note = ""
            },
            new Stop
            {
                StopId = 2,
                Index = 1,
                Type = Stop.Kind.Unload,
                Yard = "CSW",
                Note = ""
            }
        );
    
    }
    
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Stop> Stops { get; set; }
}