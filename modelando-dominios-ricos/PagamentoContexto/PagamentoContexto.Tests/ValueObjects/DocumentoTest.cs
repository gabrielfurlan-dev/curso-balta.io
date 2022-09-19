using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Domain.ValueObjects;
using Xunit;

namespace PagamentoContexto.Tests.ValueObjects
{
    public class DocumentoTest
    {
        [Fact]
        public void Deve_retornar_erro_quando_CNPJ_nao_for_valido()
        {
            var documento = new Documento("123", TipoDocumento.CNPJ);
            Assert.False(documento.Valido());

            documento = new Documento("1234567891234567890", TipoDocumento.CNPJ);
            Assert.False(documento.Valido());

        }

        [Fact]
        public void Deve_retornar_sucesso_quando_CNPJ_for_valido()
        {
            var documento = new Documento("12345678912345", TipoDocumento.CNPJ);

            Assert.True(documento.Valido());
        }

        [Fact]
        public void Deve_retornar_erro_quando_CPF_nao_for_valido()
        {
            var documento = new Documento("123", TipoDocumento.CPF);

            Assert.False(documento.Valido());
        }

        [Fact]
        public void Deve_retornar_sucesso_quando_CPF_for_valido()
        {
            var documento = new Documento("12345678912", TipoDocumento.CPF);

            Assert.True(documento.Valido());
        }
    }
}
