using RefConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace RefConnect.Controllers;

public class PostsController : Controller
{
    
    private readonly AppDbContext _db;
    public PostsController(AppDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        var posts = from p in _db.Posts
            orderby p.CreatedAt descending
            select p;
        return View(posts);
    }

    public IActionResult Show(int id)
    {
        var post = _db.Posts.Find(id);
        if (post == null)
        {
            return NotFound();
        }
        return View(post);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {
        if (ModelState.IsValid)
        {
            post.CreatedAt = DateTime.Now;
            _db.Posts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(post);
        }
        
    }

    public IActionResult Edit(int id)
    {
        var post = _db.Posts.Find(id);
        if (post == null)
        {
            return NotFound();
        }
        return View(post);
        
    }

    [HttpPost]
    public IActionResult Edit(Post post)
    {
        if (ModelState.IsValid)
        {
            _db.Posts.Update(post);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(post);
        }
    }


    [HttpPost]
    public IActionResult Delete(int id)
    {
        var post = _db.Posts.Find(id);
        if (post == null)
        {
            return NotFound();
        }
        _db.Posts.Remove(post);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    
}