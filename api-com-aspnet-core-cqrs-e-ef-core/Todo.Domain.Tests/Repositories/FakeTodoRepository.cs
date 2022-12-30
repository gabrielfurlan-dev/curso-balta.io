using Todo.Domain.Entities;
using Todo.Domain.Repositories.Contracts;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Gravar(TodoItem todo) { }
    }
}