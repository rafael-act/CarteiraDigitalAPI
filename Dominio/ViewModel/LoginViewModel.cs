using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email deve ser válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password é obrigatório")]
        public string Password { get; set; }
    }
}
