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

        public bool Delete(int id)
        {
            ContactModel identificationDb = ListById(id);

            if (identificationDb is null)
            {
                throw new System.Exception("Error of delete (No Id compatible)");
            }

            _dataContext.Contacts.Remove(identificationDb);

            _dataContext.SaveChanges();

            return true;

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

        public ContactModel UpdateEdit(ContactModel contact)
        {
            ContactModel identificationDb = ListById(contact.Id);

            if (identificationDb is null)
            {
                throw new System.Exception("Error of update (No Id compatible)");
            }
            
            identificationDb.Name = contact.Name;
            identificationDb.Email = contact.Email;
            identificationDb.Number = contact.Number;

            _dataContext.Contacts.Update(identificationDb);
            _dataContext.SaveChanges();

            return identificationDb;    
        }
    }
}