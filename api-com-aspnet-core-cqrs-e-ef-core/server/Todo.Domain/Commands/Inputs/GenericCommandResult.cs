using ToDo.Domain.Commands.Inputs.Contracts;

namespace ToDo.Domain.Commands.Inputs
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult() { }
        
        public GenericCommandResult(bool sucesso, string message, object data)
        {
            Sucesso = sucesso;
            Message = message;
            Data = data;
        }

        public bool? Sucesso { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}