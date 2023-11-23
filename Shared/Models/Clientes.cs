using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2_AP1_Randy.Shared;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }
    public string? Nombres { get; set; }

        [ForeignKey("ClienteId")]
    public ICollection<CobrosDetalle> CobrosDetalle { get; set; } = new List<CobrosDetalle>();


}
