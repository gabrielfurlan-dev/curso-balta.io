using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IClienteRepository
    {
        //  public IList<Produto> ObterTodosOsProdutos();

         public Cliente ObterCliente(string documento);
    }
}