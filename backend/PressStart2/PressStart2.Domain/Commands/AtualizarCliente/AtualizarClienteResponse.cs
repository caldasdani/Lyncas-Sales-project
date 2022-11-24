﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.AtualizarCliente
{
    public class AtualizarClienteResponse
    {
        public string Mensagem { get; }

        public AtualizarClienteResponse(string mensagem)
        {
            Mensagem = mensagem;
        }

    }
}
