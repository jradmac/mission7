using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mission6.Models;

[Table("Movies")]
public class MovieForm
{
    [Key]
    public int MovieId { get; set; }
    
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be after 1888")]
    public int Year { get; set; }

    // Allow nullable for Director and Rating
    public string? Director { get; set; }
    
    public string? Rating { get; set; }
    
    [Required]
    public bool Edited { get; set; }
    
    public string? LentTo { get; set; }

    [Required]
    public bool CopiedToPlex { get; set; }
    
    public string? Notes { get; set; }
   
}

