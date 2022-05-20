using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Repository
{
    public interface IContactRepository
    {
        public ContactModel Add(ContactModel contact);
    }
}
