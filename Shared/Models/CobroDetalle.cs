using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CobrosDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public int CobroId { get; set; }
    public int VentaId { get; set; }
    public string? Observaciones { get; set; }
    public int TotalFacturas { get; set; }
    public int TotalCobrado { get; set; }
    

     
}