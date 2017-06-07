using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class TourCartController : Controller
    {
        private readonly TourCart _tourCart;
        private readonly ITourRepository _tourRepository;

        public TourCartController(ITourRepository tourRepository, TourCart tourCart)
        {
            _tourRepository = tourRepository;
            _tourCart = tourCart;
        }
    }
}
