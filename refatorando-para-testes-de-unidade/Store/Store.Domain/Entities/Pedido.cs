namespace Store.Domain.Entities
{
    public class Pedido : Entity
    {
        public Pedido(Cliente cliente, decimal desconto, decimal taxaDeEntrega)
        {
            Numero = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EStatusPedido.NovoPedido;
            Cliente = cliente;
            Data = DateTime.Now;
            Itens = new List<ItemDoPedido>();
            Desconto = desconto;
            TaxaDeEntrega = taxaDeEntrega;
        }

        public string Numero { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public IList<ItemDoPedido> Itens { get; set; }
        public decimal Desconto { get; set; }
        public decimal TaxaDeEntrega { get; set; }
        public EStatusPedido Status { get; set; }
        public decimal ValorTotal { get; private set; }
        public decimal Troco { get; set; }

        private void AtualizarValorTotal() 
            => ValorTotal = (Itens.Sum(x => x.Preco * x.Quantidade) - Desconto) + TaxaDeEntrega;

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var item = new ItemDoPedido(produto, quantidade);

            if (item.Valido())
            {
                Itens.Add(item);
                AtualizarValorTotal();
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

            if(valorPagamento > ValorTotal)
                Troco = valorPagamento - ValorTotal;

            Status = EStatusPedido.PagamentoConcluido;

            return true;
        }
    
        public void CancelarPedido()
            => Status = EStatusPedido.PedidoCancelado;
    }
}