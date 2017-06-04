using System.Collections.Generic;

namespace OnlineShop
{
    public interface ITourRepository
    {
        IEnumerable<Tour> Tours { get; }
        IEnumerable<Tour> TourOfTheWeek { get; }
        Tour GetTourById(int tourId);
    }
}