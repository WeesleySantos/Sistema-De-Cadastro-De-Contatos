using ControleContatos.Models;
using System.Collections.Generic;

namespace ControleContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoViewModel> BuscarTodos(int usuarioId);
        ContatoViewModel ListarPorId(int id);
        ContatoViewModel Adicionar(ContatoViewModel contato);
        ContatoViewModel Atualizar(ContatoViewModel contato);
        bool Apagar(int id);
    }
}
