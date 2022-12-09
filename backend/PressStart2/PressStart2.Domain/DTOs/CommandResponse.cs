using PressStart2.Domain.Commands.ObterCliente;
using prmToolkit.NotificationPattern;
using MediatR;

namespace PressStart2.Domain.DTOs
{
    public class CommandResponse
    {
        private ObterClienteResponse obterClienteResponse;

        public bool Sucesso { get; }
        public object Dados { get; }
        public IEnumerable<Notification> Notificacoes { get; }

        public CommandResponse(object dados, INotifiable notificacoes)
        {
            Sucesso = notificacoes.IsValid();
            Dados = notificacoes.IsValid() ? dados : null;
            Notificacoes = notificacoes.Notifications;
        }

        public CommandResponse(INotifiable notificacoes)
        {
            Sucesso = false;
            Dados = null;
            Notificacoes = notificacoes.Notifications;
        }

        public CommandResponse(ObterClienteResponse obterClienteResponse)
        {
            this.obterClienteResponse = obterClienteResponse;
        }
    }

    
}
