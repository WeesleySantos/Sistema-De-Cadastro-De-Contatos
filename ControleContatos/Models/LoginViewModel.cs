using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
