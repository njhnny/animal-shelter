using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public ActionResult Create(Animal item)
    {
        _db.Animals.Add(item);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Animal thisItem = _db.Animals.FirstOrDefault(item => item.AnimalId == id);
        return View(thisItem);
    }
  }
}