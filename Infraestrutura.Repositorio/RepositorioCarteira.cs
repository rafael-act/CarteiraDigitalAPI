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
    public class RepositorioCarteira : RepositorioBase<Carteira>, IRepositorioCarteira
    {
        private readonly CarteiraContext _context;
        public RepositorioCarteira(CarteiraContext context) : base(context)
        {   
            _context = context;
        }
    }
}
