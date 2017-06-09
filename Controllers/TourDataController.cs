using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    public class TourDataController : Controller
    {
        private readonly ITourRepository _tourRepository;

        public TourDataController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;    
        }
        [HttpGet()]
        public IEnumerable<TourViewModel> LoadAdditionalTours()
        {
            IEnumerable<Tour> top3Tours = null;

            top3Tours = _tourRepository.Tours.OrderBy(t => t.TourId).Take(3);

            var tours = new List<TourViewModel>();
            foreach (var tour in top3Tours)
            {
                tours.Add(MapViewModels(tour));
            }
            return tours;
        }

        private TourViewModel MapViewModels(Tour tour)
        {
            return new TourViewModel()
            {
                TourId = tour.TourId,
                Name = tour.Name,
                Price = tour.Price,
                ShortDescription = tour.ShortDescription,
                ThumbnailUrl = tour.ImageThumbnailUrl
            };
        }
    }
}