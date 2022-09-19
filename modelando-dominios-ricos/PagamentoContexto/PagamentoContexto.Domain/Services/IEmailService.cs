namespace PagamentoContexto.Domain.Services
{
    public interface IEmailService
    {
         void EnviarEmail(string para, string email, string subititulo, string corpoEmail);
    }
}