using Microsoft.EntityFrameworkCore;

namespace mission6.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
    {
        
    }
    public DbSet<MovieForm> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
    
}