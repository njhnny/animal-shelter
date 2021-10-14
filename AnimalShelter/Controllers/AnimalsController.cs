using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.TrickId = new SelectList(_db.Tricks, "TrickId", "TrickName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal, int TrickId)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      if (TrickId != 0)
      {
      _db.AnimalTrick.Add(new AnimalTrick() { TrickId = TrickId, AnimalId = animal.AnimalId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Animal thisAnimal = _db.Animals
        .Include(animal => animal.JoinEntities)
        .ThenInclude(join => join.Trick)
        .FirstOrDefault(animal => animal.AnimalId == id);
        return View(thisAnimal);
    }

    public ActionResult Delete(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      _db.Animals.Remove(thisAnimal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}