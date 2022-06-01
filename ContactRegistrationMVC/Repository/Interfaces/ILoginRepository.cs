using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Repository.Interfaces
{
    public interface ILoginRepository
    {

        public bool ComparateLogin(DataLoginModel dataLoginModel);

    }
}
