using System;
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
    public class CobrosController : ControllerBase
    {
        private readonly Context _context;

        public CobrosController(Context context)
        {
            _context = context;
        }

        // GET: api/Cobros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cobros>>> GetCobros()
        {
          if (_context.Cobros == null)
          {
              return NotFound();
          }
            return await _context.Cobros.ToListAsync();
        }

        // GET: api/Cobros/5
        [HttpGet("{CobrosId}")]
        public async Task<ActionResult<Cobros>> GetCobros(int CobrosId)
        {
            if (_context.Cobros == null)
            {
                return NotFound();
            }

            var cobros = await _context.Cobros.Include(e => e.CobroDetalles).Where(e => e.CobroId == CobrosId).FirstOrDefaultAsync();

            if (cobros == null)
            {
                return NotFound();
            }

            foreach(var item in cobros.CobroDetalles)
            {
                Console.WriteLine($"{item.DetalleId}, {item.CobroId}, {item.VentaId}, {item.Observaciones}, {item.TotalFacturas}, {item.TotalCobrado}");
            }

            return cobros;
        }

        // GET: api/Cobros/Clientes
        [HttpGet("Clientes")]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            return await _context.Clientes.ToListAsync();
        }

        // PUT, POST, DELETE methods...

        private bool CobrosExists(int id)
        {
            return (_context.Cobros?.Any(e => e.CobroId == id)).GetValueOrDefault();
        }
    }
}
