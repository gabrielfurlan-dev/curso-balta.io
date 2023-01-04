using ToDo.Domain.Commands.Inputs.Contracts;

namespace ToDo.Domain.Commands.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
         ICommandResult Handle(T command);
    }
}