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
    
    // [Required]
    // TODO: Clarify if this "new" will allow the Index in the base class to work?
    // public int Index { get; set; }
    
    [Required]
    public string Yard { get; set; }
    
    [Required]
    public Kind Type { get; set; }
    
    [MinLength(0)]
    [MaxLength(1000)]
    public string Note { get; set; }
    
    public List<Job> Jobs { get; set; }
    
    public int? TotalMass
    {
        get
        {
            return Jobs?.Sum(j => j.Mass);
        }
    }
    
    public int? TotalLength
    {
        get
        {
            return Jobs?.Sum(j => j.Length);
        }
    }
    
    public int? TotalWagons
    {
        get
        {
            return Jobs?.Sum(j => j.Wagons);
        }
    }
    
    public int? TotalPay
    {
        get
        {
            return Jobs?.Sum(j => j.Pays);
        }
    }
}