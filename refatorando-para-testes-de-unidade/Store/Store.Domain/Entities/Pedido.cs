namespace Store.Domain.Entities
{
    public class Pedido : Entity
    {
        public Pedido(Cliente cliente, Desconto desconto, decimal taxaDeEntrega)
        {
            Numero = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EStatusPedido.NovoPedido;
            Cliente = cliente;
            Data = DateTime.Now;
            Itens = new List<ItemDoPedido>();
            Desconto = desconto;
            TaxaDeEntrega = taxaDeEntrega;
        }

        public Pedido(string numero, Cliente cliente, DateTime data, Desconto desconto, decimal taxaDeEntrega, EStatusPedido status, decimal troco) 
        {
            this.Numero = numero;
                this.Cliente = cliente;
                this.Data = data;
                this.Desconto = desconto;
                this.TaxaDeEntrega = taxaDeEntrega;
                this.Status = status;
                this.Troco = troco;
               
        }
                public string Numero { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public IList<ItemDoPedido> Itens { get; set; }
        public Desconto Desconto { get; set; }
        public decimal TaxaDeEntrega { get; set; }
        public EStatusPedido Status { get; set; }
        public decimal ValorTotal
        {
            get
            {
                return (Itens.Sum(x => x.Preco * x.Quantidade) - Desconto.Valor()) + TaxaDeEntrega;
            }
            private set{}
        }
        public decimal Troco { get; set; }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var item = new ItemDoPedido(produto, quantidade);

            if (item.Valido())
            {
                Itens.Add(item);
            }

            Status = EStatusPedido.AguardandoPagamento;
        }

        public bool PedidoValido()
        {
            if (Cliente == null)
                return false;

            return true;
        }

        public bool ConcluirPagamento(decimal valorPagamento)
        {
            if (valorPagamento < ValorTotal)
                return false;

            if (valorPagamento > ValorTotal)
                Troco = valorPagamento - ValorTotal + Desconto.Valor();

            Status = EStatusPedido.PagamentoConcluido;

            return true;
        }

        public void CancelarPedido()
            => Status = EStatusPedido.PedidoCancelado;
    }
}