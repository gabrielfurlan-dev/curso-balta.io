using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories.Contracts
{
    public interface IToDoRepository
    {
        
        void Gravar(ToDoItem todo);
        ToDoItem GetToDoById(Guid id, string? refUser);
        void Update(ToDoItem item);

        IEnumerable<ToDoItem> GetAll(string refUser);
        IEnumerable<ToDoItem> GetAllDone(string refUser);
        IEnumerable<ToDoItem> GetAllUndone(string refUser);
        IEnumerable<ToDoItem> GetByPeriod(string refUser, bool done, DateTime date);
    }
}