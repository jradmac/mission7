using Microsoft.EntityFrameworkCore;
using mission6.Models;


public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
    {
        
    }
    public DbSet<MovieForm> MovieForm { get; set; }
    
}