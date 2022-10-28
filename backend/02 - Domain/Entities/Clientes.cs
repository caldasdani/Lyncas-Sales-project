using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities
{
    public class Clientes //a classe clientes possui 4 atributos
    {
        public string Nome {get; set;}
        public string Email {get; set;}
        public double Cpf {get; set;}
        public double Telefone {get; set;}
    }    
}