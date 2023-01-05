using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Infra.Contexts;
using ToDo.Domain.Queries;
using ToDo.Domain.Repositories.Contracts;

namespace ToDo.Domain.Infra.Repositories.ToDo
{
    public class ToDoRepository : IToDoRepository
    {
        private DataContext _dataContext;
        public ToDoRepository(DataContext dataContext)
            => _dataContext = dataContext;
        
        public void Gravar(ToDoItem todo)
        {
            _dataContext.Add(todo);
            _dataContext.SaveChanges();
        }
        
        public void Update(ToDoItem todo)
        {
            _dataContext.Entry(todo).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public IEnumerable<ToDoItem> GetAll(string refUser)
            =>_dataContext.Todos
              .Where(ToDoQueries.GetAll(refUser))
              .OrderBy(x => x.Date);

        public IEnumerable<ToDoItem> GetAllDone(string refUser)
        =>_dataContext.Todos
              .Where(ToDoQueries.GetAllDone(refUser))
              .OrderBy(x => x.Date);

        public IEnumerable<ToDoItem> GetAllUndone(string refUser)
        =>_dataContext.Todos
              .Where(ToDoQueries.GetAllUndone(refUser))
              .OrderBy(x => x.Date);

        public IEnumerable<ToDoItem> GetByPeriod(string refUser, bool done, DateTime date)
        =>_dataContext.Todos
              .Where(ToDoQueries.GetByPeriod(refUser, done, date))
              .OrderBy(x => x.Date);


        public ToDoItem GetToDoById(Guid id, string refUser)
            =>_dataContext.Todos .FirstOrDefault(ToDoQueries.GetById(id, refUser));

    }
}