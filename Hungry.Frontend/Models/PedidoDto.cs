namespace Hungry.Frontend.Models;

public class PedidoDto
{
    public Guid Id { get; set; }
    public Guid? ClienteId { get; set; }
    public string ClienteNome { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public StatusPedidoDto Status { get; set; }
    public MetodoPagamento? MetodoPagamento { get; set; }

    public List<ItemPedidoDto> Itens { get; set; } = new();
}

public class ItemPedidoDto
{
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
}
