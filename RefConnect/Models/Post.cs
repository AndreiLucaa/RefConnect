using System.ComponentModel.DataAnnotations;
namespace RefConnect.Models;

public class Post
{
    [Key] public string idPostare { get; set; }
    public string linkVideo { get; set; }
    public string descriere { get; set; }
    public string idUser { get; set; }
}