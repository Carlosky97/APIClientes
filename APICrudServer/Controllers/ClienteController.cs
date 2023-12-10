using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICrudServer.Data;
using Microsoft.EntityFrameworkCore;

namespace APICrudServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ClienteController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Cliente>>> GetCliente()
        {
            return Ok(await _context.Clientes.ToListAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if(cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente cliente)
        {
            _context.Add(cliente);

            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Cliente cliente)
        {
            if(id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if(cliente == null)
            {
                return NotFound("No esta correcto el id del cliente.");
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
