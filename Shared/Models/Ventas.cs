using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Ventas
{
    [Key]
    public int VentaId { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public double Monto { get; set; }
    public double Balance { get; set; }
    public bool Pagar { get; set; }

 [ForeignKey("VentaId")]
 public ICollection<CobrosDetalle> CobrosDetalles { get; set; } = new List<CobrosDetalle>();


}