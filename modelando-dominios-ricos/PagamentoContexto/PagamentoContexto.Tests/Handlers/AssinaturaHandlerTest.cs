using PagamentoContexto.Domain.Commands;
using PagamentoContexto.Domain.Handlers;
using System;
using PagamentoContexto.Tests.Mocks;
using Xunit;
using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Tests.Handlers
{
    public class AssinaturaHandlerTest
    {

        [Fact]
        public void Deve_retornar_erro_quando_documento_ja_existir()
        {
            var handler =  new AssinaturaHandler(new AlunoFakeRepository(), new ServicoEmailFakeRepository());

            var command = new CriarAssinaturaPagamentoComBoletoCommand();
            command.PrimeiroNome = "Primeiro Nome";
            command.SegundoNome = "Segundo Nome";
            command.NumeroDocumento = "12345678912";
            command.Email = "teste@teste.com";
            command.CodigoDeBarras = "1234567891234";
            command.NumeroBoleto = "1";
            command.NumeroPagamento = "1";
            command.DataDePagamento = DateTime.Now;
            command.DataDeExpiracao = DateTime.Now.AddMonths(1);
            command.Total = 10;
            command.TotalPago = 10;
            command.Emitente = "Emitente";
            command.DocumentoPagamento = "99999999999";
            command.TipoDocumentoPagamento = TipoDocumento.CPF;
            command.EnderecoPagamento = new Endereco("rua 1", "bairro 1", "numero 1", "CEP 1", "cidade 1", "uf 1", "complemento 1");
            command.EmailPagamento = new Email("pagamento@teste.com");
            command.Rua = "rua 2";
            command.Bairro = "bairro 2";
            command.Numero = "numero 2";
            command.CEP = "CEP 2";
            command.Cidade = "cidade 2";
            command.UF = "uf 2";
            command.Complemento = "complemento 2";

            handler.Handle(command);

            Assert.Equal(false, handler.IsValid);
        }
        
    }
}