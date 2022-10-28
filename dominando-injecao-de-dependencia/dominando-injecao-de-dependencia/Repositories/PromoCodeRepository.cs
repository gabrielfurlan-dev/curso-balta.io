using Dapper;
using DependencyStore.Models;
using dominando_injecao_de_dependencia.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace dominando_injecao_de_dependencia.Repositories
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        SqlConnection _conexao;

        public PromoCodeRepository(SqlConnection conexao)
            => _conexao = conexao;

        public async Task<PromoCode?> GetPromoCodeById(string promoCode)
        {
            string query = $"SELECT * FROM PROMO_CODES WHERE CODE={promoCode}";
            return await _conexao.QueryFirstAsync<PromoCode>(query);
        }
    }
}