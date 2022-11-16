﻿using MediatR;
using PressStart2.Domain.DTOs;


namespace PressStart2.Domain.Commands.AdicionarClente
{
    public class AdicionarClienteRequest : IRequest<CommandResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set;}
        public string Cpf { get; set;}

    }
}
