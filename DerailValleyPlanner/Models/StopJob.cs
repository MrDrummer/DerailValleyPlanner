using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DerailValleyPlanner.Models;

// [PrimaryKey(nameof(JobId), nameof(StopType))]
// public class StopJob
// {
//     [Key]
//     // [Column(Order = 1)]
//     public int StopJobId { set; get; }
//     
//     // [Key]
//     // [Column(Order = 2)]
//     public int JobId { set; get; }
//     public Job Job { get; set; }
//     
//     // [ForeignKey(Stop.StopId)]
//     public int StopId { set; get; }
//     public Stop Stop { get; set; }
//     
//     // [Key]
//     // [Column(Order = 3)]
//     public Stop.Kind StopType { set; get; }
// }