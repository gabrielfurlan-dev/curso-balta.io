using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ToDoController : ControllerBase
    {
        //POST
        [HttpPost]
        [Route("")]
        public GenericCommandResult Create(
            [FromBody] CreateToDoCommand command,
            [FromServices] CreateToDoHandler handler)
        {
            command.RefUser = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

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
        {
            command.RefUser = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("mark-as-undone")]
        public GenericCommandResult MarkAsUndone(
                    [FromBody] MarkToDoAsUndoneCommand command,
                    [FromServices] MarkTodoAsUndoneHandler handler
        )
        {
            command.RefUser = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        //GET
        [HttpGet]
        [Route("")]
        public IEnumerable<ToDoItem> GetAll([FromServices] IToDoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAll(user);
        }

        [HttpGet]
        [Route("done")]
        public IEnumerable<ToDoItem> GetAllDone([FromServices] IToDoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAllDone(user);
        }

        [HttpGet]
        [Route("undone")]
        public IEnumerable<ToDoItem> GetAllUndone([FromServices] IToDoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAllUndone(user);
        }

        [HttpGet]
        [Route("done/today")]
        public IEnumerable<ToDoItem> GetAllDoneForToday([FromServices] IToDoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, done: true, date: DateTime.Now);
        }

        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<ToDoItem> GetAllUndoneForToday([FromServices] IToDoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, done: false, date: DateTime.Now);
        }

        [HttpGet]
        [Route("done/tomorrow")]
        public IEnumerable<ToDoItem> GetAllDoneForTomorrow([FromServices] IToDoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, done: true, date: DateTime.Now.AddDays(1));
        }

        [HttpGet]
        [Route("undone/tomorrow")]
        public IEnumerable<ToDoItem> GetAllUndoneForTomorrow([FromServices] IToDoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, done: false, date: DateTime.Now.AddDays(1));
        }
    }
}