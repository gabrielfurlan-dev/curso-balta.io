using ToDo.Domain.Entities;

namespace ToDo.Domain.Tests.Entities
{
    [TestClass]
    public class TodoItemTest
    {
        [TestMethod]
        public void Dado_um_novo_item_o_mesmo_nao_pode_estar_concluido()
        {
            //Arrange
            var item = new ToDoItem("Título", DateTime.Now, "Usuário");

            //Act & Assert
            Assert.IsFalse(item.Done);
        }
    }
}