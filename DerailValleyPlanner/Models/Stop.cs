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
    
    public IEnumerable<Job> Jobs { get; set; }
    
    public int TotalMass
    {
        get
        {
            return Jobs?.Sum(j => j.Mass) ?? 0;
        }
    }

    public int ChangeMass => Type == Kind.Unload ? TotalMass * -1 : TotalMass;

    public double TotalLength
    {
        get
        {
            return Jobs?.Sum(j => j.Length) ?? 0;
        }
    }
    
    public double ChangeLength => Type == Kind.Unload ? TotalLength * -1 : TotalLength;
    
    public int TotalWagons
    {
        get
        {
            return Jobs?.Sum(j => j.Wagons) ?? 0;
        }
    }
    
    public int ChangeWagons => Type == Kind.Unload ? TotalWagons * -1 : TotalWagons;
    
    public int TotalPay
    {
        get
        {
            return Jobs?.Sum(j => j.Pays) ?? 0;
        }
    }
}