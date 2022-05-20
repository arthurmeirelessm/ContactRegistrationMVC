using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _dataContext;

        public ContactRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public ContactModel Add(ContactModel contact)
        {
            // Registration in Database

            _dataContext.Contacts.Add(contact);
            _dataContext.SaveChanges();

            return contact;
        }
    }
}
