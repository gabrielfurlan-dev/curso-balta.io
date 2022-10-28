using DependencyStore.Models;

namespace dominando_injecao_de_dependencia.Repositories.Contracts
{
    public interface IPromoCodeRepository
    {
        public Task<PromoCode?> GetPromoCodeById(string promoCode);
    }

}