using Store.Domain.Entities;

namespace Store.Domain.Repository
{
    public interface IDescontoRepository
    {
        public Desconto Obter(string codigo);
    }
}