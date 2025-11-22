using Microsoft.AspNetCore.Mvc;
using RefConnect.Models;

namespace RefConnect.Controllers;


public class userArbitrusController : Controller
{
    private readonly AppDbContext _db;
    public userArbitrusController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var referees = from userReferee in _db.UserArbitri orderby userReferee.nume
                          select userReferee;
        
        
        return View(referees.ToList());
        
        
        
    }

    public ActionResult Show(int id)
    {
        userArbitru arbitru = _db.UserArbitri.Find(id);
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
    public IActionResult Create(userArbitru referee)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _db.UserArbitri.Add(referee);
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
        userArbitru arbitru = _db.UserArbitri.Find(id);
        if (arbitru == null)
        {
            return BadRequest(ModelState);
        }
        
        return View(arbitru);
       
    }

    [HttpPost]
    public IActionResult Edit(userArbitru referee)
    {
        try
        {
            if(ModelState.IsValid)
            {
                _db.UserArbitri.Update(referee);
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
        userArbitru referee = _db.UserArbitri.Find(id);
        if (referee == null)
        {
            return NotFound();
            
        }
        _db.UserArbitri.Remove(referee);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    
    
}

