namespace Store.Domain.Entities
{
    public class Pedido : Entity
    {
        public Pedido(Cliente cliente, decimal desconto, decimal taxaDeEntrega)
        {
            Cliente = cliente;
            Data = DateTime.Now;
            Numero = Guid.NewGuid().ToString().Substring(0, 8);
            Itens = new List<ItemDoPedido>();
            Desconto = desconto;
            TaxaDeEntrega = taxaDeEntrega;
        }

        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public string Numero { get; set; }
        public IList<ItemDoPedido> Itens { get; set; }
        public decimal Desconto { get; set; }
        public decimal TaxaDeEntrega { get; set; }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var item = new ItemDoPedido(produto, quantidade);

            if(item.Valido())
                Itens.Add(item);
        }

        public bool PedidoValido()
        {
            if (Cliente == null)
                return false;

            return true;
        }   
    }
}