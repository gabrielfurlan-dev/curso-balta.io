using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using PagamentoContexto.Domain.ValueObjects;
using PagamentoContexto.Shared.Commands;

namespace PagamentoContexto.Domain.Commands
{
    public class CriarAssinaturaPagamentoComBoletoCommand : Notifiable<Notification>, ICommand
    {

        //Nome
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }

        //Documento
        public string NumeroDocumento { get; set; }

        //Email
        public string Email { get; set; }

        //Boleto
        public string CodigoDeTransacao { get; set; }
        public string NumeroBoleto { get; set; }

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

        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterOrEqualsThan(PrimeiroNome.Length, 3, "CriarAssinaturaPagamentoComBoletoCommand.PrimeiroNome"));
        }
    }
}