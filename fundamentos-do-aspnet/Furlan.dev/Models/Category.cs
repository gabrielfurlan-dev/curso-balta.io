using System.ComponentModel.DataAnnotations;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;

namespace Furlan.dev.Models
{
    public class Category //: Notifiable<Notification>
    {
        private StringBuilder _notifications = new StringBuilder();
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }

        public IList<Post>? Posts { get; set; }

        // public bool EhValido()
        // {
        //     AddNotifications(new Contract<Notification>()
        //                 .Requires()
        //                 .IsEmpty(Name, "Name", "Nome da categoria deve estar preenchido.")
        //                 .IsEmpty(Slug, "Slug", "Slug deve estar preenchido.")
        //     );

        //     return IsValid;

        // }


        public bool EhValido()
        {
            if (String.IsNullOrEmpty(Name))
            {
                _notifications.AppendLine("Nome da categoria deve estar preenchido.");
                return false;
            }
            else if (String.IsNullOrEmpty(Slug))
            {
                _notifications.AppendLine("Slug deve estar preenchido.");
                return false;
            }
            
            return true;
        }

        internal string GetNotifications()
        {
            return _notifications.ToString();
        }
    }
}