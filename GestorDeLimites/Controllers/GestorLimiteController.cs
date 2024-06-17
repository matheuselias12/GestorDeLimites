using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GestorLimiteController : ControllerBase
    {
        private readonly ILogger<GestorLimiteController> _logger;

        public GestorLimiteController(ILogger<GestorLimiteController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarLimites(GestorLimite gestorLimite)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ObterRegistros()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarLimites(GestorLimite gestorLimite)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverRegistro(GestorLimite gestorLimite)
        {
            return Ok();
        }
    }
}
