using Dominio.Core.Interfaces.Repositorios;
using Dominio.Modelos;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class RepositorioCarteira : RepositorioBase<Carteira>, IRepositorioCarteira
    {
        public RepositorioCarteira(CarteiraContext context) : base(context)
        {

        }

        public async Task<Carteira> ObterCarteira(string numeroCarteira)
        {
            var carteira = await _context.Carteiras.Include(x=>x.Cliente)
                .FirstOrDefaultAsync(x => x.NumeroCarteira == numeroCarteira) ?? throw new KeyNotFoundException($"Carteira com número {numeroCarteira} não encontrada.");
            
            Console.WriteLine(carteira.Cliente?.Nome);
            return carteira;
        }
    }
}
