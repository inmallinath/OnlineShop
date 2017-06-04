using Microsoft.AspNetCore.Mvc;

namespace OnlineShop
{
    public class TourController : Controller
    {
        private readonly ITourRepository _tourRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TourController(ITourRepository tourRepository, ICategoryRepository categoryRepository)
        {
            _tourRepository = tourRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult TourList()
        {
            return View(_tourRepository.Tours);
        }
    }
}