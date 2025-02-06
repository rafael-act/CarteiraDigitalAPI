using Dominio.Core.Interfaces.Repositorios;
using Dominio.Core.Interfaces.Servicos;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico.Servico
{
    public class ServicoCliente : ServicoBase<Cliente>, IServicoCliente
    {
        public readonly IRepositorioCliente _repositorio;
        public ServicoCliente(IRepositorioCliente repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
