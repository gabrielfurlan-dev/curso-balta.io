using DependencyRoomBooking.Controllers;

namespace exercicios.Repositories.Contracts
{
    public interface IPaymentRepository
    {
         public Task<PaymentResponse?> GetPaymentResponse(string email, CreditCard creditCard);
    }
}