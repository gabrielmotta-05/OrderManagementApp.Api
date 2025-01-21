using MediatR;
using OrderManagementApp.Api.Models;
using OrderManagementApp.Api.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagementApp.Api.Handlers
{
    public class FilterOrdersCommandHandler : IRequestHandler<FilterOrdersCommand, List<Order>>
    {
        private readonly OrdersService _ordersService;

        public FilterOrdersCommandHandler(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public async Task<List<Order>> Handle(FilterOrdersCommand request, CancellationToken cancellationToken)
        {
            var filteredOrders = _ordersService.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(request.NomeCliente))
            {
                filteredOrders = filteredOrders.Where(o => o.NomeCliente.Contains(request.NomeCliente, StringComparison.OrdinalIgnoreCase));
            }

            if (request.StartDate.HasValue)
            {
                filteredOrders = filteredOrders.Where(o => o.DataOrdem >= request.StartDate.Value);
            }

            if (request.EndDate.HasValue)
            {
                filteredOrders = filteredOrders.Where(o => o.DataOrdem <= request.EndDate.Value);
            }

            return filteredOrders.ToList();
        }
    }

}
