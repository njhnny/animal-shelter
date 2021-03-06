using System.Collections.Generic;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public Animal()
    {
      this.JoinEntities = new HashSet<AnimalTrick>();
    }
    public int AnimalId { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }

    public virtual ICollection<AnimalTrick> JoinEntities { get; }
  }
}