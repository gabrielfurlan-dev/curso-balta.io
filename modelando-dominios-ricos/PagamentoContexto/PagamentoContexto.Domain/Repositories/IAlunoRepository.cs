using PagamentoContexto.Domain.Entities;

namespace PagamentoContexto.Domain.Repositories
{
    public interface IAlunoRepository
    {
         bool ExisteDocumento(string documento);
         bool ExisteEmail(string email);
         void CriarAssinatura(Aluno aluno);
    }
}   