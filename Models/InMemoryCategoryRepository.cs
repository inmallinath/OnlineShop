using System;
using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories => new List<Category>{
            new Category{ CategoryId = 1, CategoryName = "Sports", Description = "All Sports related tours"},
            new Category{ CategoryId = 2, CategoryName = "Adventure", Description = "All tours related to adventure"},
            new Category{ CategoryId = 3, CategoryName = "Musical", Description = "Music to the core"},
            new Category{ CategoryId = 4, CategoryName = "Spiritual", Description = "Seeking God"}
        };
    }
}