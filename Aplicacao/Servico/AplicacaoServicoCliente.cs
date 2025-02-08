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
    public class AplicacaoServicoCliente : IAplicacaoServicoCliente
    {
        private readonly IServicoCliente _servicoCliente;
        private readonly IMapperCliente _mapperCliente;

        public AplicacaoServicoCliente(IServicoCliente servicoCliente, IMapperCliente mapperCliente)
        {
            _servicoCliente = servicoCliente;
            _mapperCliente = mapperCliente;
        }

        public async Task Adicionar(ClienteDTO obj)
        {
            var objCliente = _mapperCliente.MapperToEntity(obj);
            await _servicoCliente.Adicionar(objCliente);
        }

        public void Atualizar(ClienteDTO obj)
        {
            var objCliente = _mapperCliente.MapperToEntity(obj);
            _servicoCliente.Atualizar(objCliente);
        }

        public void Dispose()
        {
            _servicoCliente.Dispose();
        }

        public async Task<ClienteDTO> ObterPeloId(int id)
        {
            var objCliente = await _servicoCliente.ObterPeloId(id);
            return _mapperCliente.MapperToDTO(objCliente);
        }

        public IEnumerable<ClienteDTO> ObterTodos()
        {
            var objCliente = _servicoCliente.ObterTodos();
            return _mapperCliente.MapperListClientes(objCliente);
        }

        public void Remover(ClienteDTO obj)
        {
            var objCliente = _mapperCliente.MapperToEntity(obj);
            _servicoCliente.Remover(objCliente);
        }
    }
}
