
using PressStart2.Domain.Entities.Contracts;

namespace PressStart2.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }

        protected Usuario() { }

        public Usuario(string login, string senha, string nome ) 
        { 
            Login = login;
            Senha = senha;
            Nome = nome;

            this.AdicionarUsuarioContract();
        }
    }
}
