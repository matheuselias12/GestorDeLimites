using Application.Service.Interface;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GestorLimiteController : ControllerBase
    {
        private readonly ILogger<GestorLimiteController> _logger;
        private readonly IGestorLimitesService _gestorLimitesService;

        public GestorLimiteController(ILogger<GestorLimiteController> logger, IGestorLimitesService gestorLimitesService)
        {
            _logger = logger;
            _gestorLimitesService = gestorLimitesService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarLimites(GestorLimites gestorLimite)
        {
            try
            {
                await _gestorLimitesService.CadastrarLimites(gestorLimite);
                return Ok(gestorLimite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{documento}/{numConta}")]
        public async Task<IActionResult> ObterRegistros(string documento, string numConta)
        {
            try
            {
                return Ok(await _gestorLimitesService.ObterRegistros(documento, numConta));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarLimites(GestorLimites gestorLimite)
        {
            try
            {
                await _gestorLimitesService.AtualizarLimites(gestorLimite);
                return Ok(gestorLimite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("dadosTransacao")]
        public async Task<IActionResult> EnviarTrasacao(DadosTransacao dadosTransacao)
        {
            try
            {
                var result = await _gestorLimitesService.EnviarTrasacao(dadosTransacao);
                return Ok($"Registro salvo com sucesso! A conta {result.NumConta} com o documento {result.Documento} está com o valor de limite {result.LimiteTransacao}!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{documento}/{numConta}")]
        public async Task<IActionResult> RemoverRegistro(string documento, string numConta)
        {
            try
            {
                await _gestorLimitesService.RemoverRegistro(documento, numConta);
                return Ok($"A conta {numConta} com o documento {documento} foi removida com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
