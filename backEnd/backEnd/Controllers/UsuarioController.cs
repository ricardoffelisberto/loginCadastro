#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backEnd.Models;

namespace backEnd.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly Contexto _context;

        public UsuarioController(Contexto context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<List<Usuario>> Get()
        {
            return await _context.Usuario.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Usuario> GetById(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            var saveUsuario = _context.Usuario.Add(usuario);

            await _context.SaveChangesAsync();

            return Ok(saveUsuario.Entity);
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> Put(Usuario usuario)
        {
            var saveUsuario = _context.Usuario.Update(usuario);

            await _context.SaveChangesAsync();

            return Ok(saveUsuario.Entity);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            var saveUsuario = _context.Usuario.Remove(usuario);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
