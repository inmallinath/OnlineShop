using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderDetail> OrderItems { get; set; }
        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Street Address 1")]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter your Address")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Street Address 2")]
        public string AddressLine2 { get; set; }
        [Display(Name = "Postal Code")]
        [StringLength(7, MinimumLength = 6)]
        [Required(ErrorMessage = "Please enter your Postal Code")]
        public string PostalCode { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your City")]
        public string City { get; set; }
        [StringLength(50)]
        public string Province { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your Country")]
        public string Country { get; set; }
        [Display(Name = "Phone Number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter your Phone Number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])", ErrorMessage = "Email Address is not in a valid format")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set;}
    }
}