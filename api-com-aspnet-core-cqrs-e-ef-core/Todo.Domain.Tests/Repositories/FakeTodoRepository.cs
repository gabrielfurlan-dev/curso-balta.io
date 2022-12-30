using Todo.Domain.Entities;
using Todo.Domain.Repositories.Contracts;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void AtualizarTitulo(string? title) { }

        public void Gravar(TodoItem todo) { }

        public TodoItem ObterItemPorId(Guid id, string? refUser)
            => new TodoItem("Nome Tarefa",DateTime.Now, "Referência de usuário");

        public void SalvarAtualizacoes(object item) { }
    }
}