using System.ComponentModel.DataAnnotations;
namespace RazorPagesMovie.Models;

public class Bottle
{
    public int Id { get; set; }
    
    // make a mandatory connection to one chemical
    public int ChemicalId { get; set; }
    public Chemical Chemical { get; set; } = null!;
    public float Amount { get; set; }

    [StringLength(4)]
    public string AmountUnits { get; set; }
}