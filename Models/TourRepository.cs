using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Models
{
    public class TourRepository : ITourRepository
    {
        private readonly AppDbContext _appContext;

        public TourRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Tour> Tours => _appContext.Tours.Include(c=>c.Category);

        public IEnumerable<Tour> TourOfTheWeek => _appContext.Tours.Include(c=>c.Category).Where(t=>t.IsTourOfTheWeek);

        public Tour GetTourById(int tourId)
        {
            return _appContext.Tours.FirstOrDefault(t => t.TourId == tourId);
        }
    }
}