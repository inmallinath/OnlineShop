using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderDetail> OrderItems { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal OrderTotal { get; set; }
    }
}