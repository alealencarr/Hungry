using Hungry.Domain.Enums;
using Hungry.Domain.Interfaces;

namespace Hungry.Application.UseCases;

public class PagarPedidoUseCase
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IPagamentoGateway _pagamentoGateway;

    public PagarPedidoUseCase(IPedidoRepository pedidoRepository, IPagamentoGateway pagamentoGateway)
    {
        _pedidoRepository = pedidoRepository;
        _pagamentoGateway = pagamentoGateway;
    }

    public async Task Execute(Guid pedidoId, MetodoPagamento metodo)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(pedidoId);
        if (pedido == null)
            throw new InvalidOperationException("Pedido não encontrado");

        var sucesso = await _pagamentoGateway.RealizarPagamento(pedido.Id, pedido.Total);

        if (!sucesso)
            throw new InvalidOperationException("Falha ao processar pagamento");

        pedido.Pagar(metodo);
        await _pedidoRepository.SalvarAsync(pedido);

    }
}
