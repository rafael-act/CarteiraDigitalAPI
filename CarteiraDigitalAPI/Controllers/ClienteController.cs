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

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> ObterTodos()
        {
            return Ok(_aplicacaoServicoCliente.ObterTodos());
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public ActionResult<string> ObterPeloId(int id)
        {
            return Ok(_aplicacaoServicoCliente.ObterPeloId(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult <Task> Post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                    return NotFound();

                _aplicacaoServicoCliente.Adicionar(clienteDTO);
                return Ok("Cliente Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public ActionResult Put([FromBody] ClienteDTO clienteDTO)
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

        [Authorize(Roles = "admin")]
        [HttpDelete()]
        public ActionResult Delete([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                    return NotFound();

                _aplicacaoServicoCliente.Remover(clienteDTO);
                return Ok("Cliente Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
