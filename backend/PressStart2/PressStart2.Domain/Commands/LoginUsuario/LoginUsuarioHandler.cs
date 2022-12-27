
using MediatR;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Extensions;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;

namespace PressStart2.Domain.Commands.LoginUsuario
{
    public class LoginUsuarioHandler : Notifiable, IRequestHandler<LoginUsuarioRequest, CommandResponse>
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public LoginUsuarioHandler(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public Task<CommandResponse> Handle(LoginUsuarioRequest request, CancellationToken cancellationToken)
        {
            var usuario = _repositoryUsuario.Autenticar(request.Login, request.Senha.EncryptSenha());

            if (usuario == null)
            {
                AddNotification("LoginUsuario", "Usuario e Senha não conferem");
                return Task.FromResult(new CommandResponse(this));
            }

            return Task.FromResult(new CommandResponse(new LoginUsuarioResponse(usuario.Id, usuario.Nome), this));
        }
    }
}
