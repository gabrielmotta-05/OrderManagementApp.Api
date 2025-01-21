using MediatR;
using OrderManagementApp.Api.Commands;
using OrderManagementApp.Api.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagementApp.Api.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Order>
    {
        private static List<Order> Orders = new List<Order>(); // Lista de simulação.

        public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var existingOrder = Orders.FirstOrDefault(o => o.Id == request.Id);
            if (existingOrder == null)
            {
                throw new ArgumentException("Pedido não encontrado.");
            }

            existingOrder.NomeCliente = request.NomeCliente;
            existingOrder.Items = request.Items;
            existingOrder.DataOrdem = DateTime.UtcNow;

            return existingOrder;
        }
    }
}
