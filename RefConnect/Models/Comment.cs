using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace RefConnect.Models;

public class Comment
{
    [Key] public string idComentariu { get; set; }
    public string idUser { get; set; }
    public string idPostare { get; set; }
    public string continut { get; set; }
    public DateTime dataPostarii { get; set; }
}