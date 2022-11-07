using dominando_injecao_de_dependencia.Repositories;
using dominando_injecao_de_dependencia.Repositories.Contracts;
using dominando_injecao_de_dependencia.Services;
using dominando_injecao_de_dependencia.Services.Contracts;
using Microsoft.Data.SqlClient;

namespace dominando_injecao_de_dependencia.Extensions
{
    public static class DependenciesExtensions
    {
        public static void AddSqlConnection(this IServiceCollection service, string connectionString)
        => new SqlConnection(connectionString);

        public static void AddRepository(this IServiceCollection service)
        {
            service.AddTransient<ICustomerRepository, CustomerRepository>();
            service.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
        }

        public static void AddService(this IServiceCollection service)
        {
            service.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
        }
    }
}