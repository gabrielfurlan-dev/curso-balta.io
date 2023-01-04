using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Queries
{
    public static class ToDoQueries
    {
        public static Expression<Func<ToDoItem, bool>> GetAll(string refUser)
            => x => x.RefUser == refUser;

        public static Expression<Func<ToDoItem, bool>> GetAllDone(string refUser)
            => x => x.RefUser == refUser && x.Done;

        public static Expression<Func<ToDoItem, bool>> GetAllUndone(string refUser)
            => x => x.RefUser == refUser && !x.Done;

        public static Expression<Func<ToDoItem, bool>> GetByPeriod(string refUser, bool done, DateTime date)
            => x =>
             x.RefUser == refUser &&
             x.Done == done &&
             x.Date.Date == date.Date;

        public static Expression<Func<ToDoItem, bool>> GetById(Guid id, string refUser)
            => x => x.Id == id && x.RefUser == refUser;
    }
}