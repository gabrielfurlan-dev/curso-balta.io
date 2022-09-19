using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Commands
{
    public class CriarAssinaturaPayPalCommand
    {
        //Nome
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }

        //Documento
        public string NumeroDocumento { get; set; }
        
        //Email
        public string Email { get; set; }

        //PayPal
        public string CodigoDeTransacao { get; set; }

        //Pagamento
        public string NumeroPagamento { get; set; }
        public DateTime DataDePagamento { get; set; }
        public DateTime DataDeExpiracao { get; set; }
        public DateTime Total { get; set; }
        public DateTime TotalPago { get; set; }
        public string Emitente { get; set; }
        public Documento DocumentoEmitente { get; set; }
        public string EnderecoEmitente { get; set; }
        public Email EmailEmitente { get; set; }

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