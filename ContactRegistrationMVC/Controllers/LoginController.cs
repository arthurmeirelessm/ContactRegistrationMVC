using ContactRegistrationMVC.Helpers;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactRegistrationMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISession _session;

        public LoginController(IUserRepository userRepository, ISession session)
        {
            _userRepository = userRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            // Se o usuario estiver com uma sessão aberta, ou seja, ja tiver logado seu perfil alguma vez na tela de login, ele será rediciondo direto pro index "Home"
            if (_session.GetSessionOfUser() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Exit()
        {
           _session.RemoveSessionOfUser();
            return RedirectToAction("Index", "Login");
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
                        _session.CreateSessionOfUser(comparateUserName);
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
