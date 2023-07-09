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
                ConsistId = "SM-FH-23",
                FromYard = "SM",
                FromTrack = "B-4-O",
                ToYard = "MF",
                ToTrack = "C-4-I",
                Mass = 252,
                Length = 72.18,
                Pays = 16456,
                Wagons = 3,
                Description = "Steel Rolls"
            },
            new Job
            {
                JobId = 2,
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
                JobId = 3,
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
            },
            new Job
            {
                JobId = 4,
                ConsistId = "OWN-FH-81",
                FromYard = "OWN",
                FromTrack = "C-3-O",
                ToYard = "HB",
                ToTrack = "D-4-I",
                Mass = 405,
                Length = 130.71,
                Pays = 47064,
                Wagons = 9,
                Description = "Crude Oil"
            },
            new Job
            {
                JobId = 5,
                ConsistId = "FF-FH-77",
                FromYard = "FF",
                FromTrack = "C-2-O",
                ToYard = "HB",
                ToTrack = "E-8-I",
                Mass = 450,
                Length = 180,
                Pays = 29847,
                Wagons = 10,
                Description = "Shipping Containers"
            },
            new Job
            {
                JobId = 6,
                ConsistId = "FF-LH-17",
                FromYard = "FF",
                FromTrack = "C-9-S",
                ToYard = "GF",
                ToTrack = "B-3-S",
                Mass = 73,
                Length = 82.37,
                Pays = 7381,
                Wagons = 5,
                Description = "3 Empty Cars, 2 Box Cars"
            },
            new Job
            {
                JobId = 7,
                ConsistId = "FF-LH-39",
                FromYard = "FF",
                FromTrack = "C-1-S",
                ToYard = "OWN",
                ToTrack = "B-2-S",
                Mass = 228,
                Length = 174.28,
                Pays = 15368,
                Wagons = 12,
                Description = "Empty Oil Tankers"
            },
            new Job
            {
                JobId = 8,
                ConsistId = "FF-LH-03",
                FromYard = "FF",
                FromTrack = "C-1-S",
                ToYard = "MF",
                ToTrack = "B-2-S",
                Mass = 69,
                Length = 54.16,
                Pays = 11449,
                Wagons = 3,
                Description = "Empty Car Wagons"
            },
            new Job
            {
                JobId = 9,
                ConsistId = "IMW-FH-16",
                FromYard = "IMW",
                FromTrack = "B-6-O",
                ToYard = "SM",
                ToTrack = "A-6-I",
                Mass = 344,
                Length = 72.90,
                Pays = 19793,
                Wagons = 4,
                Description = "Iron Ore (Yellow Wagons)"
            },
            new Job
            {
                JobId = 10,
                ConsistId = "IMW-LH-10",
                FromYard = "IMW",
                FromTrack = "B-1-S",
                ToYard = "MF",
                ToTrack = "B-1-S",
                Mass = 110,
                Length = 180.45,
                Pays = 6585,
                Wagons = 10,
                Description = "Empty Cars"
            },
            new Job
            {
                JobId = 11,
                ConsistId = "IMW-FH-11",
                FromYard = "IMW",
                FromTrack = "B-3-O",
                ToYard = "SM",
                ToTrack = "B-3-I",
                Mass = 1032,
                Length = 218.71,
                Pays = 49682,
                Wagons = 12,
                Description = "Iron Ore"
            },
            new Job
            {
                JobId = 12,
                ConsistId = "IMW-FH-37",
                FromYard = "IMW",
                FromTrack = "B-4-O",
                ToYard = "SM",
                ToTrack = "B-3-I",
                Mass = 430,
                Length = 91.13,
                Pays = 23786,
                Wagons = 5,
                Description = "Iron Ore"
            },
            new Job
            {
                JobId = 13,
                ConsistId = "FF-FH-79",
                FromYard = "FF",
                FromTrack = "C-7-O",
                ToYard = "HB",
                ToTrack = "E-9-I",
                Mass = 686,
                Length = 197.67,
                Pays = 36825,
                Wagons = 14,
                Description = "Box Cars"
            },
            new Job
            {
                JobId = 14,
                ConsistId = "FF-FH-05",
                FromYard = "FF",
                FromTrack = "C-3-O",
                ToYard = "HB",
                ToTrack = "C-2-I",
                Mass = 320,
                Length = 128.66,
                Pays = 22553,
                Wagons = 8,
                Description = "Containers & Box Cars"
            },
            new Job
            {
                JobId = 15,
                ConsistId = "FF-FH-59",
                FromYard = "FF",
                FromTrack = "C-5-O",
                ToYard = "HB",
                ToTrack = "E-8-I",
                Mass = 170,
                Length = 180.45,
                Pays = 16330,
                Wagons = 10,
                Description = "Containers"
            },
            new Job
            {
                JobId = 16,
                ConsistId = "GF-FH-39",
                FromYard = "GF",
                FromTrack = "D-3-O",
                ToYard = "MF",
                ToTrack = "C-3-I",
                Mass = 378,
                Length = 98.83,
                Pays = 28793,
                Wagons = 7,
                Description = "Box Cars"
            },
            new Job
            {
                JobId = 17,
                ConsistId = "GF-FH-13",
                FromYard = "GF",
                FromTrack = "D-2-O",
                ToYard = "MF",
                ToTrack = "C-3-I",
                Mass = 260,
                Length = 74.52,
                Pays = 21720,
                Wagons = 5,
                Description = "Box Cars"
            },
            new Job
            {
                JobId = 18,
                ConsistId = "OWN-FH-40",
                FromYard = "OWN",
                FromTrack = "B-4-O",
                ToYard = "HB",
                ToTrack = "C-2-I",
                Mass = 675,
                Length = 217.84,
                Pays = 72506,
                Wagons = 15,
                Description = "Crude Oil Tankers"
            },
            new Job
            {
                JobId = 19,
                ConsistId = "OWN-FH-78",
                FromYard = "OWN",
                FromTrack = "B-5-O",
                ToYard = "HB",
                ToTrack = "G-5-I",
                Mass = 765,
                Length = 246.89,
                Pays = 80392,
                Wagons = 17,
                Description = "Crude Oil Tankers"
            },
            new Job
            {
                JobId = 20,
                ConsistId = "OWN-FH-32",
                FromYard = "OWN",
                FromTrack = "B-3-O",
                ToYard = "HB",
                ToTrack = "E-9-I",
                Mass = 336,
                Length = 116.18,
                Pays = 30621,
                Wagons = 8,
                Description = "Methane"
            },
            new Job
            {
                JobId = 21,
                ConsistId = "MF-FH-80",
                FromYard = "MF",
                FromTrack = "B-4-O",
                ToYard = "FF",
                ToTrack = "C-6-I",
                Mass = 153,
                Length = 162.40,
                Pays = 11592,
                Wagons = 9,
                Description = "Containers"
            },
            new Job
            {
                JobId = 22,
                ConsistId = "MF-FH-59",
                FromYard = "MF",
                FromTrack = "B-2-O",
                ToYard = "GF",
                ToTrack = "D-6-I",
                Mass = 119,
                Length = 126.31,
                Pays = 12412,
                Wagons = 7,
                Description = "Containers. 4 Orange, 3 Blue"
            }
        );

        modelBuilder.Entity<Stop>().HasData(
            new Stop
            {
                StopId = 1,
                Index = 1,
                Type = Stop.Kind.Load,
                Yard = "MF",
                Note = ""
            },
            new Stop
            {
                StopId = 2,
                Index = 2,
                Type = Stop.Kind.Load,
                Yard = "IMW",
                Note = ""
            },
            new Stop
            {
                StopId = 3,
                Index = 3,
                Type = Stop.Kind.Unload,
                Yard = "FF",
                Note = ""
            },
            new Stop
            {
                StopId = 4,
                Index = 4,
                Type = Stop.Kind.Load,
                Yard = "FF",
                Note = ""
            },
            new Stop
            {
                StopId = 5,
                Index = 5,
                Type = Stop.Kind.Unload,
                Yard = "OWN",
                Note = ""
            },
            new Stop
            {
                StopId = 6,
                Index = 6,
                Type = Stop.Kind.Load,
                Yard = "OWN",
                Note = ""
            },
            new Stop
            {
                StopId = 7,
                Index = 7,
                Type = Stop.Kind.Unload,
                Yard = "GF",
                Note = ""
            },
            new Stop
            {
                StopId = 8,
                Index = 8,
                Type = Stop.Kind.Load,
                Yard = "GF",
                Note = ""
            },
            new Stop
            {
                StopId = 9,
                Index = 9,
                Type = Stop.Kind.Unload,
                Yard = "SM",
                Note = ""
            },
            new Stop
            {
                StopId = 10,
                Index = 10,
                Type = Stop.Kind.Load,
                Yard = "SM",
                Note = ""
            },
            new Stop
            {
                StopId = 11,
                Index = 11,
                Type = Stop.Kind.Unload,
                Yard = "HB",
                Note = ""
            },
            new Stop
            {
                StopId = 12,
                Index = 12,
                Type = Stop.Kind.Load,
                Yard = "HB",
                Note = ""
            },
            new Stop
            {
                StopId = 13,
                Index = 13,
                Type = Stop.Kind.Unload,
                Yard = "CSW",
                Note = ""
            },
            new Stop
            {
                StopId = 14,
                Index = 14,
                Type = Stop.Kind.Unload,
                Yard = "MF",
                Note = ""
            }
        );

        // modelBuilder.Entity<StopJob>();
    }
    
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Stop> Stops { get; set; }
    
    // public DbSet<StopJob> StopJobs { get; set; }
}