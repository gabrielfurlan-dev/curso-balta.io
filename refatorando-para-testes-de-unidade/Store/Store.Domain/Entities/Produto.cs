namespace Store.Domain.Entities
{
    public class Produto : Entity
    {
        public Produto(string nome, decimal preco, bool ativo)
        {
            Nome = nome;
            Preco = preco;
            Ativo = ativo;
        }

        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }
    }
}