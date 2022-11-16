using MediatR;
using PressStart2.Domain.DTOs;

namespace PressStart2.Domain.Commands.ListarCliente
{
    public class ListarClienteRequest : IRequest<CommandResponse>
    {                                //propriedade padrão do Mediator
                                     //A classe commandResponse padroniza os retornos

        // sem parametros pq nao quero especificar nada, quero listar TODOS os cliente.
    }
}
