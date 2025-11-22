using RefConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace RefConnect.Controllers;

public class GroupChatsController : Controller
{
    private readonly AppDbContext _db;
    public GroupChatsController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(GroupChat groupChat)
    {
        if (ModelState.IsValid)
        {
            _db.GroupChats.Add(groupChat);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View(groupChat);
        }
    }

    public IActionResult Edit(int id)
    {
        var groupChat = _db.GroupChats.Find(id);
        if (groupChat == null)
        {
            return NotFound();
        }
        return View(groupChat);
    }

    [HttpPost]
    public IActionResult Edit(GroupChat groupChat)
    {
        if (ModelState.IsValid)
        {
            _db.GroupChats.Update(groupChat);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View(groupChat);
        }
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var groupChat = _db.GroupChats.Find(id);
        if (groupChat == null)
        {
            return NotFound();
        }
        _db.GroupChats.Remove(groupChat);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    
}