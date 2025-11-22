using RefConnect.Models;
using Microsoft.AspNetCore.Mvc;
namespace RefConnect.Controllers;

public class CommentsController : Controller
{
    
    private readonly AppDbContext _db;
    public CommentsController(AppDbContext db)
    {
        _db = db;
    }
    //all comments for a specific post can be shown in Posts/Show view
    public IActionResult Create()
    {
        return View();
        
    }

    [HttpPost]
    public IActionResult Create(Comment comment)
    {
        if (ModelState.IsValid)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View(comment);
        }
    }
    
    public IActionResult Edit(int id)
    {
        var comment = _db.Comments.Find(id);
        if (comment == null)
        {
            return NotFound();
        }
        return View(comment);
    }

    [HttpPost]
    public IActionResult Edit(Comment comment)
    {
        if (ModelState.IsValid)
        {
            _db.Comments.Update(comment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View(comment);
        }
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {  
        
        var comment = _db.Comments.Find(id);
        if (comment == null)
        {
            return NotFound();
        }
        _db.Comments.Remove(comment);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    
    
}