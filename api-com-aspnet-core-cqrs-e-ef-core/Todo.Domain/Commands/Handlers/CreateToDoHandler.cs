using Flunt.Notifications;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories.Contracts;

namespace Todo.Domain.Commands.Handlers
{
    public class ToDoHandler :
    Notifiable<Notification>,
    IHandler<CreateToDoCommand>

    {
        public ToDoHandler(ITodoRepository repository)
            => _repository = repository;

        private readonly ITodoRepository _repository;

        public ICommandResult Handle(CreateToDoCommand command)
        {
            try
            {
                if (!command.Validate())
                    throw new Exception();

                var todo = new TodoItem(command.Title, command.Date, command.RefUser);

                return new GenericCommandResult(true, "", command);
            }
            catch (System.Exception)
            {
                return new GenericCommandResult(false, "Command não é valido", command.Notifications);
            }


        }
    }

}