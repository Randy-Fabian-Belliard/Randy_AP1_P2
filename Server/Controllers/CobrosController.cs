using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial2_AP1_Randy.Client.Pages.Registros;
using Parcial2_AP1_Randy.Shared;

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
        [HttpGet("{id}")]
        public async Task<ActionResult<Cobros>> GetCobros(int id)
        {
          if (_context.Cobros == null)
          {
              return NotFound();
          }
            var cobros = await _context.Cobros
                        .Where(c => c.CobroId == id)
                        .Include(c => c.CobrosDetalle)
                        .FirstOrDefaultAsync();

            if (cobros == null)
            {
                return NotFound();
            }

            return cobros;
        }

        // PUT: api/Cobros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCobros(int id, Cobros cobros)
        {
            if (id != cobros.CobroId)
            {
                return BadRequest();
            }

            _context.Entry(cobros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CobrosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Cobros>> PostCobros(Cobros cobros)
        {
            double aux = 0.0;
            if (!CobrosExists(cobros.CobroId))
            {
                Ventas? venta = new Ventas();
                foreach (var ventaUtilizada in cobros.CobrosDetalle)
                {
                    venta = _context.Ventas.Find(ventaUtilizada.VentaId);
                    
                        if (venta != null)
                        {
                            if (venta.Balance > 0)
                            {  
                                aux = venta.Balance;

                                ventaUtilizada.Cobrado = aux;
                                venta.Monto -= venta.Balance;
                                venta.Balance = 0;

                                _context.Ventas.Update(venta);
                                await _context.SaveChangesAsync();
                            }

                        }
                }

                _context.Cobros.Add(cobros);
            }
            await _context.SaveChangesAsync();
            return Ok(cobros);
        }

        // POST: api/Cobros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Cobros>> PostCobros(Cobros cobros)
        // { 
        //     if(!CobrosExists(cobros.CobroId))
        //     {
        //         _context.Cobros.Add(cobros);
        //     }
        //     else
        //     {
        //         _context.Cobros.Update(cobros);
        //     }

        //     await _context.SaveChangesAsync();

        //     return Ok(cobros);
        // }

        // DELETE: api/Cobros/5
       /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobros(int id)
        {
            var cobros = await _context.Cobros.FindAsync(id);

            if (cobros == null)
            {
                return NotFound();
            }

            _context.Cobros.Remove(cobros);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/
        


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobros(int id)
        {
            var cobros = await _context.Cobros
                .Include(c => c.CobrosDetalle)
                .FirstOrDefaultAsync(c => c.CobroId == id);

            if (cobros == null)
            {
                return NotFound();
            }

            // Revertir las acciones realizadas al agregar Cobros
            foreach (var detalle in cobros.CobrosDetalle)
            {
                var venta = await _context.Ventas.FindAsync(detalle.VentaId);

                if (venta != null)
                {
                    venta.Balance += detalle.Cobrado;
                    venta.Monto += detalle.Cobrado;

                    _context.Ventas.Update(venta);
                    await _context.SaveChangesAsync();
                }
            }

            _context.Cobros.Remove(cobros);
            await _context.SaveChangesAsync();

            return NoContent();
        }





        private bool CobrosExists(int id)
        {
            return (_context.Cobros?.Any(e => e.CobroId == id)).GetValueOrDefault();
        }
    }
}
