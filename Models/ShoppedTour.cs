namespace OnlineShop.Models
{
    public class ShoppedTour
    {
        public int ShoppedTourId { get; set; }
        public Tour Tour { get; set; }
        public int Amount { get; set; }
        public string TourCartId { get; set; }
    }
}