using System.Net.Http.Json;
using Hungry.Frontend.Models;

namespace Hungry.Frontend.Services;

public class PedidoService
{
    private readonly HttpClient _http;

    public PedidoService()
    { 
    }
    public PedidoService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<PedidoDto>> ObterTodosAsync()
    {
        return await _http.GetFromJsonAsync<List<PedidoDto>>("api/pedidos") ?? new();
    }

    public async Task<PedidoDto?> ObterPorIdAsync(Guid id)
    {
        return await _http.GetFromJsonAsync<PedidoDto>($"api/pedidos/{id}");
    }

    public async Task<string> CriarPedidoAsync(PedidoDto pedido)
    {
        return await _http.PostAsJsonAsync("api/pedidos", pedido).Result.Content.ReadAsStringAsync();
    }

    public async Task PagarPedidoAsync(Guid id, MetodoPagamento metodo)
    {
        await _http.PostAsync($"api/pedidos/{id}/pagar?metodo={metodo}", null);
    }

    public async Task FinalizarPedidoAsync(Guid id)
    {
        await _http.PostAsync($"api/pedidos/{id}/finalizar", null);
    }
}
