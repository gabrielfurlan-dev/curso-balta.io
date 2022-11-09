using Store.Domain.Enuns;

namespace Store.Domain.Entities
{
    public class Desconto : Entity
    {
        public Desconto(decimal total, DateTime dataDeExpiracao)
        {
            ValorDesconto = total;
            DataDeExpiracao = dataDeExpiracao;
        }

        private decimal ValorDesconto { get; set; }
        private DateTime DataDeExpiracao { get; set; }

        public bool Valido()
        => DateTime.Now <  DataDeExpiracao;

        public decimal Valor()
        {
            if (Valido())
                return ValorDesconto;
            else
                return 0;
        }
    }
}