using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex6.Models;

namespace ex6.Controller
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }


        [HttpPost("validateLogin")]
        public IActionResult Create(User user)
        {
            // valida se os campos login ou password estão vazios
            if (user.Login != "" && user.Password != "")
            {
                // se o usuario existir no banco retorna Ok(200)
                if (UserExists(user.Login))
                {
                    return Ok();
                }
                // senão retorna que o conteúdo não existe
                else
                {
                    return BadRequest("Usuário não encontrado");
                }
            }
            return BadRequest("Campo de login ou senha não devem estar vazios");
        }

        private bool UserExists(string login)
        {
            // verifica de o usuário existe pelo seu login
            return _context.Users.Any(e => e.Login == login);
        }
    }
}
