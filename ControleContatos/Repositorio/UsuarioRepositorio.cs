using ControleContatos.Data;
using ControleContatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }
        public UsuarioViewModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioViewModel BuscarPorEmailELogin(string login, string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel usuario)
        {
            UsuarioViewModel usuarioDB = ListarPorId(usuario.Id);
            if (usuarioDB == null) throw new System.Exception("Ocorreu um erro na atualização do usuário!");
            {
                usuarioDB.Nome = usuario.Nome;
                usuarioDB.Email = usuario.Email;
                usuarioDB.Login = usuario.Login;
                usuarioDB.Perfil = usuario.Perfil;
                usuarioDB.DataAtualizacao = DateTime.Now;

                _context.Usuarios.Update(usuarioDB);
                _context.SaveChanges();

                return usuarioDB;
            }
        }
        public UsuarioViewModel AlterarSenha(AlterarSenhaViewModel alterarSenha)
        {
            UsuarioViewModel usuarioDB = ListarPorId(alterarSenha.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if(!usuarioDB.SenhaValida(alterarSenha.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuarioDB.SenhaValida(alterarSenha.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");

            usuarioDB.SetNovaSenha(alterarSenha.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }
        public bool Apagar(int id)
        {
            UsuarioViewModel usuarioDB = ListarPorId(id);
            if (usuarioDB == null) throw new System.Exception("Ocorreu um erro na deleção do usuário!");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();
            return true;
        }

        public List<UsuarioViewModel> BuscarTodos()
        {
            return _context.Usuarios.Include(x => x.Contatos).ToList();
        }

        public UsuarioViewModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}
