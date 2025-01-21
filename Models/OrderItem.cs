namespace OrderManagementApp.Api.Models
{
    public class OrderItem
    {
        public string NomeItem { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public decimal PrecoTotal => Quantidade * PrecoUnitario;
    }
}
