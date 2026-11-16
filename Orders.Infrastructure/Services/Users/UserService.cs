using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Orders.API.Data;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(OrdersDbContext db, IMapper mapper, UserManager<User> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<string> Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.UserName = dto.PhoneNumber;
           await _userManager.CreateAsync(user, dto.Password);
            return user.Id;
        }
        public async Task<string> Update(UpdateUserDto dto)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == dto.Id);
            if(user == null)
            {
                //throw
            }
            var updatedUser = _mapper.Map<User>(dto);
            _db.Users.Update(updatedUser);
            await _db.SaveChangesAsync();
            return user.Id;
        }
        public async Task<List<UserViewModel>> GetAll(string searchKey)
        {
            var users =await _db.Users.Where(x =>
            x.FullName.Contains(searchKey) ||
            x.PhoneNumber.Contains(searchKey) ||
            string.IsNullOrWhiteSpace(searchKey)).ToListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }
        public async Task<string> Delete(string id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id);
            if(user == null)
            {
                //throw
            }
            user.IsDelete = true;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user.Id;
        }
        public async Task<UserViewModel> Get(string id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id);
            if(user == null)
            {
                //throw
            }
            return _mapper.Map<UserViewModel>(user);
         
        }

    }
}
