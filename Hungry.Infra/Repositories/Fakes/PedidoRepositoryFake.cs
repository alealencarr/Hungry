using Hungry.Domain.Entities;
using Hungry.Domain.Enums;
using Hungry.Domain.Interfaces;

namespace Hungry.Infra.Repositories
{
    public class PedidoRepositoryFake : IPedidoRepository
    {
        private readonly Dictionary<Guid, Pedido> _storage = new();

        public Task<Pedido?> ObterPorIdAsync(Guid id)
        {
            _storage.TryGetValue(id, out var pedido);
            return Task.FromResult(pedido);
        }

        public Task SalvarAsync(Pedido pedido)
        {
            _storage[pedido.Id] = pedido;
            return Task.CompletedTask;
        }

        public Task AtualizarStatusAsync(Guid id, StatusPedido status)
        {
            if (_storage.ContainsKey(id))
                _storage[id].AlterarStatus(status);

            return Task.CompletedTask;
        }
    }
}
