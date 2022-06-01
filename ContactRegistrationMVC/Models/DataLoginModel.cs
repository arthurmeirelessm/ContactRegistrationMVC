using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Sdk;

namespace ContactRegistrationMVC.Models
{
    public class DataLoginModel
    {

        [Required(ErrorMessage = "Enter with your UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter with your password")]
        public string Password { get; set; }

    }
}
