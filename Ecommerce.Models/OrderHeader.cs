using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models

{//Order header will have all the information about order 
    public class OrderHeader
    {
        //Header ID
        public int Id { get; set; }
        //each order will belong to a user and user ID
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        //user table
        public ApplicationUser ApplicationUser { get; set; }
        //when order was made?
        public DateTime OrderDate { get; set; }
        //when order was shipped?
        //public DateTime ShippingDate { get; set; }
        public double OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        //given or pending
        public string? PaymentStatus { get; set; }
        //public string? TrackingNumber { get; set; }
        //public string? Carrier { get; set; }
        //public DateTime PaymentDate { get; set; }
        //for company user, we will give them net 30 days to make payment after the
        //by when the payment is due.
        //public DateOnly PaymentDueDate { get; set; }
        //payment id
        //public string? PaymentIntentId { get; set; }


        //properties added in the view 
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
