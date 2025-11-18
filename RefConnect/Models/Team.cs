using System.ComponentModel.DataAnnotations;
namespace RefConnect.Models;

public class Team
{
    [Key] public string idEchipa { get; set; }
    public string numeEchipa { get; set; }
    public string numeAntrenor { get; set; }
    public string numePresedinte { get; set; }
}