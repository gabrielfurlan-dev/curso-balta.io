using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CriarItemPedidoCommandTest
    {
        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_pedido_invalido_command_nao_deve_ser_gerado()
        {
            var command = new GerarPedidoCommand();
            command.Customer = "";
            command.PromoCode = "";
            command.ZipCode = "";
            command.Itens = null;

            Assert.IsFalse(command.EhValido());
        }
    }
}