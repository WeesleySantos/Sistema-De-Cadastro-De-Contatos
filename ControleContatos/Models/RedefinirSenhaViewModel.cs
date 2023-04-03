using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class RedefinirSenhaViewModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }
    }
}
