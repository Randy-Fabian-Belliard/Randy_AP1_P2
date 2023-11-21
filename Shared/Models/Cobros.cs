using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }
    public DateTime Fecha { get; set; }

  [ForeignKey("ConbroId")]
 public ICollection<CobrosDetalle> CobroDetalles { get; set; } = new List<CobrosDetalle>();

}