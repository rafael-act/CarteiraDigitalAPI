using Aplicacao.DTO;
using Aplicacao.Interface;
using Dominio.Core.Interfaces.UnitOfWork;
using Infrastrutura.CrossCutting.Adapter.Interfaces;

namespace Aplicacao.Servico
{
    public class AplicacaoServicoTransacao : IAplicacaoServicoTransacao
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperTransacao _mapperTransacao;

        public AplicacaoServicoTransacao(IUnitOfWork unitOfWork, IMapperTransacao mapperTransacao)
        {
            _unitOfWork = unitOfWork;
            _mapperTransacao = mapperTransacao;
        }

        public async Task Adicionar(TransacaoDTO obj)
        {
            var objTransacao = _mapperTransacao.MapperToEntity(obj);
            await _unitOfWork.Transacoes.AddAsync(objTransacao);
        }

        public void Atualizar(TransacaoDTO obj)
        {
            var objTransacao = _mapperTransacao.MapperToEntity(obj);
            _unitOfWork.Transacoes.Update(objTransacao);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public  async Task<IEnumerable<TransacaoDTO>> ListarTransferenciasPorCliente(int clienteId, DateTime? dtInicial, DateTime? dtFinal)
        {
            var lista = await _unitOfWork.Transacoes.ListarTransferenciasPorCliente(clienteId, dtInicial, dtFinal);
            return _mapperTransacao.MapperListTransacao(lista);
        }

        public async Task<TransacaoDTO> ObterPeloId(int id)
        {
            var objTransacao = await _unitOfWork.Transacoes.GetByIdAsync(id);
            return _mapperTransacao.MapperToDTO(objTransacao);
        }

        public async Task<IEnumerable<TransacaoDTO>> ObterTodos()
        {
            var objTransacao = await _unitOfWork.Transacoes.GetAllAsync();
            return _mapperTransacao.MapperListTransacao(objTransacao);
        }

        public void Remover(TransacaoDTO obj)
        {
            var objTransacao = _mapperTransacao.MapperToEntity(obj);
            _unitOfWork.Transacoes.Remove(objTransacao);
        }
    }
}
