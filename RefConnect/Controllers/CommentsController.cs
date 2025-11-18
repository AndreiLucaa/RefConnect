using RefConnect.Models;

namespace RefConnect.Controllers;

public class CommentsController
{
    
    private readonly AppDbContext _db;
    public CommentsController(AppDbContext db)
    {
        _db = db;
    }
    
    
}