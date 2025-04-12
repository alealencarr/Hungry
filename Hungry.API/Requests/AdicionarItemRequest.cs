namespace Hungry.API.Requests
{
    public class AdicionarItemRequest
    {
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
