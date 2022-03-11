using backEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace backEnd.Controllers
{

    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly Contexto _context;

        public LoginController(Contexto context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Login(Login login)
        {
            var result = _context.Login.Where(l =>
                (l.Username == login.Username) && (l.Password == login.Password)
                ).FirstOrDefault();

            if (result != null)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}