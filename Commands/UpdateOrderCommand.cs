using MediatR;
using OrderManagementApp.Api.Models;

namespace OrderManagementApp.Api.Commands
{
    public class UpdateOrderCommand : IRequest<Order>
    {
        public Guid Id { get; set; }
        public string NomeCliente { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
