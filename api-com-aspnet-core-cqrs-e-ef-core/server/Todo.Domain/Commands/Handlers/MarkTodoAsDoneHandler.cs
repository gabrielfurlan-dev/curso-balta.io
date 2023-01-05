using System.Net.Http.Headers;
using ToDo.Domain.Commands.Handlers.Contracts;
using ToDo.Domain.Commands.Inputs;
using ToDo.Domain.Commands.Inputs.Contracts;
using ToDo.Domain.Repositories.Contracts;

namespace ToDo.Domain.Commands.Handlers
{
    public class MarkTodoAsDoneHandler : IHandler<MarkToDoAsDoneCommand>
    {
        private IToDoRepository _repository;
        public MarkTodoAsDoneHandler(IToDoRepository repository)
            => _repository = repository;

        public ICommandResult Handle(MarkToDoAsDoneCommand command)
        {
            try
            {
                if (!command.Validate())
                    throw new Exception();

                var todo = _repository.GetToDoById(command.Id, command.RefUser);

                todo.MarkAsDone();

                _repository.Update(todo);

                return new GenericCommandResult(true, "Tarefa concluída com sucesso.", null);
            }
            catch (System.Exception)
            {
                return new GenericCommandResult(false, "Não foi possível concluir a tarefa.", null);
            }
        }
    }
}