using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Tour> Tours { get; set; }
    }
}