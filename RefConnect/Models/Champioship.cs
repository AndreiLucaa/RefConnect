using System.ComponentModel.DataAnnotations;
namespace RefConnect.Models;

public class Champioship
{
    [Key] public string idCampionat { get; set;}
    public string numeCampionat { get; set; }
    public string tara { get; set; }
}