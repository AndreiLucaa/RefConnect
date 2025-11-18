using RefConnect.Models;

namespace RefConnect.Controllers;

public class TeamsController
{
    
    private readonly AppDbContext _db;
    public TeamsController(AppDbContext db)
    {
        _db = db;
    }
}