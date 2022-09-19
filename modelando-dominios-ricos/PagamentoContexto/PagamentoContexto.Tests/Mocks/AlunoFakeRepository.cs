using PagamentoContexto.Domain.Entities;
using PagamentoContexto.Domain.Repositories;

namespace PagamentoContexto.Tests.Mocks
{
    public class AlunoFakeRepository : IAlunoRepository
    {
        public void CriarAssinatura(Aluno aluno)
        {

        }

        public bool ExisteDocumento(string documento)
        {
            if (documento == "99999999999")
                return true;

            return false;
        }
        public bool ExisteEmail(string email)
        {
            if (email == "kappa@balta.io")
                return true;

            return false;
        }
    }
}