using ControleContatos.Helper;
using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepostorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepostorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaViewModel alterarSenha)
        {
            try
            {
                UsuarioViewModel usuarioLogado = _sessao.BuscarSessaoDoUusario();
                alterarSenha.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {
                    _usuarioRepostorio.AlterarSenha(alterarSenha);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenha);
                }
                return View("Index", alterarSenha);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel alterar sua senha, tente novamente, detalhe do erro: {erro.Message}";
                return View("Index", alterarSenha);
            }
        }
    }
}
