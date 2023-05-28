using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DerailValleyPlanner.Models;

[PrimaryKey(nameof(Job.JobId), nameof(Stop.Type))]
public class StopJob
{
    public int JobId { set; get; }
    
    public Stop.Kind StopType { set; get; }
    
    // [ForeignKey(Stop.StopId)]
    public int StopId { set; get; }
}