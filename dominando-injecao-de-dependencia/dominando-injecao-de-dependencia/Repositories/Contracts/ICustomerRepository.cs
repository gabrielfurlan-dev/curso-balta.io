using DependencyStore.Models;

namespace dominando_injecao_de_dependencia.Repositories.Contracts
{
    public interface ICustomerRepository
    {
         public Task<Customer?> GetByIdAsync(string costumerId);
    }
}