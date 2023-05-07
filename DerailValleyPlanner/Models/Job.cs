﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DerailValleyPlanner.Models;

public class Job
{
    // [key]
    // Primary Key
    public int JobId { set; get; }
    
    // ID as seen in-game
    [Required]
    [StringLength(10, ErrorMessage = "Format: XXX-YYY-NN")]
    [RegularExpression("\\w{2,3}-\\w{2,3}-\\d{2}")]
    [DisplayName("Consist ID")]
    public string ConsistId { get; set; }
    
    // Dropdown based on config
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    [DisplayName("From Yard")]
    public string FromYard { get; set; }
    
    // Dropdown based on the yard selected
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    [DisplayName("From Track")]
    public string FromTrack { get; set; }
    
    // Dropdown based on config
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    [DisplayName("To Yard")]
    public string ToYard { get; set; }
    
    // Dropdown based on the yard selected
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
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
    public int Length { get; set; }
    
    [Required]
    [Range(1, 200, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    [DisplayName("Wagons")]
    public int Wagons { get; set; }
    
    [Required]
    [Range(10, 100000, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    [DisplayName("Pays")]
    public int Pays { get; set; }
    
    // Free-form text to help identify the wagons.
    [MinLength(0)]
    [MaxLength(1000)]
    [DisplayName("Description")]
    public string Description { get; set; }
}