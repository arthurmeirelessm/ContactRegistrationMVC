using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class ContactModel : BaseModel
    {

        [Required(ErrorMessage = "Enter contact name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your Email")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your contact number")]
        [Phone(ErrorMessage = "The contact number is not valid")]
        public string Number { get; set; }
    }
}
    