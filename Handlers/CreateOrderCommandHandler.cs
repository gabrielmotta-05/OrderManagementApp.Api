﻿using MediatR;
using OrderManagementApp.Api.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OrderManagementApp.Api.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private static List<Order> Orders = new List<Order>(); // Usando uma lista estática para simulação do banco de dados.

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // Verificação de dados (validação simples).
        if (request.Items == null || !request.Items.Any())
        {
            throw new ArgumentException("O pedido deve ter pelo menos um item.");
        }

        // Criando o pedido.
        var newOrder = new Order
        {
            Id = Guid.NewGuid(),
            NomeCliente = request.NomeCliente,
            Items = request.Items,
            DataOrdem = DateTime.UtcNow
        };

        // Adiciona o pedido à lista.
        Orders.Add(newOrder);

        // Retorna o pedido criado.
        return newOrder;
    }
}
