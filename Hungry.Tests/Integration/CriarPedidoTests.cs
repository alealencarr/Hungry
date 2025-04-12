using System.Net.Http.Json;
using FluentAssertions;
using Hungry.API.Responses;
using Hungry.API.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;


namespace Hungry.Tests.Integration
{
    public class CriarPedidoTests : IClassFixture<WebApplicationFactory<Program>>
    {
     
        private readonly HttpClient _client;

        public CriarPedidoTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Deve_Criar_Um_Pedido_Com_Sucesso()
        {
            var request = new CriarPedidoRequest
            {
                NomeCliente = "João"
            };

            var response = await _client.PostAsJsonAsync("/api/pedidos", request);

            response.EnsureSuccessStatusCode();

            var pedido = await response.Content.ReadFromJsonAsync<PedidoResponse>();

            pedido.Should().NotBeNull();
            pedido!.Id.Should().NotBeEmpty();
            pedido.Cliente.Should().Be("João");
            pedido.Itens.Should().BeEmpty();
        }
    }
}
