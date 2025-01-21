using MediatR;
using OrderManagementApp.Api.Models;

namespace OrderManagementApp.Api.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public string NomeCliente { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
