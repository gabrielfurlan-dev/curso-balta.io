using Dapper;
using DependencyStore.Models;
using dominando_injecao_de_dependencia.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace dominando_injecao_de_dependencia.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
         readonly SqlConnection _connection;
        public CustomerRepository(SqlConnection connection)
        => _connection = connection;
        
        public async Task<Customer?> GetByIdAsync(string customerId)
        {
            const string query = "SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE ID=@id";
            return await _connection.QueryFirstOrDefaultAsync<Customer>(query, new { id = customerId });
        }
        
    }
}