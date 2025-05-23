﻿using KakauDelivery.Application.Interop.ItemPedido;
using System.ComponentModel.DataAnnotations.Schema;

namespace KakauDelivery.Application.Interop.Pedido
{
    public class PedidoInputModel
    {
        public int IdCliente { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;

        public List<ItemPedidoInputModel> Itens { get; set; }

        public decimal CalcularTotal() => Itens.Sum(i => i.Quantidade * i.Produto.Preco);
    }
}
