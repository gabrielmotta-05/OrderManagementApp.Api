using MediatR;
using OrderManagementApp.Api.Models;
using System;
using System.Collections.Generic;

namespace OrderManagementApp.Api.Queries
{
    public class FilterOrdersCommand : IRequest<List<Order>>
    {
        public string? NomeCliente { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public FilterOrdersCommand(string? nomeCliente, DateTime? startDate, DateTime? endDate)
        {
            NomeCliente = nomeCliente;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

}
