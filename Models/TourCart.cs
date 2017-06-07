using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.Models
{
    public class TourCart
    {
        private readonly AppDbContext _appContext;

        public TourCart(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public string TourCartId { get; set; }

        public List<ShoppedTour> ShoppedTours { get; set; }

        public static TourCart Get(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<HttpContextAccessor>()
                                    ?.HttpContext.Session;
            
            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            
            session.SetString("CartId", cartId);

            return new TourCart(context) { TourCartId = cartId };
        }

        public void AddToCart(Tour tour, int amount)
        {
            var shoppedTour = _appContext.ShoppedTours
                                .SingleOrDefault(t => t.Tour.TourId == tour.TourId 
                                            && t.TourCartId == TourCartId);
            if (shoppedTour == null)
            {
                shoppedTour = new ShoppedTour
                {
                    TourCartId = TourCartId,
                    Tour = tour,
                    Amount = 1
                };
                _appContext.ShoppedTours.Add(shoppedTour);
            }
            else
            {
                shoppedTour.Amount++;
            }
            _appContext.SaveChanges();
        }

        public int RemoveFromCart(Tour tour)
        {
            var shoppedTour = _appContext.ShoppedTours
                                .SingleOrDefault(t => t.Tour.TourId == tour.TourId
                                && t.TourCartId == TourCartId);
            
            var shopAmount = 0;

            if (shoppedTour != null)
            {
                if (shoppedTour.Amount > 1)
                {
                    shoppedTour.Amount--;
                    shopAmount = shoppedTour.Amount;
                }
                else
                {
                    _appContext.ShoppedTours.Remove(shoppedTour);
                }   
            }

            _appContext.SaveChanges();
            return shopAmount;
        }

        public List<ShoppedTour> GetShoppedTours()
        {
            return ShoppedTours ?? 
                    (ShoppedTours = _appContext.ShoppedTours
                    .Where(t=>t.TourCartId == TourCartId)
                    .Include(t => t.Tour)
                    .ToList());
        }

        public void ClearCart()
        {
            var shoppedTours = _appContext.ShoppedTours
                                .Where(st =>st.TourCartId == TourCartId);
            _appContext.ShoppedTours.RemoveRange(shoppedTours);
            _appContext.SaveChanges();
        }
    }
}