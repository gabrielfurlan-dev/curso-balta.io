using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Entities
{
    public class PayPalPagamento : Pagamento
    {
        public string CodigoDeTransacao { get; private set; }

        public PayPalPagamento(string codigoDeTransacao,
                               DateTime dataDePagamento,
                               DateTime dataDeExpiracao,
                               decimal total,
                               decimal totalPago,
                               string emitente,
                               Documento documento,
                               Endereco endereco,
                               Email email) :base(dataDePagamento,
                                                   dataDeExpiracao,
                                                   total,
                                                   totalPago,
                                                   emitente,
                                                   documento,
                                                   endereco,
                                                   email)
        {
            CodigoDeTransacao = codigoDeTransacao;
        }
    }
}