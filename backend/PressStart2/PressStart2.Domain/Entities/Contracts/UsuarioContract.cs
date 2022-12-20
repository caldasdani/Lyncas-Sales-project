
using prmToolkit.NotificationPattern;

namespace PressStart2.Domain.Entities.Contracts
{
    public static class UsuarioContract 
    {
        public static void AdicionarUsuarioContract(this Usuario usuario)
        {
            new AddNotifications<Usuario>(usuario)
                .IfNullOrInvalidLength(p => p.Login, 1, 100)
                .IfNullOrInvalidLength(p => p.Senha, 1, 100)
                .IfNotEmail(p => p.Login);
        }
    }
}
