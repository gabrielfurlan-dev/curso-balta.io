using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;

namespace Store.Tests;

[TestClass]
public class PedidoTest
{
    private readonly Cliente _cliente = new Cliente("Teste", "teste@gmail.com");
    private readonly Produto _produto = new Produto("Produto Teste", 10, true);
    private readonly Desconto _desconto10 = new Desconto(10, DateTime.Now.AddDays(1));
    private readonly Desconto _desconto1 = new Desconto(1, DateTime.Now.AddDays(1));


    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
    {
        //Arrange
        var pedido = new Pedido(null, _desconto10, 10);

        //Act & Assert
        Assert.IsFalse(pedido.PedidoValido());
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_oito_caracteres()
    {
        //Arrange & Act
        var sut = new Pedido(_cliente, _desconto10, 1);

        //Assert
        Assert.AreEqual(8, sut.Numero.Length);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
    {
        //Arrange & Act
        var sut = new Pedido(_cliente, _desconto10, 1);

        //Assert
        Assert.AreEqual(EStatusPedido.NovoPedido, sut.Status);

        //Act
        sut.AdicionarItem(_produto, 1);

        //Assert
        Assert.AreEqual(EStatusPedido.AguardandoPagamento, sut.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pedido_pago_seu_status_deve_ser_aguardando_entrega()
    {
        //Arrange
        var sut = new Pedido(_cliente, _desconto1, 1);
        sut.AdicionarItem(_produto, 1);
        
        //Act
        sut.ConcluirPagamento(10);

        //Assert
        Assert.AreEqual(EStatusPedido.PagamentoConcluido, sut.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pedido_pago_com_valor_acima_do_custo_deve_atribuir_preco_do_troco()
    {
        //Arrange
        var sut = new Pedido(_cliente, _desconto1, 1);
        sut.AdicionarItem(_produto, 1);
        
        //Act
        sut.ConcluirPagamento(15);

        //Assert
        Assert.AreEqual(6, sut.Troco);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pedido_cancelado_deve_atualizar_seu_status()
    {
        //Arrange
        var sut = new Pedido(_cliente, _desconto1, 1);

        //Act
    }
}