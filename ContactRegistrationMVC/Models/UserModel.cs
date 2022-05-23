using ContactRegistrationMVC.Enums;
using System;

namespace ContactRegistrationMVC.Models
{
    public class UserModel : BaseModel
    {

        public string Name { get; set; }
        public string Login { get; set; }
        public bool Email { get; set; }
        public UserEnum UserType { get; set; }
        public string password { get; set; }
        public DateTime DateUpAt { get; set; }

    }
}
