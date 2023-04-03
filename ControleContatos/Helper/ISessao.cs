using ControleContatos.Models;

namespace ControleContatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioViewModel usuario);
        void RemoverSessaoDoUsuario();
        UsuarioViewModel BuscarSessaoDoUusario();
    }
}
