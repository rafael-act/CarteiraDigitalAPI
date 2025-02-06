using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Cliente : Base
    {
        public Cliente(string nome, string sobrenome, string email, DateTime dataCadastro, bool ativo)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataCadastro = dataCadastro;
            Ativo = ativo;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
