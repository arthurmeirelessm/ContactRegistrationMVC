using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistrationMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EnterLogin(DataLoginModel dataLoginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var comparateUserName = _userRepository.ComparateUserName(dataLoginModel);
                    var comparatePassword = _userRepository.ComparatePassword(dataLoginModel);

                    if (comparateUserName != null && comparatePassword != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MessageFailed"] = "This user not found. Try again with other UserName or password";
                }

                return View("Index");

            }
            catch (System.Exception error)
            {
                TempData["MessageFailed"] = $"User not enter with success. Error: {error.Message}";
                return RedirectToAction("Index");
            }
        }





    }
}
