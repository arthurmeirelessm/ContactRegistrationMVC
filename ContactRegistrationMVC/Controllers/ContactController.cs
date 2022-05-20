using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

       
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
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
    }
}
