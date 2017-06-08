using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Components
{
    public class TourCartSummary : ViewComponent
    {
        private readonly TourCart _tourCart;

        public TourCartSummary(TourCart tourCart)
        {
            _tourCart = tourCart;
        }

        public IViewComponentResult Invoke()
        {
            var tours = _tourCart.GetShoppedTours();
            _tourCart.ShoppedTours = tours;

            var tourCartViewModel = new TourCartViewModel
            {
                TourCart = _tourCart,
                CartTotal = _tourCart.GetCartTotal()
            };
            return View(tourCartViewModel);
        }
    }
}