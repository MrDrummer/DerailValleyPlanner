using DerailValleyPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace DerailValleyPlanner.Data;

public class PlannerContext : DbContext
{
    public PlannerContext(DbContextOptions<PlannerContext> options)
        : base(options)
    {
    }
    
    public DbSet<Job> Jobs { get; set; }
}