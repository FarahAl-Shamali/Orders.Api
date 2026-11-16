using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Orders.Data.Models
{
    public class Meal : BaseEntity
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        public string? Description { get; set; }
        public string? Image { get; set; }
        [Required]

        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public decimal? DiscountValue { get; set; }
        public List<OrderItem> Orders { get; set; }

    }
}
