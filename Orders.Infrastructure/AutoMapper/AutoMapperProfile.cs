using AutoMapper;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category,CategoryViewModel>();

            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
