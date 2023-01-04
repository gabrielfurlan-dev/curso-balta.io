using Todo.Domain.Entities;

namespace Todo.Domain.Repositories.Contracts
{
    public interface ITodoRepository
    {
        TodoItem ObterItemPorId(Guid id, string? refUser);
        void Gravar(TodoItem todo);
        void AtualizarTitulo(string? title);
        void SalvarAtualizacoes(object item);

        IEnumerable<TodoItem> GetAll(string refUser);
        IEnumerable<TodoItem> GetAllDone(string refUser);
        IEnumerable<TodoItem> GetAllUndone(string refUser);
        IEnumerable<TodoItem> GetByPeriod(string refUser, bool done, DateTime date);
    }
}