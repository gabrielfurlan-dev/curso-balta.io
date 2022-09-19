using System.Linq.Expressions;
using PagamentoContexto.Domain.Entities;

namespace PagamentoContexto.Domain.Queries
{
    public class AlunoQueries
    {
        public static Expression<Func<Aluno, bool>> ObterInformacoesDosAlunos(string documento)
        {
            return x => x.Documento.NumeroDocumento == documento; 
        }
    }
}