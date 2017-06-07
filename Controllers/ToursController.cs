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

        public ViewResult TourList()
        {
            ToursListViewModel toursList = new ToursListViewModel();
            toursList.Tours = _tourRepository.Tours;
            //Test the Model's Current Category
            toursList.CurrentCategory = "Adventure";
            return View(toursList);
        }
    }
}