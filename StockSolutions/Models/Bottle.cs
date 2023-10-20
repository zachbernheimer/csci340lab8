using System.ComponentModel.DataAnnotations;
namespace RazorPagesMovie.Models;

public class Bottle
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Formula { get; set; }
    public float Amount { get; set; }
    [StringLength(4)]
    public string AmountUnits { get; set; }
    [StringLength(150)]
    public string? Description { get; set; }
}