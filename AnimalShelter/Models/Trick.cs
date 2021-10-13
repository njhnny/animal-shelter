using System.Collections.Generic;

namespace AnimalShelter.Models
{
  public class Trick
  {
    public Trick()
    {
      this.JoinEntities = new HashSet<AnimalTrick>();
    }
    public int TrickId { get; set; }
    public string TrickName { get; set; }
    public virtual ICollection<AnimalTrick> JoinEntities { get; set; }
  }
}