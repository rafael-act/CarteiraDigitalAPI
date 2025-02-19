﻿using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Interfaces.Servicos
{
    public interface IServicoTransacao:IServicoBase<Transacao>
    {
        IEnumerable<Transacao> ListarTransferenciasPorCliente(int clienteId, DateTime? dtInicial, DateTime? dtFinal);
    }
}
