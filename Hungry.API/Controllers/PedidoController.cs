using Hungry.API.Requests;
using Hungry.API.Responses;
using Hungry.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Hungry.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly CriarPedidoUseCase _criarPedido;
        private readonly AdicionarItemPedidoUseCase _adicionarItem;
        private readonly PagarPedidoUseCase _efetuarPagamento;
        private readonly FinalizarPedidoUseCase _finalizarPedido;
        private readonly ObterPedidoUseCase _obterPedido;

        public PedidoController(
            CriarPedidoUseCase criarPedido,
            AdicionarItemPedidoUseCase adicionarItem,
            PagarPedidoUseCase efetuarPagamento,
            FinalizarPedidoUseCase finalizarPedido,
            ObterPedidoUseCase obterPedido)
        {
            _criarPedido = criarPedido;
            _adicionarItem = adicionarItem;
            _efetuarPagamento = efetuarPagamento;
            _finalizarPedido = finalizarPedido;
            _obterPedido = obterPedido;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoResponse>> CriarPedido([FromBody] CriarPedidoRequest request)
        {
            var pedido = _criarPedido.Execute(nomeCliente: request.NomeCliente);
            return Ok(PedidoResponse.FromDomain(pedido));
        }

        [HttpPost("{pedidoId}/itens")]
        public async Task<IActionResult> AdicionarItem(Guid pedidoId, [FromBody] AdicionarItemRequest request)
        {
            await _adicionarItem.ExecuteAsync(pedidoId, request.Descricao, request.Quantidade, request.PrecoUnitario);
            return NoContent();
        }

        [HttpPost("{pedidoId}/pagamento")]
        public async Task<IActionResult> EfetuarPagamento(Guid pedidoId, [FromBody] PagamentoRequest request)
        {
            await _efetuarPagamento.Execute(pedidoId, request.Metodo);
            return NoContent();
        }

        [HttpPost("{pedidoId}/finalizar")]
        public async Task<IActionResult> FinalizarPedido(Guid pedidoId)
        {
            await _finalizarPedido.ExecuteAsync(pedidoId);
            return NoContent();
        }

        [HttpGet("{pedidoId}")]
        public async Task<ActionResult<PedidoResponse>> ObterPedido(Guid pedidoId)
        {
            var pedido = await _obterPedido.ExecuteAsync(pedidoId);
            return Ok(PedidoResponse.FromDomain(pedido));
        }
    }
}
