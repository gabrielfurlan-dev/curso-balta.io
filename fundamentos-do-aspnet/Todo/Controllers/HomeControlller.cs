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
            => context.Todos.ToList();

        [HttpGet("/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context
            )
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model is null) return NotFound();

            return Ok(model);
        }

        [HttpPost("/")]
        public IActionResult Set(
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context
            )
        {
            context.Todos.Add(todo);
            context.SaveChanges();

            return Created($"/{todo.Id}", todo);
        }

        [HttpPut("/")]
        public IActionResult Put(
            [FromRoute] TodoModel todo,
            [FromServices] AppDbContext context
        )
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == todo.Id);
            if (model is null) return NotFound();

            model.Title = todo.Title;
            model.CreateAt = todo.CreateAt;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();

            return Ok(model);
        }

        [HttpGet("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context
            )
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if(model is null) return NotFound();

            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}