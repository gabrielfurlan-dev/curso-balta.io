using ToDo.Domain.Entities;
using ToDo.Domain.Queries;

namespace ToDo.Domain.Tests.Queries
{
    [TestClass]
    public class TodoQueriesTest
    {
        [TestMethod]
        public void Dado_uma_consulta_deve_retornar_somente_as_tarefas_de_um_determinado_usuario()
        {
            //Arrange
            var tarefas = new List<ToDoItem>();
            tarefas.Add(new ToDoItem("Tarefa 1", DateTime.Now.AddDays(1), "Kappa"));
            tarefas.Add(new ToDoItem("Tarefa 2", DateTime.Now.AddDays(1), "Balta"));
            tarefas.Add(new ToDoItem("Tarefa 3", DateTime.Now.AddDays(1), "Kappa"));
            tarefas.Add(new ToDoItem("Tarefa 4", DateTime.Now.AddDays(1), "Kappa"));
            tarefas.Add(new ToDoItem("Tarefa 5", DateTime.Now.AddDays(1), "Balta"));

            //Act 
            tarefas = tarefas.AsQueryable()
                                .Where(ToDoQueries.GetAll("Kappa"))
                                .ToList();

            //Assert
            Assert.AreEqual(expected: 3, actual: tarefas.Count());
        }
    }
}