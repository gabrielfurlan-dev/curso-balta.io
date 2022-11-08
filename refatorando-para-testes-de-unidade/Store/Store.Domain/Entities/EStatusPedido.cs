using System;
namespace Store.Domain.Entities
{
    public enum EStatusPedido
    {
        NovoPedido = 0,
        AguardandoPagamento = 1,
        PagamentoConcluido = 2,
        ProntoParaEntregar = 3,
        EmTransporte = 4,
        Entregue = 5,
        Concluido = 6,
        PedidoCancelado = 7,
    }
}