﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressStart2.Domain.Commands.RemoverCliente
{
    public class RemoverClienteResponse
    {
        public string Mensagem { get; }

        public RemoverClienteResponse(string mensagem) 
        {
            Mensagem = mensagem;
        }
    }
}
