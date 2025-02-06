using Aplicacao.DTO;
using Aplicacao.Interface;
using Dominio.Core.Interfaces.Servicos;
using Infrastrutura.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class AplicacaoServicoTransacao : IAplicacaoServicoTransacao
    {
        private readonly IServicoTransacao _servicoTransacao;
        private readonly IMapperTransacao _mapperTransacao;

        public AplicacaoServicoTransacao(IServicoTransacao servicoTransacao, IMapperTransacao mapperTransacao)
        {
            _servicoTransacao = servicoTransacao;
            _mapperTransacao = mapperTransacao;
        }

        public void Adicionar(TransacaoDTO obj)
        {
            var objTransacao = _mapperTransacao.MapperToEntity(obj);
            _servicoTransacao.Adicionar(objTransacao);
        }

        public void Atualizar(TransacaoDTO obj)
        {
            var objTransacao = _mapperTransacao.MapperToEntity(obj);
            _servicoTransacao.Atualizar(objTransacao);
        }

        public void Dispose()
        {
            _servicoTransacao.Dispose();
        }

        public TransacaoDTO ObterPeloId(int id)
        {
            var objTransacao = _servicoTransacao.ObterPeloId(id);
            return _mapperTransacao.MapperToDTO(objTransacao);
        }

        public IEnumerable<TransacaoDTO> ObterTodos()
        {
            var objTransacao = _servicoTransacao.ObterTodos();
            return _mapperTransacao.MapperListTransacao(objTransacao);
        }

        public void Remover(TransacaoDTO obj)
        {
            var objTransacao = _mapperTransacao.MapperToEntity(obj);
            _servicoTransacao.Remover(objTransacao);
        }
    }
}
