using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Commands.Handlers;
using ToDo.Domain.Commands.Inputs;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories.Contracts;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class ToDoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public GenericCommandResult Create(
            [FromBody] CreateToDoCommand command,
            [FromServices] ToDoHandler handler)
        {
            command.RefUser = "gabriefurlan";

            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<ToDoItem> GetAll([FromServices] IToDoRepository repository)
            => repository.GetAll(refUser: "gabriefurlan");

        [HttpGet]
        [Route("done")]
        public IEnumerable<ToDoItem> GetAllDone([FromServices] IToDoRepository repository)
            => repository.GetAllDone(refUser: "gabriefurlan");

        [HttpGet]
        [Route("undone")]
        public IEnumerable<ToDoItem> GetAllUndone([FromServices] IToDoRepository repository)
            => repository.GetAllUndone(refUser: "gabriefurlan");

        [HttpGet]
        [Route("today")]
        public IEnumerable<ToDoItem> GetByPeriod([FromServices] IToDoRepository repository)
            => repository.GetByPeriod(refUser: "gabriefurlan", done:false, date: DateTime.Now);
    }
}