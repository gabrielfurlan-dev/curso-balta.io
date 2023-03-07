using Flunt.Notifications;
using Flunt.Validations;

namespace Furlan.dev.Models
{
    public class Category : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }

        public IList<Post>? Posts { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract<Notification>()
                        .Requires()
                        .IsEmpty(Name, "Name", "Nome da categoria deve estar.")
                        .IsEmpty(Slug, "Slug", "Slug deve estar preenchido.")
            );

            return IsValid;

        }
    }
}