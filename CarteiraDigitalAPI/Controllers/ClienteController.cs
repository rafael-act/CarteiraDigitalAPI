using Aplicacao.DTO;
using Aplicacao.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IAplicacaoServicoCliente _aplicacaoServicoCliente;

        public ClientesController(IAplicacaoServicoCliente aplicacaoServicoCliente)
        {
            _aplicacaoServicoCliente = aplicacaoServicoCliente;
        }

        //[Authorize(Roles = "admin")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClienteDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _aplicacaoServicoCliente.ObterTodos());
        }

        //[Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPeloId(int id)
        {
            return Ok(await _aplicacaoServicoCliente.ObterPeloId(id));
        }

        //[Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                    return NotFound();

                await _aplicacaoServicoCliente.Adicionar(clienteDTO);
                return Ok("Cliente Cadastrado com sucesso!");
            }
            catch
            {
                throw;
            }
        }

        //[Authorize(Roles = "admin")]
        [HttpPut]
        public IActionResult Put([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                    return NotFound();

                _aplicacaoServicoCliente.Atualizar(clienteDTO);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[Authorize(Roles = "admin")]
        [HttpDelete()]
        public IActionResult Delete([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                    return NotFound();

                _aplicacaoServicoCliente.Remover(clienteDTO);
                return Ok("Cliente Removido com sucesso!");
            }
            catch
            {
                throw;
            }
        }
    }
}
