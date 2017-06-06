using System;
using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appContext;

        public CategoryRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Category> Categories => _appContext.Categories;
    }
}