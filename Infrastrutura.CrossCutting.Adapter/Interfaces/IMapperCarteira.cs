using Aplicacao.DTO;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrutura.CrossCutting.Adapter.Interfaces
{
    public interface IMapperCarteira
    {
        #region Mappers

        Carteira MapperToEntity(CarteiraDTO carteiraDTO);

        IEnumerable<CarteiraDTO> MapperListCarteira(IEnumerable<Carteira> carteira);

      CarteiraDTO MapperToDTO(Carteira carteira);


        #endregion
    }
}
