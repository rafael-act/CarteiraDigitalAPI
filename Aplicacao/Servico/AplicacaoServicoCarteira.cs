using Aplicacao.DTO;
using Aplicacao.Interface;
using Dominio.Core.Interfaces.Servicos;
using Dominio.Modelos;
using Infrastrutura.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class AplicacaoServicoCarteira : IAplicacaoServicoCarteira
    {
        private readonly IServicoCarteira _servicoCarteira;
        private readonly IServicoTransacao _servicoTransacao;
        private readonly IMapperCarteira _mapperCarteira;
        public AplicacaoServicoCarteira(IServicoCarteira servicoCarteira,
            IMapperCarteira mapperCarteira,
            IServicoTransacao servicoTransacao)
        {
            _servicoCarteira = servicoCarteira;
            _mapperCarteira = mapperCarteira;
            _servicoTransacao = servicoTransacao;
        }

        public void Adicionar(CarteiraDTO obj)
        {
            var objCarteira = _mapperCarteira.MapperToEntity(obj);
            _servicoCarteira.Adicionar(objCarteira);
        }

        public void Atualizar(CarteiraDTO obj)
        {
            var objCarteira = _mapperCarteira.MapperToEntity(obj);
            _servicoCarteira.Atualizar(objCarteira);
        }

        public void Dispose()
        {
            _servicoCarteira.Dispose();
        }

        public async Task<CarteiraDTO> ObterCarteira(string numeroCarteira)
        {
            var objCarteira = await _servicoCarteira.ObterCarteira(numeroCarteira);
            return _mapperCarteira.MapperToDTO(objCarteira);
        }

        public async Task<CarteiraDTO> ObterPeloId(int id)
        {
            var objCarteira = await _servicoCarteira.ObterPeloId(id);
            return _mapperCarteira.MapperToDTO(objCarteira);
        }

        public IEnumerable<CarteiraDTO> ObterTodos()
        {
            var objCarteira = _servicoCarteira.ObterTodos();
            return _mapperCarteira.MapperListCarteira(objCarteira);
        }

        public void Remover(CarteiraDTO obj)
        {
            var objCliente = _mapperCarteira.MapperToEntity(obj);
            _servicoCarteira.Remover(objCliente);
        }


        Task IAplicacaoServicoCarteira.AdicionarSaldoCarteira(string numeroCarteira, decimal valorAdicionar)
        {
            var carteira = _servicoCarteira.ObterCarteira(numeroCarteira).Result;
            carteira.AdicionarSaldoCarteira(valorAdicionar);
            _servicoCarteira.Atualizar(carteira);
            var transacao = new Transacao();
            transacao.DataOperacao = DateTime.UtcNow;
            transacao.TipoOperacao = "Deposito";
            transacao.ValorOperacao = valorAdicionar;
            transacao.CarteiraSacado = null;
            transacao.CarteiraCedente = carteira;
            _servicoTransacao.Adicionar(transacao);
            return Task.FromResult(0);
        }

        Task IAplicacaoServicoCarteira.TransferênciaEntreCarteiras(string carteiraCedente, string carteiraSacado, decimal valorAdicionar)
        {
            var objCarteiraCedente = _servicoCarteira.ObterCarteira(carteiraCedente).Result;//recebe
            var objCarteiraSacado = _servicoCarteira.ObterCarteira(carteiraSacado).Result;//paga



            objCarteiraCedente.AdicionarSaldoCarteira(valorAdicionar);
            objCarteiraSacado.DiminuirSaldoCarteira(valorAdicionar);

            _servicoCarteira.Atualizar(objCarteiraCedente);
            _servicoCarteira.Atualizar(objCarteiraSacado);

            var transacao = new Transacao();
            transacao.DataOperacao = DateTime.UtcNow;
            transacao.TipoOperacao = "Transferencia";
            transacao.ValorOperacao = valorAdicionar;
            transacao.CarteiraSacado = objCarteiraSacado;
            transacao.CarteiraCedente = objCarteiraCedente;
            _servicoTransacao.Adicionar(transacao);

            return Task.FromResult(0);
        }
    }
}
