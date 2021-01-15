using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsProject.UI.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Please type into your user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please type into your password")]
        public string Password { get; set; }
    }
}