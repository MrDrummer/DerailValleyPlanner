using DerailValleyPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace DerailValleyPlanner.Data;

public class PlannerContext : DbContext
{
    public PlannerContext(DbContextOptions<PlannerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>().HasData(
            new Job
            {
                JobId = 1,
                ConsistId = "MF-FH-83",
                FromYard = "Machine Factory & Town",
                FromTrack = "B-5-O",
                ToYard = "Steel Mill",
                ToTrack = "A-6-I",
                Mass = 174,
                Length = 39,
                Pays = 6297,
                Wagons = 3,
                Description = "Empty flat cars"
            },
            new Job
            {
                JobId = 2,
                ConsistId = "CSW-LH-03",
                FromYard = "City South West",
                FromTrack = "C-4-S",
                ToYard = "Farm",
                ToTrack = "B-1-S",
                Mass = 280,
                Length = 197,
                Pays = 12112,
                Wagons = 14,
                Description = "Empty grain wagons"
            },
            new Job
            {
                JobId = 3,
                ConsistId = "HB-FH-32",
                FromYard = "Harbour & Town",
                FromTrack = "G-3-O",
                ToYard = "Machine Factory & Town",
                ToTrack = "C-4-I",
                Mass = 332,
                Length = 122,
                Pays = 22519,
                Wagons = 7,
                Description = "Cargo containers"
            },
            new Job
            {
                JobId = 4,
                ConsistId = "SM-FH-68",
                FromYard = "Steel Mill",
                FromTrack = "B-2-O",
                ToYard = "Machine Factory & Town",
                ToTrack = "C-3-I",
                Mass = 542,
                Length = 180,
                Pays = 20437,
                Wagons = 10,
                Description = "Steel"
            },
            new Job
            {
                JobId = 5,
                ConsistId = "HB-FH-60",
                FromYard = "Harbour & Town",
                FromTrack = "D-3-O",
                ToYard = "Food Factory & Town",
                ToTrack = "C-4-I",
                Mass = 68,
                Length = 72,
                Pays = 5766,
                Wagons = 4,
                Description = "Empty grain wagons"
            },
            new Job
            {
                JobId = 6,
                ConsistId = "SM-FH-27",
                FromYard = "Steel Mill",
                FromTrack = "B-1-O",
                ToYard = "Harbour & Town",
                ToTrack = "C-2-I",
                Mass = 741,
                Length = 234,
                Pays = 25718,
                Wagons = 13,
                Description = "Steel"
            }
        );
    }
    
    public DbSet<Job> Jobs { get; set; }
}