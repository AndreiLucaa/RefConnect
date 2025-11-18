using System.ComponentModel.DataAnnotations;

namespace RefConnect.Models;

public class Match
{
    [Key] public string idMeci { get; set; }
    public string echipaGazda { get; set; }
    public string echipaOaspeti { get; set; }
    public DateTime dataMeciului { get; set; }
    public string locatie { get; set; }
    public string stadion { get; set; }
    public int scorGazda { get; set; }
    public int scorOaspeti { get; set; }
}