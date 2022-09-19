using PagamentoContexto.Domain.Commands;
using Xunit;

namespace PagamentoContexto.Tests.Commands;

public class AlunoTest
{
    [Fact]
    public void Deve_retornar_erro_quando_nome_for_invalido()
    {
        //Arrange
        var command = new CriarAssinaturaPagamentoComBoletoCommand();
        command.PrimeiroNome = "1";

        //Act
        command.Validar();

        //Assert
        Assert.False(command.IsValid);
    }
}