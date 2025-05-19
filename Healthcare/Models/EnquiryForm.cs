using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Healthcare.Models
{
    public class EnquiryForm
    {
        public int id { get; set; } = 0;
        public string EnquiryDate { get; set; } = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");
      

        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Please select a product")]
        public string Product { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
    }
}