using ContactRegistrationMVC.Models;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Repository
{
    public interface IContactRepository
    {
        public List<ContactModel> SeachAll();  
        public ContactModel Add(ContactModel contact);

        public ContactModel ListById(int id); 
    }
}
