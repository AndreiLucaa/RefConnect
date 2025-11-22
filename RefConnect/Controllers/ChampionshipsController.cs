using RefConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace RefConnect.Controllers;

public class ChampionshipsController : Controller
{
    private readonly AppDbContext _db;
    public ChampionshipsController(AppDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        var championshipsList = from c in _db.Championships
            orderby c.numeCampionat
            select c;
        return View(championshipsList.ToList());
    }
    
    
    public IActionResult Show(int id)
    {
        var championship = _db.Championships.Find(id);
        if (championship == null)
        {
            return NotFound();
        }
        return View(championship);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Championship championship)
    {
        if (ModelState.IsValid)
        {
            _db.Championships.Add(championship);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(championship);
        }
    }
    
    public IActionResult Edit(int id)
    {
        var championship = _db.Championships.Find(id);
        if (championship == null)
        {
            return NotFound();
        }
        return View(championship);
    }

    [HttpPost]
    public IActionResult Edit(Championship championship)
    {
        if (ModelState.IsValid)
        {
            _db.Championships.Update(championship);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(championship);
        }
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var championship = _db.Championships.Find(id);
        if (championship == null)
        {
            return NotFound();
        }
        _db.Championships.Remove(championship);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}