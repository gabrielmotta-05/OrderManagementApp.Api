using Microsoft.AspNetCore.Mvc;
using OrderManagementApp.Api.Models;
using MediatR;
using OrderManagementApp.Api.Commands;
using OrderManagementApp.Api.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementApp.Api.Controllers
{
    /// <summary>
    /// Controller responsável pela gestão de pedidos.
    /// Permite a criação, atualização, exclusão e filtragem de pedidos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Construtor da controller de pedidos.
        /// </summary>
        /// <param name="mediator">Instância do MediatR</param>
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private static List<Order> Orders = new List<Order>
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

        /// <summary>
        /// Obtém todos os pedidos.
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(Orders);
        }

        /// <summary>
        /// Cria um novo pedido.
        /// </summary>
        /// <param name="command">Comando contendo os dados do pedido a ser criado</param>
        /// <returns>O pedido recém-criado</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            if (command == null || !command.Items.Any())
            {
                return BadRequest("Pedido inválido. Certifique-se de que os itens estão preenchidos.");
            }

            var createdOrder = await _mediator.Send(command);

            foreach (var item in createdOrder.Items)
            {
                if (item.Quantidade <= 0)
                {
                    return BadRequest($"A quantidade do item '{item.NomeItem}' deve ser maior que zero.");
                }

                if (item.PrecoUnitario < 0)
                {
                    return BadRequest($"O preço unitário do item '{item.NomeItem}' não pode ser negativo.");
                }
            }

            createdOrder.Id = Guid.NewGuid();
            createdOrder.DataOrdem = DateTime.UtcNow;

            Orders.Add(createdOrder);

            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.Id }, createdOrder);
        }

        /// <summary>
        /// Obtém um pedido específico pelo seu ID.
        /// </summary>
        /// <param name="id">ID do pedido</param>
        /// <returns>O pedido solicitado</returns>
        [HttpGet("{id}")]
        public IActionResult GetOrderById(Guid id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            return Ok(order);
        }

        /// <summary>
        /// Atualiza um pedido existente.
        /// </summary>
        /// <param name="id">ID do pedido a ser atualizado</param>
        /// <param name="command">Comando contendo os dados atualizados do pedido</param>
        /// <returns>O pedido atualizado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderCommand command)
        {
            command.Id = id;  // Garantir que o ID do pedido seja passado no comando

            try
            {
                var updatedOrder = await _mediator.Send(command);
                return Ok(updatedOrder);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um pedido existente.
        /// </summary>
        /// <param name="id">ID do pedido a ser excluído</param>
        /// <returns>Status de sucesso ou erro</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var command = new DeleteOrderCommand(id);

            // Envia o comando para o Mediator, que retorna Unit (sem dados de resposta)
            await _mediator.Send(command);

            // Retorna NoContent (204) quando o pedido for deletado com sucesso
            return NoContent();
        }



        /// <summary>
        /// Filtra pedidos com base nos parâmetros fornecidos.
        /// </summary>
        /// <param name="NomeCliente">Nome do cliente para filtro (opcional)</param>
        /// <param name="startDate">Data de início para o filtro (opcional)</param>
        /// <param name="endDate">Data de fim para o filtro (opcional)</param>
        /// <returns>Lista de pedidos filtrados</returns>
        [HttpGet("filter")]
        public async Task<IActionResult> FilterOrders([FromQuery] string? NomeCliente, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var command = new FilterOrdersCommand(NomeCliente, startDate, endDate);
            var filteredOrders = await _mediator.Send(command);

            return Ok(filteredOrders);
        }

    }
}
