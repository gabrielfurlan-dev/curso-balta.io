using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeControlller : ControllerBase
    {
        [HttpGet("/")]
        public IEnumerable<TodoModel> Get([FromServices] AppDbContext context)
            =>  context.Todos.ToList();

        [HttpGet("/{id:int}")]
        public TodoModel GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context
            )
            =>  context.Todos.FirstOrDefault(x => x.Id == id);

        [HttpPost("/")]
        public TodoModel Set(
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context
            )
        {
            context.Todos.Add(todo);
            context.SaveChanges();

            return todo;
        }

        [HttpPut("/")]
        public TodoModel Put(
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context 
        )
        {
            var model  =context.Todos.FirstOrDefault(x => x.Id == todo.Id);
            if (model is null) return todo;

            model.Title = todo.Title;
            model.CreateAt = todo.CreateAt;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();

            return model;
        }
    }
}