using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourRepository _tourRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ToursController(ITourRepository tourRepository, ICategoryRepository categoryRepository)
        {
            _tourRepository = tourRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult TourList(string category)
        {
            IEnumerable<Tour> tours;
            string _category = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                tours = _tourRepository.Tours.OrderBy(t=>t.TourId);
                _category = "All Tours";
            }
            else
            {
                tours = _tourRepository.Tours
                        .Where(t=>t.Category.CategoryName == category)
                        .OrderBy(t=>t.TourId);
                _category = _categoryRepository.Categories.FirstOrDefault(c=>c.CategoryName==category).CategoryName;
            }
            return View(new ToursListViewModel{
                Tours = tours,
                CurrentCategory = _category
            });
        }
    }
}