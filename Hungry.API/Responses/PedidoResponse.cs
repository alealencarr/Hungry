using Hungry.Domain.Entities;
using Hungry.Domain.Enums;

namespace Hungry.API.Responses
{
    public class PedidoResponse
    {
        public Guid Id { get; set; }
        public string? Cliente { get; set; }
        public List<ItemPedidoResponse> Itens { get; set; } = new();
        public decimal Total { get; set; }
        public StatusPedido Status { get; set; }

        public static PedidoResponse FromDomain(Pedido pedido)
        {
            return new PedidoResponse
            {
                Id = pedido.Id,
                Cliente = pedido.Cliente?.Nome,
                Status = pedido.Status,
                Total = pedido.Total,
                Itens = pedido.Itens.Select(i => new ItemPedidoResponse
                {
                    Nome = i.Nome,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario,
                    Total = i.Total
                }).ToList()
            };
        }
    }

    public class ItemPedidoResponse
    {
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total { get; set; }
    }
}
