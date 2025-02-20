using Aplicacao.DTO;
using Aplicacao.Interface;
using Dominio.Core.Interfaces.UnitOfWork;
using Dominio.Modelos;
using Infrastrutura.CrossCutting.Adapter.Interfaces;

namespace Aplicacao.Servico
{
    public class AplicacaoServicoCarteira : IAplicacaoServicoCarteira, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperCarteira _mapperCarteira;
        public AplicacaoServicoCarteira(IUnitOfWork unitOfWork, IMapperCarteira mapperCarteira)
        {
            _unitOfWork = unitOfWork;
            _mapperCarteira = mapperCarteira;
        }

        public async Task Adicionar(CarteiraDTO obj)
        {
            var objCarteira = _mapperCarteira.MapperToEntity(obj);
            await _unitOfWork.Carteiras.AddAsync(objCarteira);
        }

        public void Atualizar(CarteiraDTO obj)
        {
            var objCarteira = _mapperCarteira.MapperToEntity(obj);
            _unitOfWork.Carteiras.Update(objCarteira);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<CarteiraDTO> ObterCarteira(string numeroCarteira)
        {
            var objCarteira = await _unitOfWork.Carteiras.ObterCarteira(numeroCarteira);
            return _mapperCarteira.MapperToDTO(objCarteira);
        }

        public async Task<CarteiraDTO> ObterPeloId(int id)
        {
            var objCarteira = await _unitOfWork.Carteiras.GetByIdAsync(id);
            return _mapperCarteira.MapperToDTO(objCarteira);
        }

        public async Task<IEnumerable<CarteiraDTO>> ObterTodos()
        {
            var objCarteira = await _unitOfWork.Carteiras.GetAllAsync();
            return _mapperCarteira.MapperListCarteira(objCarteira);
        }

        public void Remover(CarteiraDTO obj)
        {
            var objCliente = _mapperCarteira.MapperToEntity(obj);
            _unitOfWork.Carteiras.Remove(objCliente);
        }

        public async Task AdicionarSaldoCarteira(string numeroCarteira, decimal valorAdicionar)
        {
            var carteira = await _unitOfWork.Carteiras.ObterCarteira(numeroCarteira);
            carteira.AdicionarSaldoCarteira(valorAdicionar);
            _unitOfWork.Carteiras.Update(carteira);
            var transacao = new Transacao
            {
                DataOperacao = DateTime.UtcNow,
                TipoOperacao = "Deposito",
                ValorOperacao = valorAdicionar,
                CarteiraSacado = null,
                CarteiraCedente = carteira
            };

            await _unitOfWork.Transacoes.AddAsync(transacao);
           
            _unitOfWork.Complete();
        }

        public async Task TransferênciaEntreCarteiras(string carteiraCedente, string carteiraSacado, decimal valorAdicionar)
        {
            var objCarteiraCedente = await _unitOfWork.Carteiras.ObterCarteira(carteiraCedente);//recebe
            var objCarteiraSacado = await _unitOfWork.Carteiras.ObterCarteira(carteiraSacado);//paga



            objCarteiraCedente.AdicionarSaldoCarteira(valorAdicionar);
            objCarteiraSacado.DiminuirSaldoCarteira(valorAdicionar);

            _unitOfWork.Carteiras.Update(objCarteiraCedente);
            _unitOfWork.Carteiras.Update(objCarteiraSacado);

            var transacao = new Transacao
            {
                DataOperacao = DateTime.UtcNow,
                TipoOperacao = "Transferencia",
                ValorOperacao = valorAdicionar,
                CarteiraSacado = objCarteiraSacado,
                CarteiraCedente = objCarteiraCedente
            };
            await _unitOfWork.Transacoes.AddAsync(transacao);

            _unitOfWork.Complete();
        }
    }
}
