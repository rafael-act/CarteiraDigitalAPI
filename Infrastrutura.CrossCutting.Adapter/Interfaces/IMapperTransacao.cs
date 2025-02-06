using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.DTO;
using Dominio.Modelos;

namespace Infrastrutura.CrossCutting.Adapter.Interfaces
{
    public interface IMapperTransacao
    {
        #region Mappers

        Transacao MapperToEntity(TransacaoDTO transacaoDTO);

        IEnumerable<TransacaoDTO> MapperListTransacao(IEnumerable<Transacao> transacao);

        TransacaoDTO MapperToDTO(Transacao transacao);

        #endregion
    }
}
