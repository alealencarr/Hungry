using Hungry.Domain.Entities;
using Hungry.Domain.Interfaces;

namespace Hungry.Application.UseCases;

public class CriarPedidoUseCase
{
    private readonly IPedidoRepository _pedidoRepository;

    public CriarPedidoUseCase(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public Pedido Execute(string? nomeCliente = null)
    {
        Cliente? cliente = null;

        if (!string.IsNullOrWhiteSpace(nomeCliente))
        {
            cliente = new Cliente(nomeCliente);
        }

        var pedido = new Pedido(cliente);
        _pedidoRepository.SalvarAsync(pedido);

        return pedido;
    }

}
