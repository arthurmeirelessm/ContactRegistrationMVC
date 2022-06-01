using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository.Interfaces;
using System.Linq;

namespace ContactRegistrationMVC.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _dataContext;

        public LoginRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool ComparateLogin(DataLoginModel dataLoginModel)
        {

            var identificationUserName = _dataContext.Users.FirstOrDefault(x => x.Login == dataLoginModel.UserName);
            var identificationPassword = _dataContext.Users.FirstOrDefault(x => x.Password == dataLoginModel.Password);

            if (identificationUserName is not null && identificationPassword is not null)
            {
                return true;
            }
            return false;

        }
    }
}
