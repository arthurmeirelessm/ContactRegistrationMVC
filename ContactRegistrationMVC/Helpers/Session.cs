using ContactRegistrationMVC.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ContactRegistrationMVC.Helpers
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _iHttpContextAccessor;

        public Session(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }

        public void CreateSessionOfUser(UserModel user)
        {
            // JsonConvert aqui em baixo serve para converter objeto em string
            // Isso foi feito por que logo abaixo vai ter uma instrução pra guardar esse valor convertido, sendo passado como "valor" que é a variavel
            string valor = JsonConvert.SerializeObject(user);

            _iHttpContextAccessor.HttpContext.Session.SetString("sessionUserLogged", valor); 
        }

        public UserModel GetSessionOfUser()
        {
            string sessionUser = _iHttpContextAccessor.HttpContext.Session.GetString("sessionUserLogged");

            return string.IsNullOrEmpty(sessionUser) ? null : JsonConvert.DeserializeObject<UserModel>(sessionUser);
        }

        public void RemoveSessionOfUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
