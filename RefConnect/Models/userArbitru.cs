using System.ComponentModel.DataAnnotations;
namespace RefConnect.Models;

public class userArbitru
{
    public enum Role
    {
        Admin,
        Referee
    }
    
    [Key] public string? userId { get; set; }
    public Role role { get; set; }
    public string? nume { get; set; }
    public string? prenume { get; set; }
    public string? email { get; set; }
}