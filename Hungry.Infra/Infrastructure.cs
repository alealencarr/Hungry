using Hungry.Domain.Entities;
using Hungry.Domain.Interfaces;
using Hungry.Domain.Enums;

namespace Hungry.Infra.Infrastructure
{
   

    public class PedidoRepositoryInMemory : IPedidoRepository
    {
        private readonly Dictionary<Guid, Pedido> _storage = new();

        public Task<Pedido?> ObterPorIdAsync(Guid id)
            => Task.FromResult(_storage.TryGetValue(id, out var pedido) ? pedido : null);

        public Task SalvarAsync(Pedido pedido)
        {
            _storage[pedido.Id] = pedido;
            return Task.CompletedTask;
        }

        public Task AtualizarStatusAsync(Guid id, StatusPedido status)
        {
            if (_storage.TryGetValue(id, out var pedido))
            {
                pedido.AlterarStatus(status);
            }
            return Task.CompletedTask;
        }
    }

    public class PagamentoGatewayFake : IPagamentoGateway
    {
        public Task<bool> RealizarPagamento(Guid pedidoId, decimal valor)
        {
            return Task.FromResult(true); // sempre aprova
        }
    }
}
 
