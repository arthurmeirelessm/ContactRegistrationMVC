using ContactRegistrationMVC.Models;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Repository.Interfaces
{
    public interface IUserRepository
    {
        public UserModel Add(UserModel contact);
        public UserModel ListById(int id);
        public UserModel SameEmail(UserModel user);
        public List<UserModel> SeachAll();
        public UserModel SameLogin(UserModel login);
        public UserModel UpdateEdit(UserModel contact);
        public bool Delete(int id);
        public UserModel ComparateUserName(DataLoginModel dataLoginModel);
        public UserModel ComparatePassword(DataLoginModel dataLoginModel);
        public UserModel ComparaIsUserNameIsSameToRefineLogin(RedefineLoginModel redefineLoginModel);
        public UserModel ComparaIsEmailIsSameToRefineLogin(RedefineLoginModel redefineLoginModel);

    }
}
