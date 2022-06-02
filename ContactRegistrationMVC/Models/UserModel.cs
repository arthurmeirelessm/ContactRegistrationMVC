using ContactRegistrationMVC.Enums;
using ContactRegistrationMVC.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class UserModel : BaseModel
    {
        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter your Email")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your Type user")]
        public UserEnum UserType { get; set; }
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
        public DateTime DateUpAt { get; set; }
        public void SetPasswordHash()
        {
            Password = Password.GenerateHash();
        }

        public string GenerateNewPassword ()
        {
            string NewPassword = Guid.NewGuid().ToString().Substring(0, 8);
            Password = NewPassword.GenerateHash();
            return NewPassword; 
        }

    }
}
