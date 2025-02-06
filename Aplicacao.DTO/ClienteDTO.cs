namespace Aplicacao.DTO
{
    public class ClienteDTO
    {
        public ClienteDTO(int? id, string nome, string sobrenome, string email, DateTime dataCadastro, bool ativo)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataCadastro = dataCadastro;
            Ativo = ativo;
        }

        public int? Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}