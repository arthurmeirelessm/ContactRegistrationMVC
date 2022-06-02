using ContactRegistrationMVC.Helpers;
using ContactRegistrationMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace ContactRegistrationMVC.Filters
{
    public class PageRestrictOnlyAdmin : ActionFilterAttribute
    {
        //Classe com o metodo abaixo no objetivo de bloqueiar quando algum usuario tenta entra em "Home" alterando a rota
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessionUser = context.HttpContext.Session.GetString("sessionUserLogged");

            if (string.IsNullOrEmpty(sessionUser))
            {
                // O que ele quis dizer aqui em baixo?
                //Se esse if for nulo ou vazio ele retornara um redicionamento feito pelo "Context.Result"
                //Dentro dele será passado os paramentros para qual controller e action ele será redirecionado
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(sessionUser);
                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if (user.UserType != Enums.UserEnum.ADM)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrict" }, { "action", "Index" } });
                }
            }

    
            base.OnActionExecuting(context);
        }
    }
}
