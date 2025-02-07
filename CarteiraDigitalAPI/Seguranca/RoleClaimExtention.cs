using Dominio.Modelos;
using System.Security.Claims;

namespace CarteiraDigitalAPI.Seguranca
{
    public static class RoleClaimExtention
    {
        public static IEnumerable<Claim> GetClaims(this Cliente usuario)
        {
            var result = new List<Claim>
            {
                new(ClaimTypes.Name, usuario.Nome),
                new(ClaimTypes.Email, usuario.Email),
                new(ClaimTypes.Role, usuario.Roles.Name)
            };
            return result;
        }
    }
}
