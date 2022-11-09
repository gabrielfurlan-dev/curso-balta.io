using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IProdutoRepository
    {
         IEnumerable<Produto> Obter(IEnumerable<Guid> ids);
    }
}