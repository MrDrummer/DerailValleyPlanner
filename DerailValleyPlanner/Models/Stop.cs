using System.ComponentModel.DataAnnotations;
using IndexedList;
using Microsoft.EntityFrameworkCore;

namespace DerailValleyPlanner.Models;

/**
 * Contains jobs
 */
// [PrimaryKey(nameof(StopId))]
public class Stop : Indexed
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
    // TODO: Clarify if this "new" will allow the IndexedList to work?
    public new int Index { get; set; }
    
    [Required]
    public string Yard { get; set; }
    
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