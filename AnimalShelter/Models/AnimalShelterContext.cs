using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Trick> Tricks { get; set; }
    public DbSet<AnimalTrick> AnimalTrick { get; set; }

    public AnimalShelterContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}