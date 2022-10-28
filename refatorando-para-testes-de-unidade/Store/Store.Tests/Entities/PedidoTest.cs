using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;

namespace Store.Tests;

[TestClass]
public class PedidoTest
{
    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
    {
        //Arrange
        var pedido = new Pedido(null, 10, 10);

        //Act & Assert
        Assert.IsFalse(pedido.PedidoValido());
    }
}