using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Repositories.Contracts;

namespace Todo.Domain.Commands.Handlers
{
    public class MarkTodoAsUndoneHandler : IHandler<MarkToDoAsDoneCommand>
    {
        private ITodoRepository _repository;
        public MarkTodoAsUndoneHandler(ITodoRepository repository)
            => _repository = repository;

        public ICommandResult Handle(MarkToDoAsDoneCommand command)
        {
            try
            {
                if (!command.Validate())
                    throw new Exception();

                var todo = _repository.ObterItemPorId(command.Id, command.RefUser);

                todo.MarkAsDone();

                _repository.SalvarAtualizacoes(todo);

                return new GenericCommandResult(true, "Tarefa concluída com sucesso.", null);
            }
            catch (System.Exception)
            {
                return new GenericCommandResult(false, "Não foi possível concluir a tarefa.", null);
            }
        }
    }
}