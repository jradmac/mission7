using System.ComponentModel.DataAnnotations;
namespace mission6.Models;

public class MovieForm
{
    [Key]
    public int Id { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Director { get; set; }
    public string Rating { get; set; }
   public string Edited { get; set; }
   public string LentTo { get; set; }
   public string Notes { get; set; }
   
   
   

}

