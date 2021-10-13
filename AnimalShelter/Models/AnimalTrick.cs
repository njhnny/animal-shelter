namespace AnimalShelter.Models
{
  public class AnimalTrick
  {
    public int AnimalTrickId { get; set; }
    public int AnimalId { get; set; }
    public int TrickId { get; set; }
    public virtual Animal Animal { get; set; }
    public virtual Trick Trick { get; set; }
  }
}