using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.Modelos;
using Dominio.Core.Interfaces.Repositorios;
using Infraestrutura.Data;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class RepositorioTransacao : RepositorioBase<Transacao>, IRepositorioTransacao
    {
        private readonly CarteiraContext _context;
        public RepositorioTransacao(CarteiraContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transacao>> ListarTransferenciasPorCliente(int clienteId, DateTime? dtInicial, DateTime? dtFinal)
        {
            IQueryable<Transacao> query = _context.Transacoes
               .Where(t => t.CarteiraCedente.Id == clienteId);

            if (dtInicial.HasValue)
            {
                query = query.Where(t => t.DataOperacao >= dtInicial.Value.ToUniversalTime());
            }

            if (dtFinal.HasValue)
            {
                query = query.Where(t => t.DataOperacao <= dtFinal.Value.ToUniversalTime());
            }

            return await query.ToListAsync();
        }

    }
}
