using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageUserApi.Models
{
    public class CommonResponse
    {
        public int StatusCode { get; set; }
        public Object StatusMsg { get; set; }
        public Object Data { get; set; }
    }
    public class UserDetails
    {
        [Required(ErrorMessage = "Mobile Is required")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "PinCode is required")]
        public string PinCode { get; set; }
    }
}
