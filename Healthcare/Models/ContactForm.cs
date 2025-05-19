using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Healthcare.Models
{
    public class ContactForm
    {
        public int id { get; set; } = 0;
        public string ContactDate { get; set; }=DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");
     
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
    }
}