using RefConnect.Models;


namespace RefConnect.Controllers;

public class PostsController
{
    
    private readonly AppDbContext _db;
    public PostsController(AppDbContext db)
    {
        _db = db;
    }
    
    
}