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
    public class MapperCarteira : IMapperCarteira
    {
        List<CarteiraDTO> carteiraDTOs = new List<CarteiraDTO>();

        public Carteira MapperToEntity(CarteiraDTO carteiraDTO)
        {
            Carteira carteira = new Carteira(carteiraDTO.NumeroCarteira, carteiraDTO.DataCriacao, carteiraDTO.Situacao, carteiraDTO.Saldo, carteiraDTO.Cliente)
            {
                Id = carteiraDTO.Id
            };

            return carteira;

        }
        public IEnumerable<CarteiraDTO> MapperListClientes(IEnumerable<Carteira> carteira)
        {
            foreach (var item in carteira)
            {
                CarteiraDTO carteiraDTO = new CarteiraDTO(item.Id, item.NumeroCarteira, item.DataCriacao, item.Situacao, item.Saldo, item.Cliente);
                carteiraDTOs.Add(carteiraDTO);
            }
            return carteiraDTOs;
        }

        public CarteiraDTO MapperToDTO(Carteira carteira)
        {
            CarteiraDTO carteiraDTO = new CarteiraDTO(carteira.Id, carteira.NumeroCarteira, carteira.DataCriacao, carteira.Situacao, carteira.Saldo, carteira.Cliente);
            return carteiraDTO;
        }

       
    }
}
