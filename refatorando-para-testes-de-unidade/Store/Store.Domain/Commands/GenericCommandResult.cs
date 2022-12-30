using Store.Domain.Commands.Contracts;

namespace Store.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public void ICommandResult(bool success, string message, Object data )
        {
            Success = success;
            Message = message;
            Data = data;
        }
         public bool Success { get; set; }
         public string Message { get; set; }
         public Object Data { get; set; }
    }
}