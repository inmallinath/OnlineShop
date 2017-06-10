using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly TourCart _tourCart;

        public OrdersController(IOrderRepository orderRepository, TourCart tourCart)
        {
            _orderRepository = orderRepository;
            _tourCart = tourCart;
        }
        [Authorize]
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CheckOut(Order order)
        {
            var tours = _tourCart.GetShoppedTours();
            _tourCart.ShoppedTours = tours;

            if (_tourCart.ShoppedTours.Count == 0)
            {
                ModelState.AddModelError("","No tours in your cart. Please select some before your check out");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.AddOrder(order);
                _tourCart.ClearCart();
                return RedirectToAction("PostCheckOut");
            }
            return View(order);
        }

        public IActionResult PostCheckOut()
        {
            ViewBag.PostCheckOutMessage = "Pack your bags. You are all set!!!";
            return View();
        }
    }
}