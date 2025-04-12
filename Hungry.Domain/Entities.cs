using Hungry.Domain.Enums;

namespace Hungry.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string? Cpf { get; private set; } // Opcional

        public Cliente(string nome, string? cpf = null)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cpf = cpf;
        }
    }

    public class ItemPedido
    {
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }

        public decimal Total => Quantidade * PrecoUnitario;

        public ItemPedido(string nome, int quantidade, decimal precoUnitario)
        {
            Nome = nome;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
    }



    public class Pedido
    {
        public Guid Id { get; private set; }
        public Cliente? Cliente { get; private set; }
        public List<ItemPedido> Itens { get; private set; } = new();
        public StatusPedido Status { get; private set; } = StatusPedido.Criado;
        public MetodoPagamento? MetodoPagamento { get; private set; }
        public decimal Total => Itens.Sum(x => x.Total);

        public Pedido(Cliente? cliente = null)
        {
            Id = Guid.NewGuid();
            Cliente = cliente;
        }

        public void AdicionarItem(string nome, int qtd, decimal preco)
        {
            Itens.Add(new ItemPedido(nome, qtd, preco));
        }

        public void AlterarStatus(StatusPedido novoStatus)
        {
            Status = novoStatus;
        }

        public void Finalizar()
        {
            if (Itens == null || !Itens.Any())
                throw new InvalidOperationException("Não é possível finalizar um pedido sem itens.");

            if (Status != StatusPedido.Criado)
                throw new InvalidOperationException("Apenas pedidos no status 'Criado' podem ser finalizados.");

            AlterarStatus(StatusPedido.Finalizado);
        }
 


        public void Pagar(MetodoPagamento metodo)
        {
            if (Status != StatusPedido.Criado)
                throw new InvalidOperationException("Somente pedidos no status 'Criado' podem ser pagos.");

            if (Itens == null || !Itens.Any())
                throw new InvalidOperationException("Não é possível pagar um pedido sem itens.");

            MetodoPagamento = metodo;
            AlterarStatus(StatusPedido.Pago);
        }


    }
}
 
