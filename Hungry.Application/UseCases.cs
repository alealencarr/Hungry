using Hungry.Domain.Entities;
using Hungry.Domain.Interfaces;
using Hungry.Domain.Enums;

namespace Hungry.Application.UseCases
{
    public class PedidoService
    {
        private readonly IPedidoRepository _repo;

        public PedidoService(IPedidoRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> CriarPedidoAsync(Cliente? cliente, List<ItemPedido> itens)
        {
            var pedido = new Pedido(cliente);
            foreach (var item in itens)
                pedido.AdicionarItem(item.Nome, item.Quantidade, item.PrecoUnitario);

            await _repo.SalvarAsync(pedido);
            return pedido.Id;
        }

        public async Task MudarStatusAsync(Guid id, StatusPedido novoStatus)
        {
            var pedido = await _repo.ObterPorIdAsync(id) ?? throw new Exception("Pedido não encontrado");
            pedido.AlterarStatus(novoStatus);
            await _repo.AtualizarStatusAsync(id, novoStatus);
        }
    }

    public class PagamentoService
    {
        private readonly IPagamentoGateway _gateway;

        public PagamentoService(IPagamentoGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task EfetuarPagamento(Guid pedidoId, decimal valor)
        {
            var sucesso = await _gateway.RealizarPagamento(pedidoId, valor);
            if (!sucesso) throw new Exception("Pagamento recusado");
        }
    }
}