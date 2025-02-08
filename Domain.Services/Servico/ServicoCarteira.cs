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
    public class ServicoCarteira : ServicoBase<Carteira>, IServicoCarteira
    {
        public readonly IRepositorioCarteira _repositorio;
        public ServicoCarteira(IRepositorioCarteira repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }


        Task<Carteira> IServicoCarteira.ObterCarteira(string numeroCarteira)
        {
            return _repositorio.ObterCarteira(numeroCarteira);

        }
    }
}
