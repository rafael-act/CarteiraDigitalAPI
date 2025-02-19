using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelos;
using Dominio.Core.Interfaces.Repositorios;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class RepositorioCarteira : RepositorioBase<Carteira>, IRepositorioCarteira
    {
        private readonly CarteiraContext _context;
        public RepositorioCarteira(CarteiraContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Carteira> ObterCarteira(string numeroCarteira)
        {
            var carteira = await _context.Carteiras.Include(x=>x.Cliente)
                .FirstOrDefaultAsync(x => x.NumeroCarteira == numeroCarteira);

            if (carteira == null)
                throw new KeyNotFoundException($"Carteira com número {numeroCarteira} não encontrada.");
            Console.WriteLine(carteira.Cliente?.Nome);
            return carteira;
        }
    }
}
