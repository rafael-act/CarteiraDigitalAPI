using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Interfaces.Repositorios
{
    public interface IRepositorioTransacao : IRepositorioBase<Transacao>
    {
        IEnumerable<Transacao> ListarTransferenciasPorCliente(int clienteId, DateTime? dtInicial, DateTime? dtFinal);
    }
}
