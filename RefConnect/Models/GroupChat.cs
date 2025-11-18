using System.ComponentModel.DataAnnotations;
namespace RefConnect.Models;

public class GroupChat
{
    [Key] public string? idChat { get; set; }
    public string? numeChat { get; set; }
    
}