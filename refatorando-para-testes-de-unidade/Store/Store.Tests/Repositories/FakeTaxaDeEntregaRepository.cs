using Store.Domain.Repositories;

namespace Store.Tests.Repositories
{
    public class FakeTaxaDeEntregaRepository : ITaxaDeEntregaRepository
    {
        public decimal Obter(string cep)
        => 10;
        
    }
}