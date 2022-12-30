using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Repositories.Contracts;

namespace Todo.Domain.Commands.Handlers
{
    public class UpdateTodoHandler : IHandler<UpdateTodoCommand>
    {
        private ITodoRepository _repository;

        public UpdateTodoHandler(ITodoRepository repository)
        => _repository = repository;

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            try
            {
                if (!command.Validate())
                    throw new Exception();

                var item = _repository.ObterItemPorId(command.Id, command.RefUser);

                _repository.AtualizarTitulo(command.Title);

                _repository.SalvarAtualizacoes(item);

                return new GenericCommandResult(true, "Tarefa atualizada com sucesso.", item);
            }
            catch (System.Exception)
            {
                return new GenericCommandResult(false, "Não foi possível atualizar os dados da tarefa.", null);
            }
        }
    }
}