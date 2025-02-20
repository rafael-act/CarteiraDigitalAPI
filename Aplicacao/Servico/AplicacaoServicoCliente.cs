using Aplicacao.DTO;
using Aplicacao.Interface;
using Dominio.Core.Interfaces.UnitOfWork;
using Infrastrutura.CrossCutting.Adapter.Interfaces;

namespace Aplicacao.Servico
{
    public class AplicacaoServicoCliente : IAplicacaoServicoCliente
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperCliente _mapperCliente;

        public AplicacaoServicoCliente(IUnitOfWork unitOfWork, IMapperCliente mapperCliente)
        {
            _unitOfWork = unitOfWork;
            _mapperCliente = mapperCliente;
        }

        public async Task Adicionar(ClienteDTO obj)
        {
            var objCliente = _mapperCliente.MapperToEntity(obj);
            await _unitOfWork.Clientes.AddAsync(objCliente);
        }

        public void Atualizar(ClienteDTO obj)
        {
            var objCliente = _mapperCliente.MapperToEntity(obj);
            _unitOfWork.Clientes.Update(objCliente);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<ClienteDTO> ObterPeloId(int id)
        {
            var objCliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            return _mapperCliente.MapperToDTO(objCliente);
        }

        public async Task<IEnumerable<ClienteDTO>> ObterTodos()
        {
            var objCliente = await _unitOfWork.Clientes.GetAllAsync();
            return _mapperCliente.MapperListClientes(objCliente);
        }

        public void Remover(ClienteDTO obj)
        {
            var objCliente = _mapperCliente.MapperToEntity(obj);
            _unitOfWork.Clientes.Remove(objCliente);
        }
    }
}
