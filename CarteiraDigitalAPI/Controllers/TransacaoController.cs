using Aplicacao.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigitalAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly IAplicacaoServicoTransacao _aplicacaoServicoTransferencia;
        public TransacaoController(IAplicacaoServicoTransacao aplicacaoServicoTransacao)
        {
            _aplicacaoServicoTransferencia = aplicacaoServicoTransacao;
        }

        //[Authorize(Roles = "admin,user")]
        [HttpGet]
        [Route("ListarTransferenciasPorCliente/{clienteId}")]
        public async Task<IActionResult> ListarTransferenciasPorCliente(int clienteId, DateTime? dtInicial, DateTime? dtFinal)
        {
            try
            {
                if (clienteId <= 0)
                    return NotFound();

                var lista = await _aplicacaoServicoTransferencia.ListarTransferenciasPorCliente(clienteId, dtInicial, dtFinal);
                return new JsonResult(lista.ToList());
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
