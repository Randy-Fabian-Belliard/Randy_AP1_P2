using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2_AP1_Randy.Shared;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public double Monto { get; set; }
    public double Balance { get; set; }

    [ForeignKey("VentaId")]
    public ICollection<CobrosDetalle> CobrosDetalle { get; set; } = new List<CobrosDetalle>();

    
}


