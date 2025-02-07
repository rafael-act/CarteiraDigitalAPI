using CarteiraDigitalAPI.Seguranca;
using Dominio.Modelos;
using Dominio.Modelos.ViewModel;
using Infraestrutura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using System.Threading.Tasks;

namespace CarteiraDigitalAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegisterViewModel model,
                                              [FromServices] CarteiraContext context)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new Cliente(model.Name,"",model.Email,DateTime.Now,true)
            {
                Slug = model.Email.Replace("@", "-").Replace(".", "-"),
                RolesId = 1,
                PasswordHash = PasswordHasher.Hash(model.Password),
            };
            try
            {
                await context.Clientes.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok($"{user.Email} {user.PasswordHash}");
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, "Email Duplicado");
            }
            catch
            {
                return StatusCode(500, "Error Interno");
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(
       [FromBody] LoginViewModel model,
       [FromServices] CarteiraContext context,
       [FromServices] TokenService tokenService)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var cliente = await context
               .Clientes
               .Include(x => x.Roles)
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (cliente == null)
                return StatusCode(401, "Usuário ou password inválido");

            if (!PasswordHasher.Verify(cliente.PasswordHash, model.Password))
                return StatusCode(401, "Usuário ou password inválido");

            try
            {
                var token = tokenService.GerarToken(cliente);
                return Ok(token);
            }
            catch
            {
                return StatusCode(500, "Erro Interno");
            }

        }

        [Authorize(Roles = "admin")]
        [HttpPatch("ModificarPermissaoUsuario")]
        public async Task<IActionResult> ModificarRole(int UserId,
                                                    int NewRoleId,
                                                    [FromServices] CarteiraContext context)
        {
            var user = await context
                .Clientes
                .FirstOrDefaultAsync(x => x.Id == UserId);

            var role = await context
                .Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == NewRoleId);

            if (user == null || role == null)
                return StatusCode(401, "Id Inválido");

            user.Roles = role;

            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
