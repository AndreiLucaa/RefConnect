using Microsoft.AspNetCore.Mvc;
using RefConnect.Models;

namespace RefConnect.Controllers;


public class UsersController : Controller
{
    private readonly AppDbContext _db;
    public UsersController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var referees = from user in _db.Users orderby user.nume
                          select user;
        
        return View(referees.ToList());
    }

    public ActionResult Show(int id)
    {
        User arbitru = _db.Users.Find(id);
        if (arbitru == null)
        {
            return BadRequest(ModelState);
        }
        
        return View(arbitru);
    }
    

    public IActionResult Create()
    {
        return View();
    }
    
    
    
    [HttpPost]
    public IActionResult Create(User referee)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(referee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }


    }

    public IActionResult Edit(int id)
    {
        User arbitru = _db.Users.Find(id);
        if (arbitru == null)
        {
            return BadRequest(ModelState);
        }
        
        return View(arbitru);
       
    }

    [HttpPost]
    public IActionResult Edit(User referee)
    {
        try
        {
            if(ModelState.IsValid)
            {
                _db.Users.Update(referee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
            
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        User referee = _db.Users.Find(id);
        if (referee == null)
        {
            return NotFound();
            
        }
        _db.Users.Remove(referee);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    
    
}

