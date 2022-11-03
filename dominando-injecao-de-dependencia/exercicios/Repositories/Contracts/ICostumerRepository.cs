using DependencyRoomBooking.Controllers;

namespace exercicios.Repositories.Contracts
{
    public interface ICustomerRepository
    {
         public Task<Customer?> GetCustomerByEmail(string email);
    }
}