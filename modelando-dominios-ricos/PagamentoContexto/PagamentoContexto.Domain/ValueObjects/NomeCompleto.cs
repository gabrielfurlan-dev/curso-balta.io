using Flunt.Notifications;
using Flunt.Validations;
using PagamentoContexto.Shared.ValueObjects;

namespace PagamentoContexto.Domain.ValueObjects
{
    public class NomeCompleto : ValueObject
    {
        public NomeCompleto(string primeiroNome, string segundoNome)
        {
            PrimeiroNome = primeiroNome;
            SegundoNome = segundoNome;

            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNullOrEmpty(primeiroNome, "NomeCompleto.PrimeiroNome")
            .IsNullOrEmpty(segundoNome, "NomeCompleto.SegundoNome"));
        }

        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
    }
}