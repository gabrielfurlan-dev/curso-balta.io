using Flunt.Notifications;

namespace PagamentoContexto.Shared.Entity;
public class Entity : Notifiable<Notification>

{
 public Guid Id { get; set; }

    public Entity(Guid id)
    {
        Id = id;
    }
}
