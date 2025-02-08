using Aplicacao.DTO;
using Aplicacao.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDigitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private readonly IAplicacaoServicoCarteira _aplicacaoServicoCarteira;

        [Authorize(Roles = "admin,user")]
        [HttpGet]
        public ActionResult<Task<CarteiraDTO>> ConsultarSaldoCarteira(string numeroCarteira)
        {
            try
            {
                if (string.IsNullOrEmpty(numeroCarteira)||string.IsNullOrWhiteSpace(numeroCarteira))
                    return NotFound();

                return _aplicacaoServicoCarteira.ObterCarteira(numeroCarteira);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
