namespace OnlineShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int TourId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Tour tour { get; set; }
        public virtual Order order { get; set; }
    }
}