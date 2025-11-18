using RefConnect.Models;

namespace RefConnect.Controllers;

public class GroupChatsController
{
    private readonly AppDbContext _db;
    public GroupChatsController(AppDbContext db)
    {
        _db = db;
    }
}