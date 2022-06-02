using System.ComponentModel.DataAnnotations;

namespace ContactRegistrationMVC.Models
{
    public class RedefineLoginModel
    {
        [Required(ErrorMessage = "Enter with your UserName")]
        public string UserName { get; set;}
        [Required(ErrorMessage = "Enter with your Email")]
        public string Email { get; set;}
    }
}
