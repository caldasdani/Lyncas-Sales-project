using PressStart2.Domain.Commands.ListarCliente;
using PressStart2.Domain.Entities;

namespace PressStart2.Domain.Interfaces.Repositories
{
    public interface IRepositoryCliente : IRepositoryBase<Cliente>
    {
        bool VerificaDuplicidade(string cpf);

    }
}
