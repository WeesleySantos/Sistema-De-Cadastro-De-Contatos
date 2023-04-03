using ControleContatos.Data;
using ControleContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }
        public ContatoViewModel Adicionar(ContatoViewModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoViewModel Atualizar(ContatoViewModel contato)
        {
            ContatoViewModel contatoDB = ListarPorId(contato.Id);
            if (contatoDB == null) throw new System.Exception("Ocorreu um erro na atualização do contato!");
            {
                contatoDB.Nome = contato.Nome;
                contatoDB.Email = contato.Email;
                contatoDB.Celular = contato.Celular;

                _context.Contatos.Update(contatoDB);
                _context.SaveChanges();

                return contatoDB;
            }
        }

        public bool Apagar(int id)
        {
            ContatoViewModel contatoDB = ListarPorId(id);
            if (contatoDB == null) throw new System.Exception("Ocorreu um erro na deleção do contato!");

            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();
            return true;
        }

        public List<ContatoViewModel> BuscarTodos(int usuarioId)
        {
            return _context.Contatos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public ContatoViewModel ListarPorId(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}
