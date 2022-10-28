using Store.Domain.Enuns;

namespace Store.Domain.Entities
{
    public class Desconto : Entity
    {
        public Desconto(decimal total, DateTime dataDeExpiracao)
        {
            Total = total;
            DataDeExpiracao = dataDeExpiracao;
        }

        public decimal Total { get; private set; }
        public DateTime DataDeExpiracao { get; private set; }
        public EStatusdoPedido Status { get; set; }

        public bool Valido()
        => DateTime.Compare(DateTime.Now, DataDeExpiracao) < 0;

        public decimal Valor()
        {
            if (Valido())
                return Total;
            else
                return 0;
        }
        public void Cancel()
        {
            Status = EStatusdoPedido.Cancelado;           
        }
    }

}