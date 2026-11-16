using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Orders.Data.Models
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        [Required]

        public string CustomerId { get; set; }
        public User Customer { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public List<OrderItem> Orders  { get; set; }
    }
}
