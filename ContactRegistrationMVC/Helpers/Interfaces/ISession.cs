using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Helpers
{
    public interface ISession
    {
        public void CreateSessionOfUser(UserModel user);
        public void RemoveSessionOfUser();
        public UserModel GetSessionOfUser();
    }
}
