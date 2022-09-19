using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Entities
{
    public class CartaoDeCreditoPagamento : Pagamento
    {
        public CartaoDeCreditoPagamento(string nomeProprietarioCartao,
                                        string numeroCartao,
                                        string numeroDaUltimaTransacao,
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
            NomeProprietarioCartao = nomeProprietarioCartao;
            NumeroCartao = numeroCartao;
            NumeroDaUltimaTransacao = numeroDaUltimaTransacao;
        }

        public string NomeProprietarioCartao { get; private set; }
        public string NumeroCartao { get; private set; }
        public string NumeroDaUltimaTransacao { get; private set; }
    }
}