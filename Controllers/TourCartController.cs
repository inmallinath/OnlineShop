using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.ViewModels;

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

        public ViewResult Index()
        {
            var tours = _tourCart.GetShoppedTours();
            _tourCart.ShoppedTours = tours;

            var cartViewModel = new TourCartViewModel
            {
                TourCart = _tourCart,
                CartTotal = _tourCart.GetCartTotal()
            };
            
            return View(cartViewModel);
        }

        public RedirectToActionResult AddToTourCart(int tourId)
        {
            var selectedTour = _tourRepository.Tours.FirstOrDefault(t=>t.TourId == tourId);
            if (selectedTour != null)
            {
                _tourCart.AddToCart(selectedTour, 1);
            }
            return RedirectToAction("Index");
        }
    }
}
