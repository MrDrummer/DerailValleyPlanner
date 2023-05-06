using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DerailValleyPlanner.Models;

public class Job
{
    // [key]
    public int JobId { set; get; }
    public int ConsistId { get; set; }    
}