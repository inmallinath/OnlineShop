using System.Collections.Generic;
using OnlineShop.Models;

namespace OnlineShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Tour> TourOfTheWeek { get; set; }
    }
}