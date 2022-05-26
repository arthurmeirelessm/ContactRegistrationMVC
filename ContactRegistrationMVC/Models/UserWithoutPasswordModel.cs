using ContactRegistrationMVC.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class UserWithoutPasswordModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; }
      
        [Required(ErrorMessage = "Enter login")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Enter your Email")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your Type user")]
        public UserEnum UserType { get; set; }
      
    }
}
