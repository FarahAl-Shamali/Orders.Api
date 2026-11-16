using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orders.API.Data;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;
        public CategoryService(OrdersDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAll(string searchKey)
        {
            var categories =await _db.Categories.Where(x => x.Name.Contains(searchKey)
            || string.IsNullOrWhiteSpace(searchKey)).Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                MealCount = _db.Meals.Count(y => y.CategoryId == x.Id)
            }).ToListAsync();
            return categories;

        }
        public async Task<int> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return category.Id;
        }
        public async Task<int> Update(UpdateCategoryDto dto)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == dto.Id);
            if (category == null)
            {
                //throw 
            }
            var updatedCategory = _mapper.Map(dto, category);
            _db.Categories.Update(updatedCategory);
            _db.SaveChanges();
            return category.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(x=> x.Id == Id);
            if(category == null)
            {
                //throw
            }
            category.IsDelete = true;
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
            return category.Id;
        }

        public async Task<CategoryViewModel> Get(int Id)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(x => x.Id == Id);
            if (category == null)
            {
                //throw
            }
            var categoryVm = _mapper.Map<CategoryViewModel>(category);
            categoryVm.MealCount = _db.Meals.Count(x => x.CategoryId == category.Id);
            return categoryVm;
        }

    }
}
