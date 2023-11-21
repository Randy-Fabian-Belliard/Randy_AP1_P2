using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }
    public string? Nombres { get; set; }

    [ForeignKey("ClienteId")]
    public ICollection<Cobros> Cobros { get; set; } = new List<Cobros>();
    
}