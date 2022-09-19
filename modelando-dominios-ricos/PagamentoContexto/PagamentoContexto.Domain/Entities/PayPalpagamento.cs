using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Entities
{
    public class PaypalPagamento : Pagamento
    {
        public string CodigoDeTransacao { get; private set; }

        public PaypalPagamento(string codigoDeTransacao,
                               DateTime dataDePagamento,
                               DateTime dataDeExpiracao,
                               DateTime total,
                               DateTime totalPago,
                               string emitente,
                               Documento documento,
                               string endereco,
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