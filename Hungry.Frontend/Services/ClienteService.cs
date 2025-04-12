using System.Net.Http.Json;
using Hungry.Frontend.Models;

namespace Hungry.Frontend.Services;

public class ClienteService
{
    private readonly HttpClient _http;

    public ClienteService()
    {

    }
    public ClienteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ClienteDto>> ObterTodosAsync()
    {
        return await _http.GetFromJsonAsync<List<ClienteDto>>("api/clientes") ?? new();
    }

    public async Task CadastrarAsync(string nome, string telefone, string email)
    {
        var cliente = new ClienteDto
        {
            Nome = nome,
            Telefone = telefone,
            Email = email
        };

        await _http.PostAsJsonAsync("api/clientes", cliente);
    }
}
