using RefConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace RefConnect.Controllers;

public class MatchesController : Controller
{

    private readonly AppDbContext _db;
    
    public MatchesController(AppDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        var matchesList = from m in _db.Matches
            orderby m.dataMeciului
            select m;
        return View(matchesList.ToList());
    }
    
    public IActionResult Show(int id)
    {
        var match = _db.Matches.Find(id);
        if (match == null)
        {
            return NotFound();
        }
        return View(match);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Match match)
    {
        if (ModelState.IsValid)
        {
            _db.Matches.Add(match);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(match);
        }

    }
    
    public IActionResult Edit(int id)
    {
        var match = _db.Matches.Find(id);
        if (match == null)
        {
            return NotFound();
        }
        return View(match);
    }

    [HttpPost]
    public IActionResult Edit(Match match)
    {
        if (ModelState.IsValid)
        {
            _db.Matches.Update(match);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(match);
        }
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var match = _db.Matches.Find(id);
        if (match == null)
        {
            return NotFound();
        }
        _db.Matches.Remove(match);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}