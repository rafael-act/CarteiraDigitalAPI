using Aplicacao.Interface;
using CarteiraDigitalAPI.Controllers;
using CarteiraTeste.MockData;
using Dominio.Modelos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraTeste.Apresentacao.CarteiraDigitalAPI.Controllers
{
   public class TestTransacaoController
    {
        [Fact]
        public void GetTodasTransferenciasCliente_ShouldReturn200Status()
        {
            var idcliente = 1;
            /// Arrange
            var transacaoService = new Mock<IAplicacaoServicoTransacao>();
            transacaoService.Setup(_ => _.ListarTransferenciasPorCliente(idcliente,DateTime.UtcNow,DateTime.UtcNow))
                .Returns((IEnumerable<Aplicacao.DTO.TransacaoDTO>)TransferenciaMockData.ObterTarefas());
            var sut = new TransacaoController(transacaoService.Object);
            /// Act
            var result = (JsonResult)sut.ListarTransferenciasPorCliente(idcliente, DateTime.UtcNow, DateTime.UtcNow);

            // /// Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
