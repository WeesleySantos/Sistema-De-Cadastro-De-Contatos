namespace ControleContatos.Helper
{
    public interface IEmail
    {
        bool Enviar(string emal, string assunto, string mensagem);
    }
}
