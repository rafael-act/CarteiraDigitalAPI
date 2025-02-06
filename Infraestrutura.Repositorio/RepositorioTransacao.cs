using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.Modelos;
using Dominio.Core.Interfaces.Repositorios;
using Infraestrutura.Data;

namespace Infraestrutura.Repositorio
{
    public class RepositorioTransacao : RepositorioBase<Transacao>, IRepositorioTransacao
    {
        private readonly CarteiraContext _context;
        public RepositorioTransacao(CarteiraContext context) : base(context)
        {
            _context = context;
        }
    }
}
