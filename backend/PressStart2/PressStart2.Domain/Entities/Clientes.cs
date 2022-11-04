using System;
using PressStart2.Domain.Entities;

namespace PressStart2.Domain.Entities
{
    public class Cliente : EntidadeBase //a classe cliente possui 5 atributos
    {
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public string? Cpf { get; private set; }
        public string? Telefone { get; private set; }
        public bool FlagAtivo { get; private set; }

        protected Cliente() { } // construtor protegido sem parametro

        public Cliente(string nome, string email, string cpf, string telefone) 
            //construtor publico com parametros com o intuito de add o cliente
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
            FlagAtivo = true;

            //this.AdicionarClienteContract();
        }

        public void Atualizar(string nome, string email, string cpf, string telefone)
            //Metodo para atualizar um cliente
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;

            //this.AtualizarClienteContract();
        }
        public void Inativar()
            //Metodo para inativar cliente --> Cliente.Inativar
        {
            FlagAtivo = false;
        }
    }
}