using ContactRegistrationMVC.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace ContactRegistrationMVC.Filters
{
    public class PageToUserLogged : ActionFilterAttribute
    {
        //Classe com o metodo abaixo no objetivo de bloqueiar quando algum usuario tenta entra em "Home" alterando a rota
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessionUser = context.HttpContext.Session.GetString("sessionUserLogged");

            if (string.IsNullOrEmpty(sessionUser))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary);
            }
            base.OnActionExecuting(context);
        }
    }
}
