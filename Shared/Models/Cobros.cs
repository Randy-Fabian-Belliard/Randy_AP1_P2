using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2_AP1_Randy.Shared;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public DateTime Fecha  { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string? Observacion  { get; set; }

    [ForeignKey("CobroId")]
    public ICollection<CobrosDetalle> CobrosDetalle { get; set; } = new List<CobrosDetalle>();

}









