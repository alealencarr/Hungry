using Hungry.Domain.Entities;
using Hungry.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Hungry.Application.UseCases 
{
    public class ObterPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ObterPedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> ExecuteAsync(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id);

            if (pedido is null)
                throw new InvalidOperationException("Pedido não encontrado.");

            return pedido;
        }
    }
}