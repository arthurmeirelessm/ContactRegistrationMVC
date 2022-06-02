using ContactRegistrationMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ContactRegistrationMVC.NewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessionUser = HttpContext.Session.GetString("sessionUserLogged");
            if (string.IsNullOrEmpty(sessionUser))
            {
                return null;
            }

            UserModel user = JsonConvert.DeserializeObject<UserModel>(sessionUser);

            return View(user);
        }
    }
}
