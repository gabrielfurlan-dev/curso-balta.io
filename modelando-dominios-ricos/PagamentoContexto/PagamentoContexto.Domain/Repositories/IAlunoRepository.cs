namespace PagamentoContexto.Domain.Repositories
{
    public interface IAlunoRepository
    {
         bool ExisteDocumento();
         bool ExisteEmail();
         void CriarAssinatura();
    }
}