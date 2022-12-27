
namespace PressStart2.Domain.Commands.LoginUsuario
{
    public class LoginUsuarioResponse
    {
        public Guid Id { get; }
        public string Nome { get; }

        public LoginUsuarioResponse(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
