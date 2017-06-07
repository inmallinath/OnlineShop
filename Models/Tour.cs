namespace OnlineShop.Models
{
    public class Tour
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsTourOfTheWeek { get; set; }
        public bool SeatsAvailable { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}