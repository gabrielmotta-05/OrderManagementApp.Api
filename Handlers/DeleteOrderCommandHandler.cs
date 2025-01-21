using MediatR;
using OrderManagementApp.Api.Commands;

namespace OrderManagementApp.Api.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly OrdersService _ordersService;

        public DeleteOrderCommandHandler(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _ordersService.Orders.FirstOrDefault(o => o.Id == request.Id);
            if (order == null)
            {
                // Retorna Unit.Value, indicando que não há dados de retorno, mas a operação não foi bem-sucedida
                throw new KeyNotFoundException("Pedido não encontrado.");
            }

            _ordersService.Orders.Remove(order);

            return Unit.Value; // Pedido deletado com sucesso
        }
    }

}
