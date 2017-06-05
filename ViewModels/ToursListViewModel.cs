using System.Collections.Generic;

namespace OnlineShop.ViewModels
{
    public class ToursListViewModel
    {
        public IEnumerable<Tour> Tours { get; set; }
        public string CurrentCategory { get; set; }
    }
}