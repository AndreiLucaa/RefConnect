using RefConnect.Models;

namespace RefConnect.Controllers;

public class MatchesController
{

    private readonly AppDbContext _db;
    
    public MatchesController(AppDbContext db)
    {
        _db = db;
    }


}