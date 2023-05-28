using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DerailValleyPlanner.Models;

/**
 * Contains jobs
 */
[PrimaryKey(nameof(StopId))]
public class Stop
{
    public enum Kind
    {
        Load,
        Unload,
        Via
    }
    
    [Key]
    public int StopId { set; get; }
    
    [Required]
    public int Index { get; set; }
    
    [Required]
    public Yard Yard { get; set; }
    
    [Required]
    public Kind Type { get; set; }
    
    [MinLength(0)]
    [MaxLength(1000)]
    public string Note { get; set; }
    
    public ICollection<StopJob> Jobs { get; set; }
    
    // public int TotalMass { get; set; }
    // public int TotalLength { get; set; }
    // public int TotalWagons { get; set; }
    // public int TotalPay { get; set; }
}