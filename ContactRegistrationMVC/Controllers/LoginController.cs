using Microsoft.AspNetCore.Mvc;

namespace ContactRegistrationMVC.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
