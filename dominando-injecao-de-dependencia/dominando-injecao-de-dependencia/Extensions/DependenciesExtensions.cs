using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominando_injecao_de_dependencia.Extensions
{
    public static class DependenciesExtensions
    {
        public static void AddSqlConnection(this IServiceCollection service, string connectionString)
        => new SqlConnection(connectionString);

        public static void AddRepository(this IServiceCollection service)
        {
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
        }

        public static void AddService(this IServiceCollection service)
        {
            builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
        }
    }
}