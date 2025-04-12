namespace Hungry.Tests
{
    using Hungry.Application.UseCases;
    using Hungry.Domain.Entities;
    using Hungry.Infra.Infrastructure;
    using Hungry.Domain.Enums;

    public class PedidoTests
    {
        [Fact]
        public async Task Deve_Criar_Pedido_Com_Sucesso()
        {
            var repo = new PedidoRepositoryInMemory();
            var service = new PedidoService(repo);

            var cliente = new Cliente("João");
            var itens = new List<ItemPedido> {
                new ItemPedido("X-Burger", 1, 20),
                new ItemPedido("Fritas", 2, 8)
            };

            var id = await service.CriarPedidoAsync(cliente, itens);

            var pedido = await repo.ObterPorIdAsync(id);
            Assert.NotNull(pedido);
            Assert.Equal(36, pedido!.Total);
            Assert.Equal(StatusPedido.Criado, pedido.Status);
        }
    }
}