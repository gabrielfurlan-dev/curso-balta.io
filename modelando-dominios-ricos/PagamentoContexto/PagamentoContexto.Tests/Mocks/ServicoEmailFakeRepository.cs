using PagamentoContexto.Domain.Services;

namespace PagamentoContexto.Tests.Mocks
{
    public class ServicoEmailFakeRepository : IEmailService
    {
        public void EnviarEmail(string para, string email, string subititulo, string corpoEmail)
        {
            
        }
    }
}