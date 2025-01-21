using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementApp.Api.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NomeCliente { get; set; } = string.Empty;
        public DateTime DataOrdem { get; set; } = DateTime.UtcNow;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal ValorTotal => Items.Sum(item => item.PrecoUnitario * item.Quantidade);
    }
}
