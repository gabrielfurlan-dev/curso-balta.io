using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Inputs.Contracts;

namespace ToDo.Domain.Commands
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