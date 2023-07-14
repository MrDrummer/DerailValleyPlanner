using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DerailValleyPlanner.Models;

// TODO: Save consist ID as Type and Number (Last two parts)
// TODO: Use Yard code instead of name
// TODO: Use Track number instead of string

// [PrimaryKey(nameof(JobId))]
public class Job
{
    // Primary Key
    [Key]
    public int JobId { set; get; }
    
    // ID as seen in-game
    [Required]
    [StringLength(10, ErrorMessage = "Format: XXX-YY-NN")]
    [RegularExpression("\\w{2,3}-\\w{2}-\\d{1,2}")]
    [DisplayName("Consist ID")]
    public string ConsistId { get; set; }
    
    // Dropdown based on config
    [Required]
    [DisplayName("From Yard")]
    public string FromYard { get; set; }
    
    // Dropdown based on the yard selected
    [Required]
    [DisplayName("From Track")]
    public string FromTrack { get; set; }
    
    // Dropdown based on config
    [Required]
    [DisplayName("To Yard")]
    public string ToYard { get; set; }
    
    // Dropdown based on the yard selected
    [Required]
    [DisplayName("To Track")]
    public string ToTrack { get; set; }
    
    [Required]
    [Range(10, 10000, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    [DisplayName("Mass")]
    public int Mass { get; set; }
    
    [Required]
    [Range(10, 10000, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    [DisplayName("Length")]
    public double Length { get; set; }
    
    [Required]
    [Range(1, 200, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    [DisplayName("Wagons")]
    public int Wagons { get; set; }
    
    [Required]
    [Range(10, 100000, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    [DisplayName("Pays")]
    [DisplayFormat(DataFormatString = "{0:C0}")]
    public int Pays { get; set; }
    
    // Free-form text to help identify the wagons.
    [MinLength(0)]
    [MaxLength(1000)]
    [DisplayName("Description")]
    public string Description { get; set; }

    public double MassPerWagon => Math.Round((double)Mass / Wagons, 2);

    public IEnumerable<Stop> Stops { get; set; }

    // Note: this is important so the select can compare pizzas
    public override bool Equals(object o) {
        var other = o as Job;
        return other?.JobId==JobId;
    }

    // Note: this is important so the select can compare pizzas
    public override int GetHashCode() => JobId.GetHashCode();

    public override string ToString() => ConsistId;
}