using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2_AP1_Randy.Shared;

public class CobrosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("CobroId")]
    public int CobroId { get; set; }

    [ForeignKey("ClienteId")]
    public int ClienteId { get; set; }

    [ForeignKey("VentaId")]
    public int VentaId { get; set; }
    public double Cobrado { get; set; }
    public bool Pagar { get; set; }
    public int TotalFacturas { get; set; }
    public double TotalCobrado { get; set; }



}