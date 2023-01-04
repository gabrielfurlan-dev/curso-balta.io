using Flunt.Notifications;
using ToDo.Domain.Commands.Handlers.Contracts;
using ToDo.Domain.Commands.Inputs;
using ToDo.Domain.Commands.Inputs.Contracts;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories.Contracts;

namespace ToDo.Domain.Commands.Handlers
{
    public class CreateToDoHandler :
    Notifiable<Notification>,
    IHandler<CreateToDoCommand>

    {
        public CreateToDoHandler(IToDoRepository repository)
            => _repository = repository;

        private readonly IToDoRepository _repository;

        public ICommandResult Handle(CreateToDoCommand command)
        {
            try
            {
                if (!command.Validate())
                    throw new Exception();

                var todo = new ToDoItem(command.Title, command.Date, command.RefUser);

                _repository.Gravar(todo);

                return new GenericCommandResult(true, "Tarefa criada com sucesso!", command);
            }
            catch (System.Exception)
            {
                return new GenericCommandResult(false, "Command não é valido", command.Notifications);
            }


        }
    }

}