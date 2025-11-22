using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace RefConnect.Models;

public class Post
{
    [Key] public string? idPostare { get; set; }
    public string? linkVideo { get; set; }
    public string? descriere { get; set; }
    public string? idUser { get; set; }
    public JSType.Date createdAt { get; set; }
}