using System.Collections.Generic;

namespace AnimalShelter.Models
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Animal> Animals { get; set; }

    public Category(string categoryName)
    {
      Name = categoryName;
      _instances.Add(this);
      Id = _instances.Count;
      Animals = new List<Animal>{};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Category> GetAll()
    {
      return _instances;
    }

    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public void AddItem(Animal item)
    {
      Animals.Add(item);
    }

  }
}