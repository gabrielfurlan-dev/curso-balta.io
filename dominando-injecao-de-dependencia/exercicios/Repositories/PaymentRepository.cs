using DependencyRoomBooking.Controllers;
using exercicios.Repositories.Contracts;
using RestSharp;

namespace exercicios.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public async Task<PaymentResponse?> GetPaymentResponse(string email, CreditCard creditCard)
        {
            var client = new RestClient("https://payments.com");

            var request = new RestRequest()
                .AddQueryParameter("api_key", "c20c8acb-bd76-4597-ac89-10fd955ac60d")
                .AddJsonBody(new
                {
                    User = email,
                    CreditCard = creditCard
                });
            return await client.PostAsync<PaymentResponse>(request, new CancellationToken());
        }
    }
}