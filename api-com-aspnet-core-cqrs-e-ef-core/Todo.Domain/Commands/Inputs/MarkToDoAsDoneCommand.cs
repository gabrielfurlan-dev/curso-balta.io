using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Inputs.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkToDoAsDoneCommand : Notifiable<Notification>, ICommand
    {
        public MarkToDoAsDoneCommand(){ }
        
        public MarkToDoAsDoneCommand(Guid id, string? refUser)
        {
            Id = id;
            RefUser = refUser;
        }

        public Guid Id { get; set; }
        public string? RefUser { get; set; }

        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsLowerThan(RefUser.Length, 6, "User", "Usuário invlálido.")
                );

            return IsValid;
        }
    }
}