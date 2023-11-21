using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Parcial2_AP1_Randy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly Context _context;

        public VentasController(Context context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas()
        {
            try
            {
                if (_context.Ventas == null)
                {
                    return NotFound();
                }

                var ventas = await _context.Ventas.ToListAsync();

                if (ventas == null || !ventas.Any())
                {
                    return NotFound();
                }

                return ventas;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error en el servidor: {ex.Message}");
            }
        }
        

    }
}
