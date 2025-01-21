using OrderManagementApp.Api.Models;

public class OrdersService
{
    public List<Order> Orders { get; } = new List<Order>
    {
        new Order
        {
            NomeCliente = "Gabriel Motta",
            DataOrdem = DateTime.UtcNow,
            Items = new List<OrderItem>
            {
                new OrderItem { NomeItem = "Laptop", Quantidade = 1, PrecoUnitario = 1200.50M },
                new OrderItem { NomeItem = "Mouse", Quantidade = 2, PrecoUnitario = 25.00M }
            }
        },
        new Order
        {
            NomeCliente = "Aline Carvalho",
            DataOrdem = DateTime.UtcNow.AddDays(-1),
            Items = new List<OrderItem>
            {
                new OrderItem { NomeItem = "Keyboard", Quantidade = 1, PrecoUnitario = 100.00M },
                new OrderItem { NomeItem = "Monitor", Quantidade = 2, PrecoUnitario = 300.00M }
            }
        }
    };
}
