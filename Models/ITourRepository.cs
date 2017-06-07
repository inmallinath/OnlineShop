using System.Collections.Generic;

namespace OnlineShop.Models
{
    public interface ITourRepository
    {
        IEnumerable<Tour> Tours { get; }
        IEnumerable<Tour> TourOfTheWeek { get; }
        Tour GetTourById(int tourId);
    }
}