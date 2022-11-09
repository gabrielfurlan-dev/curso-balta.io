using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IDescontoRepository
    {
        public Desconto Obter(string codigo);
    }
}