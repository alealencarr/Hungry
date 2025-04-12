using Hungry.Domain.Entities;
using Hungry.Domain.Interfaces;


namespace Hungry.Application.UseCases;

public class AdicionarItemPedidoUseCase
{
    private readonly IPedidoRepository _pedidoRepository;

    public AdicionarItemPedidoUseCase(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task ExecuteAsync(Guid pedidoId, string descricao, int quantidade, decimal precoUnitario)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(pedidoId);

        if (pedido == null)
            throw new InvalidOperationException("Pedido não encontrado");

        pedido.AdicionarItem(descricao, quantidade, precoUnitario);

        await _pedidoRepository.SalvarAsync(pedido);
    }

}
