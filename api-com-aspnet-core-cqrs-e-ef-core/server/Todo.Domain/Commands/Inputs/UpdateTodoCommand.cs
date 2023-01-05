using Flunt.Notifications;
using Flunt.Validations;
using ToDo.Domain.Commands.Inputs.Contracts;

namespace ToDo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable<Notification>, ICommand
    {
        public UpdateTodoCommand() {  }
        public UpdateTodoCommand(Guid id, string title, string refUser)
        {
            Id = id;
            Title = title;
            RefUser = refUser;
        }

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? RefUser { get; set; }
        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsLowerThan(RefUser.Length, 6, "User", "Usuário inválido.")
                .IsLowerThan(Title.Length, 4, "User", "Descreva melhor sua tarefa.")
            );

            return IsValid;
        }
    }

    public class Kata
{
  public static bool Solution(string str, string ending)
  => str.Substring(str.Length - ending.Length, str.Length).Equals(ending);
}
}