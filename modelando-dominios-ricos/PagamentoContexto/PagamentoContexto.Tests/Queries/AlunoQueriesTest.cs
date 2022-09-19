using System.Collections.Generic;
using System.Linq;
using PagamentoContexto.Domain.Entities;
using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Domain.Queries;
using PagamentoContexto.Domain.ValueObjects;
using Xunit;

namespace PagamentoContexto.Tests.Queries
{
    public class AlunoQueriesTest
    {
        private IList<Aluno> _alunos;

        public AlunoQueriesTest()
        {
            _alunos = new List<Aluno>();
            
            for (int i = 0; i <= 10; i++)
            {
                _alunos.Add(
                    new Aluno(
                        new NomeCompleto("Aluno", i.ToString()),
                        new Documento("1111111111" + i.ToString(), TipoDocumento.CPF),
                        new Email($"aluno{i.ToString()}@teste.com")
                    )
                );
            }
        }

        [Fact]
        public void Deve_retornar_nulo_quando_documento_nao_existir()
        {
            var expression = AlunoQueries.ObterInformacoesDosAlunos("12345678911");
            var estudante = _alunos.AsQueryable().Where(expression).FirstOrDefault();

            Assert.Equal(null, estudante);
        }

        public void Deve_retornar_aluno_quando_documento_existir()
        {
            var expression = AlunoQueries.ObterInformacoesDosAlunos("11111111111");
            var estudante = _alunos.AsQueryable().Where(expression).FirstOrDefault();

            Assert.NotEqual(null, estudante);
        }
    }
}