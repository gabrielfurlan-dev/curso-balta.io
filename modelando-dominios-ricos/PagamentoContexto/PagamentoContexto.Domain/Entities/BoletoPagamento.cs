using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Entities
{
    public class BoletoPagamento : Pagamento
    {
        public BoletoPagamento(string codigoBarras,
                               string numeroBoleto,
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
            CodigoBarras = codigoBarras;
            NumeroBoleto = numeroBoleto;
        }

        public string CodigoBarras { get; private set; }
        public string NumeroBoleto { get; private set; }
    }
}