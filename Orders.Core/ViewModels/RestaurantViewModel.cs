using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Orders.Core.ViewModels
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LogoUrl { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

    }
}
