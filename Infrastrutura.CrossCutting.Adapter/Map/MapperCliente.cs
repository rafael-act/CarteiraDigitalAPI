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
    public class MapperCliente : IMapperCliente
    {
        #region properties

        List<ClienteDTO> clienteDTOs = new List<ClienteDTO>();

        #endregion
        #region methods

        public Cliente MapperToEntity(ClienteDTO clienteDTO)
        {
            Cliente cliente = new Cliente(clienteDTO.Nome,clienteDTO.Sobrenome,clienteDTO.Email,clienteDTO.DataCadastro,clienteDTO.Ativo)
            {
                Id = clienteDTO.Id
            };

            return cliente;

        }


        public IEnumerable<ClienteDTO> MapperListClientes(IEnumerable<Cliente> clientes)
        {
            foreach (var item in clientes)
            {


                ClienteDTO clienteDTO = new ClienteDTO(item.Id, item.Nome, item.Sobrenome, item.Email, item.DataCadastro, item.Ativo);
                clienteDTOs.Add(clienteDTO);

            }

            return clienteDTOs;
        }

        public ClienteDTO MapperToDTO(Cliente cliente)
        {

            ClienteDTO clienteDTO = new ClienteDTO(cliente.Id, cliente.Nome, cliente.Sobrenome, cliente.Email, cliente.DataCadastro, cliente.Ativo);
            return clienteDTO;

        }

        #endregion
    }
}
