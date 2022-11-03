using Dapper;
using DependencyRoomBooking.Controllers;
using exercicios.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace exercicios
{
    public class CustomerRepository : ICustomerRepository
    {
        private SqlConnection _connection;

        public CustomerRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<Customer?> GetCustomerByEmail(string email)
            => await _connection .QueryFirstOrDefaultAsync<Customer?>("SELECT * FROM [Customer] WHERE [Email]=@email", new { email });
    }
}