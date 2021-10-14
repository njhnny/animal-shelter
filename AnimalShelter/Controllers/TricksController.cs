using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public class TricksController : Controller
  {
    private readonly AnimalShelterContext _db;

    public TricksController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Trick> model = _db.Tricks.ToList();
      return View(model);
    }

    
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Trick trick)
    {
      _db.Tricks.Add(trick);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    

    // [HttpGet("/categories/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category selectedCategory = Category.Find(id);
    //   List<Animal> categoryItems = selectedCategory.Animals;
    //   model.Add("category", selectedCategory);
    //   model.Add("animals", categoryAnimals);
    //   return View(model);
    // }


    // // This one creates new Items within a given Category, not new Categories:

    // [HttpPost("/categories/{categoryId}/animals")]
    // public ActionResult Create(int categoryId, string animalDescription)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category foundCategory = Category.Find(categoryId);
    //   Animal newAnimal = new Animal(animalDescription);
    //   newAnimal.Save();    // New code
    //   foundCategory.AddAnimal(newAnimal);
    //   List<Animal> categoryAnimals = foundCategory.Animals;
    //   model.Add("animals", categoryAnimals);
    //   model.Add("category", foundCategory);
    //   return View("Show", model);
    // }

  }
}