using ContactRegistrationMVC.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;



// SESSION É UMA CLASSE ONDE TEMOS 3 METODOS, UM DE CRIACAO, BUSCA E DELEÇÃO DE SESSOES DE USUARIO
// EX: O DE BUSCA QUE É GetSessionOfUser, FAZ A BUSCA DO USUARIO PRA SABER SE ELE JA SE LOGOU ALGUMA VEZ NA APLICAÇÃO
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
            string value = JsonConvert.SerializeObject(user);

            _iHttpContextAccessor.HttpContext.Session.SetString("sessionUserLogged", value); 
        }

        public UserModel GetSessionOfUser()
        {
            string sessionUser = _iHttpContextAccessor.HttpContext.Session.GetString("sessionUserLogged");

            return string.IsNullOrEmpty(sessionUser) ? null : JsonConvert.DeserializeObject<UserModel>(sessionUser);
        }

        public void RemoveSessionOfUser()
        {
            _iHttpContextAccessor.HttpContext.Session.Remove("sessionUserLogged");
        }
    }
}
