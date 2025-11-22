using System.ComponentModel.DataAnnotations;
namespace RefConnect.Models;

public class Championship
{
    [Key] public string? idCampionat { get; set;}
    public string? numeCampionat { get; set; }
    public string? tara { get; set; }
}