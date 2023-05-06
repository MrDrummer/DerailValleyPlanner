using DerailValleyPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace DerailValleyPlanner.Data;

public class JobContext : DbContext
{
    public JobContext(DbContextOptions<JobContext> options)
        : base(options)
    {
    }
    
    public DbSet<Job> Jobs { get; set; }
}