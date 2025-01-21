using MediatR;
using OrderManagementApp.Api.Commands;
using OrderManagementApp.Api.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagementApp.Api.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private static List<Order> Orders = new List<Order>();

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Orders.FirstOrDefault(o => o.Id == request.Id);
            if (order == null)
            {
                // Retorna Unit.Value, indicando que não há dados de retorno, mas a operação não foi bem-sucedida
                throw new KeyNotFoundException("Pedido não encontrado.");
            }

            Orders.Remove(order);

            return Unit.Value; // Pedido deletado com sucesso
        }
    }

}
