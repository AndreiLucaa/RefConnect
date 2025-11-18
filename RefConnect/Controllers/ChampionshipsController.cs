using RefConnect.Models;


namespace RefConnect.Controllers;

public class ChampionshipsController
{
    private readonly AppDbContext _db;
    public ChampionshipsController(AppDbContext db)
    {
        _db = db;
    }
    
    
}