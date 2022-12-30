using Todo.Domain.Entities;

namespace Todo.Domain.Repositories.Contracts
{
    public interface ITodoRepository
    {
        TodoItem ObterItemPorId(Guid id, string? refUser);
        void Gravar(TodoItem todo);
        void AtualizarTitulo(string? title);
        void SalvarAtualizacoes(object item);
    }
}