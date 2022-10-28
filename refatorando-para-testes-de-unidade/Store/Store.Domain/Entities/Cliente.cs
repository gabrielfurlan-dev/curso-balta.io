namespace Store.Domain.Entities
{
    public class Cliente : Entity
    {
        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
        //Utilizar o private set para que não sejam alterados por qualquer classe
        public string Nome { get; private set; }
        public string Email { get; private set; }
    }
} 