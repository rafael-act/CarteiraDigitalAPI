using Aplicacao.DTO;
using Dominio.Modelos;
using Infrastrutura.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.CrossCutting.Adapter.Map
{
    public class MapperTransacao : IMapperTransacao
    {
        List<TransacaoDTO> transacaoList = new List<TransacaoDTO>();
        public IEnumerable<TransacaoDTO> MapperListTransacao(IEnumerable<Transacao> transacao)
        {
            foreach (var item in transacao)
            {
                TransacaoDTO carteiraDTO = new TransacaoDTO(item.TipoOperacao, item.CarteiraSacado, item.CarteiraCedente);
                transacaoList.Add(carteiraDTO);
            }
            return transacaoList;
        }

        public TransacaoDTO MapperToDTO(Transacao transacao)
        {
            TransacaoDTO transacaoDTO = new TransacaoDTO(transacao.TipoOperacao,transacao.CarteiraSacado,transacao.CarteiraCedente)
            {
                Id = transacao.Id,
                DataOperacao = transacao.DataOperacao,
                ValorOperacao = transacao.ValorOperacao
            };
            return transacaoDTO;
        }

        public Transacao MapperToEntity(TransacaoDTO transacaoDTO)
        {
            Transacao transacao = new Transacao(transacaoDTO.DataOperacao,transacaoDTO.TipoOperacao,transacaoDTO.ValorOperacao,transacaoDTO.CarteiraSacado,transacaoDTO.CarteiraCedente)
            {
                Id = transacaoDTO.Id,
            };
            return transacao;
        }
    }
}
