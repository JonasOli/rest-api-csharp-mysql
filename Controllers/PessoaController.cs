using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex6.Models;

namespace ex6.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaContext _context;

        public PessoaController(PessoaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Pessoas.ToListAsync());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            // Valida se algum campo está vazio
            if (ModelState.IsValid)
            {
                // se uma pessoa ja existe retorna 400
                if (PessoaExists(pessoa.CPF))
                {
                    return BadRequest("Pessoa já cadastrada");
                }
                // senao adicioana ela ao banco de dados
                else
                {
                    _context.Add(pessoa);
                    await _context.SaveChangesAsync();
                    return Ok(pessoa);
                }
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteConfirmed([FromQuery] string cpf)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(p => p.CPF == cpf);
            // verifica se a pessoa foi encontrada
            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        private bool PessoaExists(string cpf)
        {
            return _context.Pessoas.Any(e => e.CPF == cpf);
        }
    }
}
