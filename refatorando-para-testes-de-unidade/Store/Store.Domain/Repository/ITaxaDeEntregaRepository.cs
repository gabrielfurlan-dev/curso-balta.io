namespace Store.Domain.Repository
{
    public interface ITaxaDeEntregaRepository
    {
         public decimal Obter(string cep);
    }
}