using Store.Domain.Entities;

namespace Store.Domain.Repository
{
    public interface IClienteRepository
    {
        //  public IList<Produto> ObterTodosOsProdutos();

         public Cliente ObterCliente(string documento);
    }
}