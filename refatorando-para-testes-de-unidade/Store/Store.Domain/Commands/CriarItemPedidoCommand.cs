using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Commands
{
    public class CriarItemPedidoCommand : Notifiable<Notification>, ICommand
    {
        public CriarItemPedidoCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product { get; set; }
        public int Quantity { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(Product.ToString(), 32, "Product", "Produto inválido")
            .IsGreaterThan(Quantity, 0, "Quantity", "Quantidade Inválida")
            );
        }
    }
}