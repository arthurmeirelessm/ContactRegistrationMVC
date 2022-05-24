using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //METODOS VIEWS, RETORNA SEMPRE REDIRECIONAMENTO DE TELA
        //Quando for realzar o CRUD, sempre indicar o tipo de metodo que aquela tela precisará
        //como no metodo "Index" abaixo, que busca o metdo seachAll que está dentro de _contactRepository
        //Isso indicará que essa tela precisará foi uma busca de todos os contatos registrados no backEnd
        public IActionResult Index()
        {
            List<UserModel> userModel = _userRepository.SeachAll();
            return View();
        }

    
    }
}
