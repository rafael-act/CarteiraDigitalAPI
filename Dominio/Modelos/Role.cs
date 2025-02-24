using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Modelos
{
    [Table("role")]
    public class Role
    {
        public Role(string nome)
        {
            Nome = nome;
        }
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
