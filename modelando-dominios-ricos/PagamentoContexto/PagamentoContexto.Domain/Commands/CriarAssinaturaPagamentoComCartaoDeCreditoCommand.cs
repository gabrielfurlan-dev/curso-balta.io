using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Commands
{
    public class CriarAssinaturaPagamentoComCartaoDeCreditoCommand
    {
        //Nome
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }

        //Documento
        public string NumeroDocumento { get; set; }

        //Email
        public string Email { get; set; }

        //Cartao de Credito
        public string NomeProprietarioCartao { get; private set; }
        public string NumeroCartao { get; private set; }
        public string NumeroDaUltimaTransacao { get; private set; }

        //Pagamento
        public string NumeroPagamento { get; set; }
        public DateTime DataDePagamento { get; set; }
        public DateTime DataDeExpiracao { get; set; }
        public DateTime Total { get; set; }
        public DateTime TotalPago { get; set; }
        public string Emitente { get; set; }
        public string DocumentoPagamento { get; set; }
        public TipoDocumento TipoDocumentoPagamento { get; set; }
        public Endereco EnderecoPagamento { get; set; }
        public Email EmailPagamento { get; set; }

        //Endereco
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
    }
}