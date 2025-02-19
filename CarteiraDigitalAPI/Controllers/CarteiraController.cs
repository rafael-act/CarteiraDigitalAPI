using Aplicacao.DTO;
using Aplicacao.Interface;
using Dominio.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarteiraDigitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private readonly IAplicacaoServicoCarteira _aplicacaoServicoCarteira;
        public CarteiraController(IAplicacaoServicoCarteira aplicacaoServicoCarteira)
        {
            _aplicacaoServicoCarteira = aplicacaoServicoCarteira;
        }

        //[Authorize(Roles = "admin,user")]
        [HttpGet]
        [Route("ConsultarSaldoCarteira")]
        public async Task<ActionResult<CarteiraDTO?>> ConsultarSaldoCarteira(string numeroCarteira)
        {
            try
            {
                if (string.IsNullOrEmpty(numeroCarteira) || string.IsNullOrWhiteSpace(numeroCarteira))
                    return null;

                return _aplicacaoServicoCarteira.ObterCarteira(numeroCarteira).Result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "admin,user")]
        [HttpPost]
        [Route("AdicionarSaldoCarteira")]
        public IActionResult AdicionarSaldoCarteira(string numeroCarteira, decimal valorAdicionar)
        {
            try
            {
                if (string.IsNullOrEmpty(numeroCarteira) || string.IsNullOrWhiteSpace(numeroCarteira))
                    return NotFound();
                if (valorAdicionar <= 0)
                {
                    return StatusCode(400, "Valor a adicionar na carteira obrigatório.");
                }
                _aplicacaoServicoCarteira.AdicionarSaldoCarteira(numeroCarteira, valorAdicionar);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[Authorize(Roles = "admin,user")]
        [HttpPost]
        [Route("TransferênciaEntreCarteiras")]
        public IActionResult TransferênciaEntreCarteiras(string carteiraCedente, string carteiraSacado, decimal valorAdicionar)
        {
            try
            {
                if (string.IsNullOrEmpty(carteiraCedente) || string.IsNullOrWhiteSpace(carteiraCedente))
                    return NotFound();
                if (string.IsNullOrEmpty(carteiraSacado) || string.IsNullOrWhiteSpace(carteiraSacado))
                    return NotFound();
                if (valorAdicionar <= 0)
                {
                    return StatusCode(400, "Valor a movimentar nas carteiras obrigatório.");
                }
                _aplicacaoServicoCarteira.TransferênciaEntreCarteiras(carteiraCedente, carteiraSacado, valorAdicionar);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao realizar transação. Verifique os números das carteiras.");
            }

            return Ok();
        }



    }
}
