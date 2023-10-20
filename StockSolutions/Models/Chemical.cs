using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Chemical
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Formula { get; set; }

    [StringLength(150)]
    public string? Description { get; set; }

    // Collection navigation to dependent bottles
    public ICollection<Bottle> Bottles { get; } = new List<Bottle>();
}