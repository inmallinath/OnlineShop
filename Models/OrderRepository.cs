using System;

namespace OnlineShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appContext;
        private readonly TourCart _tourCart;

        public OrderRepository(AppDbContext appContext, TourCart tourCart)
        {
            _appContext = appContext;
            _tourCart = tourCart;
        }

        public void AddOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appContext.Orders.Add(order);

            var shoppedTours = _tourCart.ShoppedTours;

            foreach (var item in shoppedTours)
            {
                var orderItem = new OrderDetail()
                {
                    Amount = item.Amount,
                    TourId = item.Tour.TourId,
                    OrderId = order.OrderId,
                    Price = item.Tour.Price
                };

                _appContext.OrderItems.Add(orderItem);
            }

            _appContext.SaveChanges();
        }
    }
}