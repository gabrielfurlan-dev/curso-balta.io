using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Inputs.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkToDoAsUndoneCommand : Notifiable<Notification>, ICommand
    {
        public MarkToDoAsUndoneCommand(){ }
        
        public MarkToDoAsUndoneCommand(Guid id, string refUser)
        {
            Id = id;
            RefUser = refUser;
        }

        public Guid? Id { get; set; }
        public string RefUser { get; set; }

        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsLowerThan(RefUser.Length, 6, "User", "Usuário invlálido")
                );

            return IsValid;
        }
    }
}