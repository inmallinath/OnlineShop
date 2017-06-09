using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Components
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryList(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categories.OrderBy(c=>c.CategoryName);
            return View(categories);
        }
    }
}