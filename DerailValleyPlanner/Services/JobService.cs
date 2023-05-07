using DerailValleyPlanner.Data;

namespace DerailValleyPlanner.Services;

public class JobService
{
    private PlannerContext _context;
    public JobService(PlannerContext context)
    {
        _context = context;
    }
}