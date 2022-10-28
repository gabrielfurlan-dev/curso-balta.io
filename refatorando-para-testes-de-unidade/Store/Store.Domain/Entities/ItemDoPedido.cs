namespace Store.Domain.Entities
{
    public class ItemDoPedido : Entity
    {
        public ItemDoPedido(Produto produto, int quantidade)
        {
            Produto = produto;
            Preco = produto != null ? produto.Preco : 0;
            Quantidade = quantidade;
        }

        public Produto Produto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        public decimal Total()
            => Preco * Quantidade;

        public bool Valido()
            => (Produto != null || Quantidade > 0);
    }
}