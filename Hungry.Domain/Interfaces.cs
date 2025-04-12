using Hungry.Domain.Entities;
using Hungry.Domain.Enums;

namespace Hungry.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido?> ObterPorIdAsync(Guid id);
        Task SalvarAsync(Pedido pedido);
        Task AtualizarStatusAsync(Guid id, StatusPedido status);
    }

    public interface IPagamentoGateway
    {
        Task<bool> RealizarPagamento(Guid pedidoId, decimal valor);
    }
}