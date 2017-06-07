using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITourRepository _tourRepository;

        public HomeController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                TourOfTheWeek = _tourRepository.TourOfTheWeek
            };
            return View(homeViewModel);
        }
    }
}