using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;
using System.Collections.Generic;
using System.Linq;

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

        public ContactModel ListById(int id)
        {
          var identification = _dataContext.Contacts.FirstOrDefault(x => x.Id == id);

            return identification;
        }

        public List<ContactModel> SeachAll()
        {
            return _dataContext.Contacts.ToList();
        }


    
    }
}