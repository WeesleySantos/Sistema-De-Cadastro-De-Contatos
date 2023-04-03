using ControleContatos.Models;
using System.Collections.Generic;

namespace ControleContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioViewModel BuscarPorLogin(string login);
        UsuarioViewModel BuscarPorEmailELogin(string login, string email);
        List<UsuarioViewModel> BuscarTodos();
        UsuarioViewModel ListarPorId(int id);
        UsuarioViewModel Adicionar(UsuarioViewModel usuario);
        UsuarioViewModel Atualizar(UsuarioViewModel contato);
        UsuarioViewModel AlterarSenha(AlterarSenhaViewModel alterarSenha);
        bool Apagar(int id);

    }
}
