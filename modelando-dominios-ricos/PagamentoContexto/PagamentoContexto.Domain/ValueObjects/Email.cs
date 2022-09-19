using Flunt.Notifications;
using Flunt.Validations;
using PagamentoContexto.Shared.ValueObjects;

namespace PagamentoContexto.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string email)
        {
             EmailValido = email;

             AddNotifications(new Contract<Notification>()
             .Requires()
             .IsEmail(email,"Email.EmailValido", "E-mail inválido."));
        }
        
        public string EmailValido { get; private set; }
    }
}