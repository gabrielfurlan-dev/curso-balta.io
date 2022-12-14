using ToDo.Domain.Commands.Handlers.Contracts;
using ToDo.Domain.Commands.Inputs;
using ToDo.Domain.Commands.Inputs.Contracts;
using ToDo.Domain.Repositories.Contracts;

namespace ToDo.Domain.Commands.Handlers
{
    public class MarkTodoAsUndoneHandler : IHandler<MarkToDoAsUndoneCommand>
    {
        private IToDoRepository _repository;
        public MarkTodoAsUndoneHandler(IToDoRepository repository)
            => _repository = repository;

        public ICommandResult Handle(MarkToDoAsUndoneCommand command)
        {
            try
            {
                if (!command.Validate())
                    throw new Exception();

                var todo = _repository.GetToDoById(command.Id, command.RefUser);

                todo.UnmarkAsDone();

                _repository.Update(todo);

                return new GenericCommandResult(true, "Tarefa desmarcada com sucesso.", null);
            }
            catch (System.Exception)
            {
                return new GenericCommandResult(false, "Não foi possível desmarcar a tarefa.", null);
            }
        }
    }
}