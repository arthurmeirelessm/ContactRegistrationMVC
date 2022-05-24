using ContactRegistrationMVC.Models;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Repository.Interfaces
{
    public interface IUserRepository
    {
        public List<UserModel> SeachAll();
        public UserModel Add(UserModel contact);
        public UserModel ListById(int id);
        public UserModel SameEmail(UserModel user);
        public UserModel SameLogin(UserModel login);
        public UserModel UpdateEdit(UserModel contact);
        public bool Delete(int id);

    }
}
