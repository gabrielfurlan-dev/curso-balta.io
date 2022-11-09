namespace Store.Domain.Repositories
{
    public interface ITaxaDeEntregaRepository
    {
         public decimal Obter(string cep);
    }
}