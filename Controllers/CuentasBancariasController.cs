using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CuentaBancaria.Data;
using CuentaBancaria.Models;

namespace CuentaBancaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasBancariasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CuentasBancariasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Datos_Cuenta>>> Get()
        {
            return await _context.CuentasBancarias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Datos_Cuenta>> Get(int id)
        {
            var cuenta = await _context.CuentasBancarias.FindAsync(id);

            if (cuenta == null)
                return NotFound();

            return cuenta;
        }

        [HttpPost]
        public async Task<ActionResult<Datos_Cuenta>> Post(Datos_Cuenta cuenta)
        {
            _context.CuentasBancarias.Add(cuenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = cuenta.ID }, cuenta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Datos_Cuenta cuenta)
        {
            if (id != cuenta.ID)
                return BadRequest();

            _context.Entry(cuenta).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cuenta = await _context.CuentasBancarias.FindAsync(id);

            if (cuenta == null)
                return NotFound();

            _context.CuentasBancarias.Remove(cuenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
