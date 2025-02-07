using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    [Table("teachers")]
    public class Cliente : DbContext
    {
        public Cliente(int id, string nome, string sobrenome, string email, DateTime dataCadastro, bool ativo)
        {
            Id = Id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataCadastro = dataCadastro;
            Ativo = ativo;
        }
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int? Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("sobrenome")]
        public string Sobrenome { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("datacadastro")]
        public DateTime DataCadastro { get; set; }
        [Column("ativo")]
        public bool Ativo { get; set; }
        [Column("passwordhash")]
        public string? PasswordHash { get; set; }
        [Column("slug")]
        public string? Slug { get; set; }
        [Column("rolesid")]
        public int RolesId { get; set; }
        public Role? Roles { get; set; }
    }
}
