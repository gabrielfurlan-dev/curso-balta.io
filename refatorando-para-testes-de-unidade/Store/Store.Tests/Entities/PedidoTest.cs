using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;

namespace Store.Tests;

[TestClass]
public class PedidoTest
{
    private readonly Cliente _cliente = new Cliente("Teste", "teste@gmail.com");
    private readonly Produto _produto = new Produto("Produto Teste", 10, true);
    private readonly Desconto _desconto = new Desconto(1m, DateTime.Now.AddDays(1));

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
    {
        //Arrange
        var pedido = new Pedido(null, _desconto, 10);

        //Act & Assert
        Assert.IsFalse(pedido.PedidoValido());
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_oito_caracteres()
    {
        //Arrange & Act
        var sut = new Pedido(_cliente, _desconto, 1);

        //Assert
        Assert.AreEqual(8, sut.Numero.Length);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
    {
        //Arrange & Act
        var sut = new Pedido(_cliente, _desconto, 1);

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
        var sut = new Pedido(_cliente, _desconto, 0);
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
        var sut = new Pedido(_cliente, _desconto, 0);
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
        var sut = new Pedido(_cliente, _desconto, 1);

        //Act
        sut.CancelarPedido();

        //Assert
        Assert.AreEqual(EStatusPedido.PedidoCancelado ,sut.Status);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Quando_adicionado_um_novo_item_deve_recalcular_preco_total()
    {
        //Arrange
        var sut = new Pedido(_cliente, _desconto, 0);

        //Act
        sut.AdicionarItem(_produto, 1);
        sut.AdicionarItem(_produto, 2);

        //Assert
        Assert.AreEqual(29, sut.ValorTotal);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pedido_com_o_produto_invalido_o_mesmo_nao_deve_ser_adicionado()
    {
        //Arrange
        var sut = new Pedido(_cliente, _desconto, 1);

        //Act
        //Item invalido = nulo ou com quantidade menor que 0
        sut.AdicionarItem(null, 1);

        //Assert
        Assert.AreEqual(0, sut.ValorTotal);
        Assert.AreEqual(0, sut.Itens.Count);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_pedido_com_o_desconto_expirado_nao_deve_calcular_preco_total_com_desconto()
    {
        //Arrange
        var desconto = new Desconto(10, DateTime.Now.AddDays(30));
        var sut = new Pedido(_cliente, desconto, 0);

        //Act
        sut.AdicionarItem(_produto, 2);

        //Assert
        Assert.AreEqual(10, sut.ValorTotal);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_valor_de_desconto_invalido_o_mesmo_nao_deve_ser_considerado()
    {
        //Arrange
        var sut = new Pedido(_cliente, null, 0);

        //Act
        sut.AdicionarItem(_produto, 2);

        //Act & Assert
        Assert.AreEqual(20, sut.ValorTotal);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_um_desconto_valido_deve_ser_calculado_o_valor_total_considerando_o_desconto()
    {
        //Arrange
        var sut = new Pedido(_cliente, _desconto, 0);

        //Act
        sut.AdicionarItem(_produto, 2);

        //Act & Assert
        Assert.AreEqual(19, sut.ValorTotal);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Dado_uma_taxa_de_entrega_no_pedido_deve_ser_calculada_no_valor_total()
    {
        //Arrange
        var desconto= new Desconto(1, DateTime.Now.AddDays(1));
        var sut = new Pedido(_cliente, desconto, 10);

        //Act
        sut.AdicionarItem(_produto, 1);

        //Act & Assert
        Assert.AreEqual(19, sut.ValorTotal);
    }
}