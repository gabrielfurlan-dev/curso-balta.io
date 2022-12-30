using Todo.Domain.Commands.Inputs;

namespace Todo.Domain.Tests.Commands.Inputs;

[TestClass]
public class CreateTodoCommandTests
{
    [TestMethod]
    public void Quando_titulo_for_menor_que_4_caracteres_command_deve_ser_invalido()
    {
        //Arrange
        var sut = new CreateToDoCommand("Abc", new DateTime(2020, 12, 28), "Referencia de Usuario Teste");

        //Act
        sut.Validate();

        //Assert
        Assert.IsFalse(sut.IsValid);
    }

    [TestMethod]
    public void Quando_referencia_de_usuario_for_menor_que_6_caracteres_command_deve_ser_invalido()
    {
        //Arrange
        var sut = new CreateToDoCommand("Tarefa", new DateTime(2020, 12, 28), "Abcde");

        //Act
        sut.Validate();

        //Assert
        Assert.IsFalse(sut.IsValid);
    }
    
    [TestMethod]
    public void Quando_todos_os_campos_estiverem_preenchidos_command_deve_ser_valido()
    {
        //Arrange
        var sut = new CreateToDoCommand("Tarefa", new DateTime(2020, 12, 28), "Referencia de usuario");

        //Act
        sut.Validate();

        //Assert
        Assert.IsTrue(sut.IsValid);
    }
}