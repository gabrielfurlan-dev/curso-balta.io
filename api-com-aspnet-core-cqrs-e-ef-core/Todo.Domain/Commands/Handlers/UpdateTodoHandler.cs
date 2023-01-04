using ToDo.Domain.Commands.Handlers.Contracts;
using ToDo.Domain.Commands.Inputs;
using ToDo.Domain.Commands.Inputs.Contracts;
using ToDo.Domain.Repositories.Contracts;

namespace ToDo.Domain.Commands.Handlers
{
    public class UpdateTodoHandler : IHandler<UpdateTodoCommand>
    {
        private IToDoRepository _repository;

        public UpdateTodoHandler(IToDoRepository repository)
        => _repository = repository;

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            try
            {
                if (!command.Validate())
                    throw new Exception();

                var item = _repository.GetToDoById(command.Id, command.RefUser);

                item.UpdateTitle(command.Title);

                _repository.Update(item);

                return new GenericCommandResult(true, "Tarefa atualizada com sucesso.", item);
            }
            catch (System.Exception)
            {
                return new GenericCommandResult(false, "Não foi possível atualizar os dados da tarefa.", null);
            }
        }
    }
}