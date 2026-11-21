using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orders.API.Data;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using Orders.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;

        public RestaurantService(OrdersDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<int> Create(CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            await _db.Restaurants.AddAsync(restaurant);
            await _db.SaveChangesAsync();
            return restaurant.Id;
        }
        public async Task<List<RestaurantViewModel>> GetAll(string? searchKey = null)
        {
            var restaurants =await _db.Restaurants
                .Include(x=>x.Meals)
                .Where(x=>x.Name.Contains(searchKey)||
                    string.IsNullOrWhiteSpace(searchKey))
                .OrderByDescending(x => x.Meals.Count())
                .ToListAsync();
            return _mapper.Map<List<RestaurantViewModel>>(restaurants);
        }
        public async Task<List<RestaurantViewModel>> NearMe(string userId)
        {
            var user =await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            var restaurants =await _db.Restaurants.ToListAsync();
            var distances = new Dictionary<int, double>();

            var userLocation = new Coordinates((double)user.Latitude, (double)user.Longitude);
            foreach (var restaurant in restaurants)
            {
                var restaurantLocation = new Coordinates((double)restaurant.Latitude, (double)restaurant.Longitude);
                var distanceKM = userLocation.DistanceTo(restaurantLocation);
                distances.Add(restaurant.Id, distanceKM);
            }
            var nearIds = distances.OrderBy(x => x.Value).Take(5).Select(x => x.Key).ToList();
            var nearRestaurants = await _db.Restaurants.Where(x => nearIds.Contains(x.Id)).ToListAsync();
            return _mapper.Map<List<RestaurantViewModel>>(nearRestaurants);
        }


    }
}
