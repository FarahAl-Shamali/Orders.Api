using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Data.Models
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MealId { get; set; }
       public Meal Meal { get; set; }
       public int Quantity { get; set; }
        public OrderItem()
        {
            Quantity = 1;
        }
    }
}
