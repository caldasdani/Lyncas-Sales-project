using MediatR;
using PressStart2.Domain.DTOs;
using PressStart2.Domain.Entities;
using PressStart2.Domain.Extensions;
using PressStart2.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;

namespace PressStart2.Domain.Commands.AdicionarUsuario
{
    public class AdicionarUsuarioHandler : Notifiable, IRequestHandler<AdicionarUsuarioRequest, CommandResponse>
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarUsuarioHandler(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public Task<CommandResponse> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            if(request.Senha != request.ConfirmacaoSenha)
            {
                AddNotification("Usuario", "Senhas não conferem");
            }

            var usuario = new Usuario(request.Login, request.Senha.EncryptSenha(), request.Nome);
            AddNotifications(usuario);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryUsuario.Adicionar(usuario);
            _repositoryUsuario.Commit();

            return Task.FromResult(new CommandResponse(
                    new AdicionarUsuarioResponse(usuario.Id, "Usuario Cadastrado"),this));
        }
    }
}
