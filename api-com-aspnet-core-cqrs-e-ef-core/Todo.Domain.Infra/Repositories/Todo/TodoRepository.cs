using Todo.Domain.Entities;
using Todo.Domain.Repositories.Contracts;

namespace Todo.Domain.Infra.Repositories.Todo
{
    public class TodoRepository : ITodoRepository
    {
        public void AtualizarTitulo(string? title)
        {
            throw new NotImplementedException();
        }

        public void Gravar(TodoItem todo)
        {
            throw new NotImplementedException();
        }

        public TodoItem ObterItemPorId(Guid id, string? refUser)
        {
            throw new NotImplementedException();
        }

        public void SalvarAtualizacoes(object item)
        {
            throw new NotImplementedException();
        }
    }
}