using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Commands;
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
        //POST
        [HttpPost]
        [Route("")]
        public GenericCommandResult Create(
            [FromBody] CreateToDoCommand command,
            [FromServices] CreateToDoHandler handler)
        {
            command.RefUser = "gabriefurlan";

            return (GenericCommandResult)handler.Handle(command);
        }

        //PUT
        [HttpPut]
        [Route("")]
        public GenericCommandResult Update(
            [FromBody] UpdateTodoCommand command,
            [FromServices] UpdateTodoHandler handler
        )
        {
            command.Title = "Titulo alterado";

            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("mark-as-done")]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkToDoAsDoneCommand command,
            [FromServices] MarkTodoAsDoneHandler handler
        )
            => (GenericCommandResult)handler.Handle(command);

        [HttpPut]
        [Route("mark-as-undone")]
        public GenericCommandResult MarkAsUndone(
                    [FromBody] MarkToDoAsUndoneCommand command,
                    [FromServices] MarkTodoAsUndoneHandler handler
        )
                    => (GenericCommandResult)handler.Handle(command);

        //GET
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
        [Route("done/today")]
        public IEnumerable<ToDoItem> GetAllDoneForToday([FromServices] IToDoRepository repository)
            => repository.GetByPeriod(refUser: "gabriefurlan", done: true, date: DateTime.Now);

        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<ToDoItem> GetAllUndoneForToday([FromServices] IToDoRepository repository)
            => repository.GetByPeriod(refUser: "gabriefurlan", done: false, date: DateTime.Now);

        [HttpGet]
        [Route("done/tomorrow")]
        public IEnumerable<ToDoItem> GetAllDoneForTomorrow([FromServices] IToDoRepository repository)
        => repository.GetByPeriod(refUser: "gabriefurlan", done: true, date: DateTime.Now.AddDays(1));

        [HttpGet]
        [Route("undone/tomorrow")]
        public IEnumerable<ToDoItem> GetAllUndoneForTomorrow([FromServices] IToDoRepository repository)
            => repository.GetByPeriod(refUser: "gabriefurlan", done: false, date: DateTime.Now.AddDays(1));
    }
}