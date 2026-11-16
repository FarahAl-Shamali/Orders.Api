using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Orders.Data.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
