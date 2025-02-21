using Dominio.Modelos;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace CarteiraTeste.Dominio.Modelos
{
    public class CarteiraTest
    {
        [Fact]
        public void AdicionarSaldoCarteiraTest()
        {
            var carteira = new Carteira();
            carteira.Saldo = 50;
            var valorParaAdicionar = 5000;
            var valorTotal = 5050;
            Assert.Equal(valorTotal,carteira.AdicionarSaldoCarteira(valorParaAdicionar));
        }

        [Fact]
        public void DiminuirSaldoCarteiraTest()
        {
            var carteira = new Carteira();
            carteira.Saldo = 5000;
            var valorParaDiminuir = 50;
            var valorTotal = 4950;
            Assert.Equal(valorTotal, carteira.DiminuirSaldoCarteira(valorParaDiminuir));
        }

        [Fact]
        public void DiminuirSaldoCarteiraTest_exception()
        {
            var carteira = new Carteira();
            carteira.Saldo = 50;
            var valorParaDiminuir = 5000;
            var valorTotal = 4950;
            Assert.Throws<InvalidOperationException>(() => (carteira.DiminuirSaldoCarteira(valorParaDiminuir)));
        }
    }
}