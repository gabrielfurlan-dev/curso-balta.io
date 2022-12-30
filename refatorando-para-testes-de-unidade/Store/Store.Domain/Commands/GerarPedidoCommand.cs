using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Contracts;

namespace Store.Domain.Commands
{
    public class GerarPedidoCommand : Notifiable<Notification>, ICommandResult
    {

        public GerarPedidoCommand()
            => Itens = new List<CriarItemPedidoCommand>();

        public GerarPedidoCommand(string customer, string zipCode, string promoCode, List<CriarItemPedidoCommand> itens)
        {
            Customer = customer;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Itens = itens;
        }

        public string? Customer { get; set; }
        public string? ZipCode { get; set; }
        public string? PromoCode { get; set; }
        public List<CriarItemPedidoCommand> Itens {get; set;}

        public bool EhValido()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(ZipCode, 8, "ZipCode", "CEP inválido.")
            .IsGreaterThan(Customer, 11, "Customer", "Cliente inválido.")
            );

            return this.IsValid;
        }
    }
}