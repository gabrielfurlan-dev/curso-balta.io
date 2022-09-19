using Flunt.Notifications;
using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Entities
{
    public abstract class Pagamento : Notifiable<Notification>
    {
        protected Pagamento(DateTime dataDePagamento,
                            DateTime dataDeExpiracao,
                            decimal total,
                            decimal totalPago,
                            string emitente,
                            Documento documento,
                            Endereco endereco,
                            Email email)
        {
            NumeroPagamento = new Guid().ToString().Replace("-","").Substring(0, 10).ToUpper();
            DataDePagamento = dataDePagamento;
            DataDeExpiracao = dataDeExpiracao;
            Total = total;
            TotalPago = totalPago;
            Emitente = emitente;
            Documento = documento;
            Endereco = endereco;
            Email = email;
        }

        public string NumeroPagamento { get; private set; }
        public DateTime DataDePagamento { get; private set; }
        public DateTime DataDeExpiracao { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPago { get; private set; }
        public string Emitente { get; private set; }
        public Documento Documento { get; private set; }
        public Endereco Endereco { get; private set; }
        public Email Email { get; private set; }
    }
}