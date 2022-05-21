using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
     

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {

            List<ContactModel> seachAll = _contactRepository.SeachAll();
            return View(seachAll);
           
        }

       
        public IActionResult Create()
        {
           return View();   
        }

        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult ConfirmDelete()
        {
            return View();
        }
       

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            _contactRepository.Add(contact);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            _contactRepository.UpdateEdit(contact);

            return RedirectToAction("Index");
        }

    }
}
