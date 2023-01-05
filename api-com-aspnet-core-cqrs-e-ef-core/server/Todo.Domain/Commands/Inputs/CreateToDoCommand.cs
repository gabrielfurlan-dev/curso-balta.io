using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Inputs.Contracts;

namespace ToDo.Domain.Commands.Inputs
{
    public class CreateToDoCommand : Notifiable<Notification>, ICommand
    {
        public CreateToDoCommand() { }

        public CreateToDoCommand(string title, DateTime date, string refUser)
        {
            Title = title;
            Date = date;
            RefUser = refUser;
        }

        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string? RefUser { get; set; }

        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Title, 4, "Title", "Por favor, descreva melhor esta tarefa.")
                .IsGreaterThan(RefUser, 6, "User", "Usuário inválido.")
            );

            return IsValid;
        }
    }
}