using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não e válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "O Celular informado não é válido!")]
        public string Celular { get; set; }
        public int? UsuarioId { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}
