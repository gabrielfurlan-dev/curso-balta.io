using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IPedidoRepository
    {   
        public void Salvar(Pedido pedido);
    }
}