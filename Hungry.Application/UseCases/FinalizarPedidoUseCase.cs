using Hungry.Domain.Interfaces;

namespace Hungry.Application.UseCases;

public class FinalizarPedidoUseCase
{
    private readonly IPedidoRepository _pedidoRepository;

    public FinalizarPedidoUseCase(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task ExecuteAsync(Guid pedidoId)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(pedidoId);

        if (pedido == null)
            throw new InvalidOperationException("Pedido não encontrado");

        pedido.Finalizar();

        await _pedidoRepository.SalvarAsync(pedido);
    }

}
