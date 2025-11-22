using RefConnect.Models;
using Microsoft.AspNetCore.Mvc;


namespace RefConnect.Controllers;

public class TeamsController : Controller
{
    
    private readonly AppDbContext _db;
    public TeamsController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        
        var teamsList = from t in _db.Teams
            orderby t.numeEchipa
            select t;
        return View(teamsList.ToList());
    }

    public IActionResult Show(int id)
    {
        var team = _db.Teams.Find(id);
        if (team == null)
        {
            return NotFound();
        }
        return View(team);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Team team)
    {
        if (ModelState.IsValid)
        {
            _db.Teams.Add(team);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(team);
        }
    }

    public IActionResult Edit(int id)
    {
        var team = _db.Teams.Find(id);
        if (team == null)
        {
            return NotFound();
        }
        return View(team);
    }

    [HttpPost]
    public IActionResult Edit(Team team)
    {
        if (ModelState.IsValid)
        {
            _db.Teams.Update(team);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(team);
        }
        
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var team = _db.Teams.Find(id);
        if (team == null)
        {
            return NotFound();
        }
        _db.Teams.Remove(team);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    
    
}