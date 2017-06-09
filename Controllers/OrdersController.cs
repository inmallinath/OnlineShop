using Microsoft.AspNetCore.Mvc;
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

        public IActionResult CheckOut()
        {
            return View();
        }
    }
}