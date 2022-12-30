using Todo.Domain.Commands.Handlers;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.Commands.Handlers
{
    [TestClass]
    public class TodoHandlerTests
    {
        [TestMethod]
        public void Dado_um_command_invalido_deve_interromper_a_execucao()
        {
            //Arrange
            var command = new CreateToDoCommand("", new DateTime(2022, 12, 28), "");
            var sut = new ToDoHandler(new FakeTodoRepository());

            //Act
            var result = (GenericCommandResult)sut.Handle(command);

            //Assert
            Assert.IsFalse(result.Sucesso);
        }

        [TestMethod]
        public void Dado_um_command_valido_deve_criar_tarefa()
        {
            //Arrange
            var command = new CreateToDoCommand("Tarefa Teste", new DateTime(2022, 12, 28), "Referência de usuário");
            var sut = new ToDoHandler(new FakeTodoRepository());

            //Act
            var result = (GenericCommandResult)sut.Handle(command);

            //Assert
            Assert.IsTrue(result.Sucesso);
        }
    }
}