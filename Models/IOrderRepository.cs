namespace OnlineShop.Models
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
    }
}