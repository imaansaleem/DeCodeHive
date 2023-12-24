﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This class will contain all the constants for our website
namespace Ecommerce.Utility
{
    public static class SD
    {
        public const string Role_Customer = "Customer";
        public const string Role_Company = "Company";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";

        public const string StatusApproved = "Approved";
        public const string StatusPending = "Pending";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusRefunded = "Refunded";
        public const string StatusCancelled = "Cancelled";

        public const string PaymentStatusPending = "Pending"; 
        public const string PaymentStatusApproved= "Approved";
        public const string PaymentStatusRejected = "Rejected";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
    }
}
