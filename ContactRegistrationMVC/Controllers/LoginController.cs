using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistrationMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EnterLogin(DataLoginModel dataLoginModel)
        {
            try
            {
               if (ModelState.IsValid)
                {
                    var comparate = _loginRepository.ComparateLogin(dataLoginModel);
                    if (comparate)
                    {
                        TempData["MessageSuccess"] = "User enter with success";
                        return RedirectToAction("Index", "Home");
                    }
                }
               return View("Index");
            } 
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = $"User not enter with succes. Error: {error.Message}";
                return RedirectToAction("Index");
            }
        }





    }
}
