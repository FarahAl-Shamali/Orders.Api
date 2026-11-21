using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Services.Restaurants
{
    public interface IRestaurantService
    {
        Task<List<RestaurantViewModel>> GetAll(string searchKey);
        Task<List<RestaurantViewModel>> NearMe(string userId);
        Task<int> Create(CreateRestaurantDto dto);
    }
}
