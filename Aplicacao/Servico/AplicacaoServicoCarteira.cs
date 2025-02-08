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
    public class AplicacaoServicoCarteira : IAplicacaoServicoCarteira
    {
        private readonly IServicoCarteira _servicoCarteira;
        private readonly IMapperCarteira _mapperCarteira;
        public AplicacaoServicoCarteira(IServicoCarteira servicoCarteira, IMapperCarteira mapperCarteira)
        {
            _servicoCarteira = servicoCarteira;
            _mapperCarteira = mapperCarteira;
        }

        public void Adicionar(CarteiraDTO obj)
        {
            var objCarteira = _mapperCarteira.MapperToEntity(obj);
            _servicoCarteira.Adicionar(objCarteira);
        }

        public void Atualizar(CarteiraDTO obj)
        {
            var objCarteira = _mapperCarteira.MapperToEntity(obj);
            _servicoCarteira.Atualizar(objCarteira);
        }

        public void Dispose()
        {
            _servicoCarteira.Dispose();
        }

        public async Task<CarteiraDTO> ObterCarteira(string numeroCarteira)
        {
            var objCarteira = await _servicoCarteira.ObterCarteira(numeroCarteira);
            return _mapperCarteira.MapperToDTO(objCarteira);
        }

        public async Task<CarteiraDTO> ObterPeloId(int id)
        {
            var objCarteira = await _servicoCarteira.ObterPeloId(id);
            return _mapperCarteira.MapperToDTO(objCarteira);
        }

        public IEnumerable<CarteiraDTO> ObterTodos()
        {
            var objCarteira = _servicoCarteira.ObterTodos();
            return _mapperCarteira.MapperListClientes(objCarteira);
        }

        public void Remover(CarteiraDTO obj)
        {
            var objCliente = _mapperCarteira.MapperToEntity(obj);
            _servicoCarteira.Remover(objCliente);
        }
    }
}
