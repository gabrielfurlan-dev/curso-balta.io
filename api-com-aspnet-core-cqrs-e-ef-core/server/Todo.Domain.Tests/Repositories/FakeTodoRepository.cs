using ToDo.Domain.Entities;
using ToDo.Domain.Repositories.Contracts;

namespace ToDo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : IToDoRepository
    {
        public IEnumerable<ToDoItem> GetAll(string refUser) { throw new NotImplementedException(); }

        public IEnumerable<ToDoItem> GetAllDone(string refUser) { throw new NotImplementedException(); }

        public IEnumerable<ToDoItem> GetAllUndone(string refUser) { throw new NotImplementedException(); }

        public IEnumerable<ToDoItem> GetByPeriod(string refUser, bool done, DateTime date) { throw new NotImplementedException(); }

        public void Gravar(ToDoItem todo) { }

        public ToDoItem GetToDoById(Guid id, string? refUser)
            => new ToDoItem("Nome Tarefa",DateTime.Now, "Referência de usuário");

        public void Update(ToDoItem item) { }
    }
}