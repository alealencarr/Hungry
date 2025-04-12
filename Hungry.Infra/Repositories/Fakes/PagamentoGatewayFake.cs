using Hungry.Domain.Interfaces;

namespace Hungry.Infra.Repositories
{
    public class PagamentoGatewayFake : IPagamentoGateway
    {
        public Task<bool> RealizarPagamento(Guid pedidoId, decimal valor)
        {
            // Simula um pagamento bem-sucedido
            return Task.FromResult(true);
        }
    }
}
