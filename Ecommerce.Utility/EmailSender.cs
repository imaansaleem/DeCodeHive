using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Implement your email sending logic here
            // This method should send an email with the provided parameters
            // You can use an email service library or framework to send the email.
            // For simplicity, you can just write a placeholder implementation.
            return Task.CompletedTask;
        }
    }
}
